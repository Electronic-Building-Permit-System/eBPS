#Run below commands on the terminal :
cd eBPS.SharedDbDeployment
dotnet new tool-manifest
dotnet tool install FluentMigrator.DotNet.Cli

cd eBPS.OrganizationDbDeployment
dotnet new tool-manifest
dotnet tool install FluentMigrator.DotNet.Cli

