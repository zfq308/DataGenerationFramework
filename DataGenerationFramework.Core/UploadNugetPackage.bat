﻿nuget pack DataGenerationFramework.Core.csproj -Prop Configuration=Release
nuget setApiKey d7def725-6c14-4fc2-97dc-60fd58fc9ca2  -Source https://www.nuget.org/api/v2/package
nuget push DataGenerationFramework.Core.1.0.0.0.nupkg -Source https://www.nuget.org/api/v2/package