function Invoke-SqlCommand {
  [cmdletbinding(DefaultParameterSetName='customauth')]
  param(
      [Parameter(Mandatory=$false)]
      [string] 
      $sqlServer = ".\SQLEXPRESS",
      
      [Parameter(Mandatory=$false)]
      [string] 
      $database = "Northwind",
      
      [Parameter(Mandatory=$true)]   
      [string] 
      $sqlCommand,
      
      [Parameter(Mandatory=$false, ParameterSetName='credauth')]
      [System.Management.Automation.PsCredential] 
      $credential,
      
      [Parameter(Mandatory=$false, ParameterSetName='customauth')]
      [string] 
      $authentication ="Integrated Security=SSPI;",
      
      [Parameter(ParameterSetName='devauth')]
      [switch]
      $developmentAuthentication
    )

  switch ($PsCmdlet.ParameterSetName) { 
    'devauth' {
      $authentication = 'User ID=sa;Password=pass'
      Write-Debug "Using development authentication: $authentication"
    }
    'credauth' {
      $plainCred = $credential.GetNetworkCredential()
      $authentication = "uid={0};pwd={1};" -f $plainCred.Username,$plainCred.Password
      Write-Debug "Using passed credentials, user: $($plainCred.Username)"
    }
    'customauth' {
      Write-Debug "Using custom authentication: $authentication"
    }
    default { throw "Parameter set name unknown: $($PsCmdlet.ParameterSetName)" }
  }

  $connectionString = "Server=$sqlServer;Database=$database;$authentication;"

  write-debug "Connection string: $connectionString"
  ## Connect to the data source and open it
  $SqlConnection = New-Object System.Data.SqlClient.SqlConnection
  $SqlConnection.ConnectionString = $connectionString

  $SqlCmd             = New-Object System.Data.SqlClient.SqlCommand
  $SqlCmd.CommandText = $sqlCommand
  $SqlCmd.Connection  = $SqlConnection
  $SqlAdapter         = New-Object System.Data.SqlClient.SqlDataAdapter
  $SqlAdapter.SelectCommand = $SqlCmd
  $dataSet            = New-Object System.Data.DataSet
  $SqlAdapter.Fill($dataSet)
  $SqlConnection.Close()
  $SqlCmd.Dispose()

  ## Return all of the rows from their query
  $dataSet.Tables | Select-Object -Expand Rows
}