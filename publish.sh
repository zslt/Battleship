#!/bin/sh
rm -r ./artifacts; mkdir ./artifacts
dotnet publish ./src/Battleship.Cli/Battleship.Cli.csproj -c Release -r linux-x64