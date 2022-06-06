# Title
How to configure CICD pipelines between azure container app on azure and azure devops pipelines and release pipelines.

### Deployment Architecture
The architecture illustrate how a developer will push code to source repository (Github), automatically trigger a build on azure devops by building and pushing image to dockerhub and lastly update azure container app.

![containerapp-azure-devops](https://user-images.githubusercontent.com/74520811/172013520-19900809-651b-4f70-89ad-857c80e25f9b.png)

## What is container app
Azure containerapp is a serverless compute engine for running container apps on `Microsoft Azure`. [Click here to know more about it](https://azure.microsoft.com/en-us/services/container-apps/).

### Requirements
Step 1:
#### Azure Account setup
* Have an azure account.
* Install Azure cli.
* Log into azure using cli. `az login`

Step 2:
#### Dockerhub Account setup
***Note:*** Skip this section if using azure container registry.
* Have a dockerhub account.
* Install docker.
* Log into your docker hub using your cli. `docker login`

Step 3:
#### Azure Devops Account setp
* Have an azure devops account.
* Log into azure devops by clicking on the link [Azure Devops](https://dev.azure.com/).
* Create or select an existing azure organization.
* Create a new project in azure organization.

**Note:** `You may have to purchase or request for parralel job from microsoft else your pipelines will fail. To know more about azure parallel jobs or to configure and pay for parralel jobs`, [Click Here](https://docs.microsoft.com/en-us/azure/devops/pipelines/licensing/concurrent-jobs?view=azure-devops&tabs=ms-hosted). 

Step 4:
#### Authenticate between Azure Devops and Github, Dockerhub and Microsoft Azure
* Log into your github account and install azure pipeline in the repository you wont to use in your azure pipeline. You can also install azure pipeline on your entire organization, which will by default install in any repository that exists in that organization and also repository to be created. [How to setup](https://www.youtube.com/watch?v=CYAYomx00PA)
* Create a service connection between azure devops and dockerhub.
* Create a service connection between azure devops and azure.

Now that we have successfully setup the necessary requirements, we are going to start setting up our CICD pipeline between microsoft azure container app and azure devops.



**Build Pipeline yaml doc**

```
trigger:
- master

pool:
  vmImage: ubuntu-latest

steps:
  - task: Docker@2
    inputs:
      containerRegistry: [DOCKERHUB_CONNECTION_FROM_SERVICE_CONNECTION]
      repository: [CONTAINER_REPOSITORY]
      command: 'build'
      Dockerfile: '**/Dockerfile'
      tags: 'latest'
  - task: Docker@2
    inputs:
      containerRegistry: [DOCKERHUB_CONNECTION_FROM_SERVICE_CONNECTION]
      repository: [CONTAINER_REPOSITORY]
      command: 'push'
      tags: 'latest'
```

Demo: [click here to watch a video on how to configure the pipeline]()