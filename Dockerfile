FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app
COPY . .
WORKDIR /app/src
RUN dotnet build "PillarTechPencilKata.sln" -c "Release" -o /app/build
ENTRYPOINT ["dotnet", "test", "/app/build/PencilKataTests.dll"]