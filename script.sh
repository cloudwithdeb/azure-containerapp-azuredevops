#!/bin/bash
CONTAINERAPP_ENVIRONMENT="todoscontainerenvironment"
CONTAINER_APP_NAME="aztocontainerapp"
RESOURCE_GROUP="azTodoResourceGroup"
WORKSPACE_NAME="todo-log-analytics"
CONTAINER_NAME="todocontainer"
IMAGE_NAME="containerapp-todo"
LOCATION="canadacentral"
USERNAME="cloudwithdeb"
PORT=5146

#Build and push docker image to docker hub
docker image build -t $IMAGE_NAME .
docker image tag $IMAGE_NAME $USERNAME/$IMAGE_NAME:latest
docker image push $USERNAME/$IMAGE_NAME

# Does resource group exists?
DoesResourceGroupExists=$(az group exists -n $RESOURCE_GROUP)

# Deploy azure container app if resource group does not exists.
if [[ $DoesResourceGroupExists -eq false ]]
then 

    az provider register --namespace Microsoft.App
    az extension add -n containerapp

    az group create --name $RESOURCE_GROUP --location $LOCATION
    az monitor log-analytics workspace create -g $RESOURCE_GROUP -n $WORKSPACE_NAME

    WORKSPACE_ID=`az monitor log-analytics workspace show --query customerId -g $RESOURCE_GROUP -n $WORKSPACE_NAME -o tsv | tr -d '[:space:]'`
    WORKSPACE_PRIMARY_KEY=`az monitor log-analytics workspace get-shared-keys --query primarySharedKey -g $RESOURCE_GROUP -n $WORKSPACE_NAME -o tsv | tr -d '[:space:]'`

    az containerapp env create --name $CONTAINERAPP_ENVIRONMENT --logs-workspace-key $WORKSPACE_PRIMARY_KEY \
    --resource-group $RESOURCE_GROUP --location $LOCATION --logs-workspace-id $WORKSPACE_ID

    az containerapp create -n $CONTAINER_APP_NAME --resource-group $RESOURCE_GROUP --environment $CONTAINERAPP_ENVIRONMENT \
    --image $USERNAME/$IMAGE_NAME  --target-port $PORT --ingress 'external' --target-port $PORT \
    --query properties.configuration.ingress.fqdn  --min-replicas 0 --max-replicas 5

fi

