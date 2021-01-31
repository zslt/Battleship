# Battleship

This is a battlship game repository. It contains a console application project and a game logic library. They target the .net5.0 framework.

## Usage

The console application can be published (/artifacts path) as a self-contained single file executable.
Windows example:
```
dotnet publish -c Release -r win-x64
```
Linux example:
```
dotnet publish -c Release -r linux-x64
```
Alternatively, you can run the publish.ps script (ps script is not tested yet, development is done on Linux) or the publish.sh script.

The console application can be configured with an appsettings.json file.
Example:
```
{
    "BattleshipConfiguration": {
        "GridSize": 10,
        "Ships": [
            {
                "Name": "Battleship",
                "Quantity": 1,
                "Size": 5
            },
            {
                "Name": "Destroyer",
                "Quantity": 2,
                "Size": 4
            }
        ]
    }
}
```
Ships cannot have greater size than the size of the gird. At leas one ship has to be provided. The total size of ships cannot be greater than the total area of the grid. The maximum allowed grid size is 10.