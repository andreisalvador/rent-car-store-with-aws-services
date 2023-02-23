$QueueUrlBase = "http://localhost:4566/000000000000/"
$QueueArnBase = "arn:aws:sqs:us-east-1:000000000000:"
$TopicArnBase = "arn:aws:sns:us-east-1:000000000000:"

$TopicGarageName = "garage"
$TopicContractsName = "contracts"

$QueueGarageNames = @("garage-finance")
$QueueContractsNames = @("contracts-finance")

$TopicNames = @($TopicGarageName, $TopicContractsName)
$QueueNames = $QueueGarageNames + $QueueContractsNames

$TopicsAndQueues = New-Object System.Collections.Generic.Dictionary"[String,String[]]"
$TopicsAndQueues.Add($TopicGarageName, $QueueGarageNames)
$TopicsAndQueues.Add($TopicContractsName, $QueueContractsNames)


Function CreateTopics
{
    foreach($TopicName in $TopicNames)
    {
        awslocal sns create-topic --name $TopicName
    }
}

Function CreateQueues
{
    foreach($QueueName in $QueueNames)
    {
        $QueueArn = ("{0}{1}" -f $QueueArnBase, $QueueName)
        awslocal sqs create-queue --queue-name $QueueName --attributes QueueArn=$QueueArn
    }
}

Function SubscribeTopic
{
    param([String]$TopicName, [String]$QueueName)
    $TopicArn=("{0}{1}" -f $TopicArnBase, $TopicName)
    $QueueEndpoint=("{0}{1}" -f $QueueArnBase, $QueueName)
    awslocal sns subscribe --topic-arn $TopicArn --protocol sqs --notification-endpoint=$QueueEndpoint
}

Function SubscribeQueuesToTopic
{  
    foreach($TopicName in $TopicNames)
    {
        $Queues = $TopicsAndQueues[$TopicName]

        foreach($Queue in $Queues)
        {
            SubscribeTopic -TopicName $TopicName -QueueName $Queue
        }
    }    
}

CreateTopics
CreateQueues
SubscribeQueuesToTopic