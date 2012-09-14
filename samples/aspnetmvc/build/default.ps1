Framework '4.0'

properties {
	$solutionName = 'MvcSample'
	$configuration = 'Debug'
	$platform = 'Any CPU'
	$versionMajor = '1'
	$versionMinor = '0'
	$version = $versionMajor + '.' + $versionMinor + '.' + $buildNumber + '.0'
    	
	$solutionPath = '../'
	$solutionFilename = $solutionPath + $solutionName + '.sln'
	$webPath = $solutionPath + 'src/Web'
	$migrationsPath = $solutionPath + 'src/Migrations/bin/Debug'
    $migrationsDllName = $solutionName + '.Migrations'
    $migratorPath = $solutionPath + 'packages/FluentMigrator.Tools.*/tools/AnyCPU/40'
	
	$deployBasePath = $solutionPath + 'deploy/'
	$deployPath = $deployBasePath + '/' + $configuration + '/'
	$deployWebFilename = $deployPath + 'Web_v' + $version + '-' + $configuration + '-' + $platform + '.zip'
	$deployMigrationsFilename = $deployPath + 'Migrations_v' + $version + '-' + $configuration + '-' + $platform + '.zip'
	
    $migrator = (Get-Item "$migratorPath/Migrate.exe")
	$xunit = $solutionPath + 'packages/xunit.runners.1.9.1/tools/xunit.console.clr4.exe'
}

task default -depends DoNotRunItDirectly

task DoNotRunItDirectly {
	'Do not run it directly!'
}

task Dev -depends EnsureParams, PrepareDev, Build, Test, Deploy
task Production -depends EnsureParams, PrepareProduction, Build, Test, Deploy

task EnsureParams {
	Assert ($buildNumber -ne $null) 'Property `$buildNumber should be specified'`
}

task PrepareDev {

}

task PrepareProduction {
	
}

task Build {
	MSBuild -t:Build -p:Configuration=$configuration $solutionFilename
}

task Migrate -depends Build {
	Invoke-Expression "$migrator --provider=sqlserver --connectionString=Main --target=$migrationsPath/$migrationsDllName.dll"
}

task Test {
    (Get-Item '..\src\*\bin\Debug\*.tests.dll') | ForEach-Object { Invoke-Expression "$xunit $_" }
}

task PrepareDeploy {
	if ((Test-Path $deployBasePath) -ne $true) 
	{
		New-Item $deployBasePath -Type directory
	}	
	if ((Test-Path $deployPath) -ne $true)
	{
		New-Item $deployPath -Type directory
	}
}

task Deploy -depends DeployWeb, DeployMigrations

task DeployWeb -depends PrepareDeploy {
	Write-Zip ("$webPath/*") -OutputPath $deployWebFilename -Quiet
}

task DeployMigrations -depends PrepareDeploy {
	Write-Zip ("$migratorPath/*", "$migrationsPath/$migrationsDllName.*", "$migrationsPath/RunMe.*") -OutputPath $deployMigrationsFilename -Quiet
}