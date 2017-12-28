FROM microsoft/aspnetcore:2
LABEL Author="rsantosdev"

WORKDIR /app
COPY AzureSearchDashboard/bin/Release/netcoreapp2.0/publish/ .
ENTRYPOINT ["dotnet", "AzureSearchDashboard.dll"]
