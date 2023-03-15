param ($version)

if ($version -eq $null) {
    $version = read-host -Prompt "Please enter package version" 
} 

dotnet pack --configuration Release

dotnet nuget push ./bin/Release/REGON.1.0.1.nupkg -s https://api.nuget.org/v3/index.json -k oy2n6v7om373ulpjz5zatwtnaseuymmujovfzwuwqilpr4