Remove-Item .\artifacts -Recurse -ErrorAction Ignore
New-Item -ItemType Directory -Force -Path .\artifacts
dotnet publish .\src\Battleship.Cli\Battleship.Cli.csproj -c Release -r win-x64