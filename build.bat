dotnet build src -c Release -o dist/OSX --no-incremental /p:MyTarget=OSX
dotnet build src -c Release -o dist/Linux --no-incremental /p:MyTarget=Linux
dotnet build src -c Release -o dist/Windows --no-incremental /p:MyTarget=Windows