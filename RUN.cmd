@echo off
chcp 65001 >nul
cd /d "%~dp0"
dotnet restore
if errorlevel 1 goto error
dotnet tool restore
if errorlevel 1 goto error
dotnet ef database update
if errorlevel 1 goto error
start "" http://localhost:5080
dotnet run --no-launch-profile --urls http://localhost:5080
pause
exit /b
:error
echo Setup failed. Read README.md or send the error text.
pause
exit /b 1
