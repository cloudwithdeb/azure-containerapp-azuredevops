# Title
How to configure CICD pipelines between azure container app and azure devops pipelines and release pipelines.

### Deployment Architecture
![containerapp-azure-devops](https://user-images.githubusercontent.com/74520811/172013520-19900809-651b-4f70-89ad-857c80e25f9b.png)

## What is container app
Azure containerapp is a serverless compute engine for running container apps on `Microsoft Azure`. [Click here to know more about it](https://azure.microsoft.com/en-us/services/container-apps/).

### Requirements
SteP 1:
* Have an azure account.
* Install Azure cli.
* Log into azure using cli.

Step 2:
* Have a docker hub account.
* Install docker.
* Log into your docker hub using your cli.

Step 3:
* Have an azure devops account.
* Log into azure devops by clicking on the link [Azure Devops](https://dev.azure.com/).
* Create or select an existing azure organization.
* Create a new project in azure organization

**Note:** You may have to purchase or request for parralel job from azure. If you dont have one, your pipelines will fail. `To configure and pay for parralel jobs` [Click Here](https://docs.microsoft.com/en-us/azure/devops/pipelines/licensing/concurrent-jobs?view=azure-devops&tabs=ms-hosted). 

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
