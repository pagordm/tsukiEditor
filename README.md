# Tsuki's Oddyssey save editor
## What is this?
This is a concept for a save editor for the mobile game "Tsuki's Oddyssey". By finding out the serialization library used in the game, we can edit the save file.
Right now only reading the save file data is programmed, as editing the data requires for the full class structure to be written. 

I estimate the completion percentage for TsukiSave.cs is at 25%.

I had to modify the ```standalone-library``` branch of the Odin Serializer as it would not compile without Unity (even though it should). You can find the modifications inside OdinSerializerNetCore.csproj

## Building
Building requires .Net Core 3.1. Modify the save file path in [test/Program.cs](test/Program.cs) to make it work with yours.

## Credits
All credits of the [Odin Serializer](https://github.com/TeamSirenix/odin-serializer) go to its original authors.