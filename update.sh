#!/bin/bash
RESOURCE_GROUP="azTodoResourceGroup"
CONTAINER_NAME="aztocontainerapp"
IMAGE_NAME="containerapp-todo"
USERNAME="cloudwithdeb"

# Enable containerapp extension
az extension add -n containerapp

# Update container app
az containerapp update --name $CONTAINER_NAME --resource-group $RESOURCE_GROUP --image $USERNAME/$IMAGE_NAME:latest