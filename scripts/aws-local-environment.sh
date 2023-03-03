queueUrlBase="http://localhost:4566/000000000000/"
queueArnBase="arn:aws:sqs:us-east-1:000000000000:"
topicArnBase="arn:aws:sns:us-east-1:000000000000:"
topicGarageName="garage"
topicContractsName="contracts"
queueGarageNames=("garage-finance")
queueContractsNames=("contracts-finance")
topicNames=($topicGarageName $topicContractsName)
queueNames=("${queueGarageNames[@]}" "${queueContractsNames[@]}")
declare -A topicsAndQueues=([$topicGarageName]=$queueGarageNames [$topicContractsName]=$queueContractsNames)

#Create topics
for topicName in "${topicNames[@]}"
do
  echo "Creating topic =====> ($topicName)"
    awslocal sns create-topic --name $topicName
done

#Create queues
for queueName in "${queueNames[@]}"
do
    echo "Creating queue =====> ($queueName)"
    awslocal sqs create-queue --queue-name $queueName --attributes QueueArn="${queueArnBase}${queueName}"
done

#Subscribe queues to topics
for topicName in "${!topicsAndQueues[@]}"
do
    for queueName in "${topicsAndQueues[$topicName]}"
    do
        echo "Subscribing queue ($queueName) to topic ($topicName)"
        awslocal sns subscribe --topic-arn "${topicArnBase}${topicName}" --protocol sqs --notification-endpoint="${queueArnBase}${queueName}"
    done    
done