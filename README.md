## How to get started


dotnet new web

+ tilføj nuget package: NSwag.AspNetCore

+ tilføj controllers og entitet

+ tilføj react app + brug den meget vigtige kommando i client mappe:
  npx swagger-typescript-api generate -p http://localhost:5101/swagger/v1/swagger.json -o ./ -n Api.ts

