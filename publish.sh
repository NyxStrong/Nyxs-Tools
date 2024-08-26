#/bin/bash

dotnet pack -c Release
dotnet nuget push "Nyxs Tools/bin/Release/Nyxs_Tools.$(xmllint --xpath '//Project/PropertyGroup/version/text()' Nyxs\ Tools/Nyxs\ Tools.csproj).nupkg" --source "github"


