# Copyright 2011 Scott Banwart

# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at

# http://www.apache.org/licenses/LICENSE-2.0

# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

if ($env:BTSINSTALLPATH) {
  Add-Type -Path "$env:BTSINSTALLPATH\Developer Tools\Microsoft.BizTalk.ExplorerOM.dll"
  $btsCatalog = New-Object Microsoft.BizTalk.ExplorerOM.BTSCatalogExplorer
  $btsCatalog.ConnectionString = "Data Source=localhost;Initial Catalog=BizTalkMgmtDb;Integrated Security=SSPI"
}

function Add-Application([string]$appName, [string]$appDescription = "") {
    $app = $btsCatalog.AddNewApplication()
    $app.Name = $appName
    $app.Description = $appDescription
    $btsCatalog.SaveChanges()
}

function Remove-Application([string]$appName) {
    $app = $btsCatalog.Applications["$appName"]
    $btsCatalog.RemoveApplication($app)
    $btsCatalog.SaveChanges()
}

function Add-ApplicationReference([string]$sourceAppName, [string]$destinationAppName) {
  $sourceApp = $btsCatalog.Applications["$sourceAppName"]
  $destinationApp = $btsCatalog.Applications[$destinationAppName]

  $destinationApp.AddReference($sourceApp)
  $btsCatalog.SaveChanges()
}

function Remove-ApplicationReference([string]$sourceAppName, [string]$destinationAppName) {
  $sourceApp = $btsCatalog.Applications[$sourceAppName]
  $destinationApp = $btsCatalog.Applications[$destinationAppName]

  $destinationApp.RemoveReference($sourceApp)
  $btsCatalog.SaveChanges()
}

function Restart-HostInstances([string[]]$hostInstances) {
    foreach ($hostInstance in $hostInstances) {
        Stop-HostInstance "$hostInstance"
        Start-HostInstance "$hostInstance"
    }
}

function Stop-HostInstance([string]$hostInstanceName) {
    Stop-Service "$hostInstanceName"
}

function Start-HostInstance([string]$hostInstanceName) {
    Start-Service "$hostInstanceName"
}

function ExportMsi([string]$appName, [string]$msiPath) {
    btstask.exe ExportApp -ApplicationName:"$appName" -Package:(Join-Path $msiPath "$appName.msi")
}
