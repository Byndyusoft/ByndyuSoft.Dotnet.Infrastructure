@echo off
Migrate --assembly=MvcSample.Migrations.dll --provider=sqlserver --connectionString=Main --verbose=true
pause