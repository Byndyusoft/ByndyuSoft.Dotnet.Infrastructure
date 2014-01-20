@echo off
..\..\packages\FluentMigrator.Tools.1.0.6.0\tools\AnyCPU\40\Migrate.exe --assembly=bin\Debug\MvcSample.Migrations.dll --provider=sqlserver --connectionString=Main --verbose=true
pause