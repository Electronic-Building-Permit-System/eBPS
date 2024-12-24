@echo off
echo Running Roles data insertion...

REM Define database and server
set SERVER_NAME=.
set DATABASE_NAME=eBPS

REM Run SQL script using Windows Authentication
sqlcmd -S %SERVER_NAME% -d %DATABASE_NAME% -E -i InsertRoles.sql

IF %ERRORLEVEL% EQU 0 (
    echo Data inserted successfully!
) ELSE (
    echo Failed to insert data. Please check your connection or SQL script.
)

pause
