@echo off
setlocal

:: Fetch tenant connection strings
set SQL_QUERY="SELECT ConnectionString FROM OrganizationsConfig WHERE IsActive = 1"
set TEMP_FILE=tenant_connection_strings.txt
set TENANT_MIGRATION_DLL="%~dp0..\bin\Debug\net8.0\eBPS.OrganizationDbDeployment.dll"

:: Run SQL query to get connection strings and store them in a temporary file
powershell -Command "Invoke-Sqlcmd -ServerInstance '.' -Database 'eBPS' -Query '%SQL_QUERY%' | Select-Object -ExpandProperty ConnectionString | ForEach-Object {$_ -replace '\r', ''} > '%TEMP_FILE%'"

:: Check if the file has been created successfully
if not exist %TEMP_FILE% (
    echo Error: Could not fetch tenant connection strings. Aborting.
    exit /b 1
)

:: Run tenant database migrations
for /f "delims=" %%T in ('type "%TEMP_FILE%"') do (
    :: Debugging: Display the connection string being processed
    echo Processing: %%T
    
    :: Run migration command for the tenant DB
    echo Running migration for tenant DB: %%T
    dotnet tool run dotnet-fm migrate --assembly "%TENANT_MIGRATION_DLL%" --processor SqlServer --connection "%%T"
    
    :: Check if migration was successful
    if errorlevel 1 (
        echo Tenant migration failed for DB: %%T. Aborting.
        exit /b 1
    )
)

:: Clean up temporary file
del %TEMP_FILE%

endlocal
echo All migrations completed successfully!
