# Title
How to configure CICD pipelines between azure container instance and azure devops pipelines and release pipelines.

## What is container app
Azure containerapp is a serverless compute engine for running container apps on `Microsoft Azure`. [Click here to know more about it](https://azure.microsoft.com/en-us/services/container-apps/).

## Requirements
SteP 1:
* Have an azure account.
* Install Azure cli.
* Log into azure using cli.

Step 2:
* Have a docker hub account.
* Install docker.
* Log into your docker hub using your cli.

Log into azure devops by clicking on the link [Azure Devops](https://dev.azure.com/).

```

trigger:
- master

pool:
  vmImage: ubuntu-latest

steps:
  - task: Docker@2
    inputs:
      containerRegistry: 'eventh-epfs-dockerhub'
      repository: 'debcloud/eleventh-epfs'
      command: 'build'
      Dockerfile: '**/signup/Dockerfile'
      tags: 'latest'
  - task: Docker@2
    inputs:
      containerRegistry: 'eventh-epfs-dockerhub'
      repository: 'debcloud/eleventh-epfs'
      command: 'push'
      tags: 'latest'
```