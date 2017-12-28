# Azure Search Dashboard
A custom dashboard to search across azure search indexes.

Build Status: ![Build Status](https://circleci.com/gh/rsantosdev/azure-search-dashboard/tree/master.svg?style=shield&circle-token=5702a2351b869e44622ff04dfabfefd158ee55e6)

### Links
* Docker Image: https://hub.docker.com/r/rsantosdev/
* Live sample: http://azure-search-dashboard.azurewebsites.net/

  username: demo / password: azure

### Running the container
To run the container locally or on Azure you need to provide some environment variables:

* AzureSearchServiceName=serviceName
* AzureSearchServiceAdminApiKey=serviceApiKey
* AuthUsername=demo
* AuthPassword=azure

`docker run -d -p 8000:80 --env-file .\azure-search-dash.list rsantosdev/azure-search-dashboard`

### Issues and Features
Please submit your issues and feature requests.
