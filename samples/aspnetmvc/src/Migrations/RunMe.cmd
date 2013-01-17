@echo off
Migrate --assembly=MvcSamples.Migrations.dll --provider=sqlserver --connectionString=Main --verbose=true
pause