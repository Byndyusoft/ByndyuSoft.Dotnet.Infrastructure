@echo off
..\..\..\..\packages\FluentMigrator.Tools.1.0.3.0\tools\AnyCPU\40\Migrate.exe --assembly=MvcSample.Migrations.dll --provider=sqlserver --connectionString=Main --verbose=true
pause