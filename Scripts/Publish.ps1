Param($ApiKey, $Version)

dotnet nuget push --source GithubPackages ..\Cosmic\bin\Debug\ARMunro.Cosmic.${Version}.nupkg --api-key $ApiKey
dotnet nuget push --source GithubPackages ..\Cosmic.CommandLine\bin\Debug\ARMunro.Cosmic.CommandLine.${Version}.nupkg --api-key $ApiKey
