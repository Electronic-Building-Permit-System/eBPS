@echo off
set SHARED_DB_CONNECTION_STRING="Server=.;Database=eBPS;Integrated Security=true;TrustServerCertificate=True;"
set SHARED_MIGRATION_DLL="%~dp0..\bin\Debug\net8.0\eBPS.SharedDbDeployment.dll"

dotnet fm migrate --assembly %SHARED_MIGRATION_DLL% --connection %SHARED_DB_CONNECTION_STRING% --processor SqlServer
if errorlevel 1 (
    echo Shared migrations failed! Aborting.
    exit /b 1
)
echo Shared migrations completed successfully!
