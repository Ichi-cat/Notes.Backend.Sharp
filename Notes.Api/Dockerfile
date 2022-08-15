#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Notes.Api/Notes.Api.csproj", "Notes.Api/"]
COPY ["Notes.Persistence/Notes.Persistence.csproj", "Notes.Persistence/"]
COPY ["Notes.Application/Notes.Application.csproj", "Notes.Application/"]
COPY ["Notes.Domain/Notes.Domain.csproj", "Notes.Domain/"]
RUN dotnet restore "Notes.Api/Notes.Api.csproj"
COPY . .
WORKDIR "/src/Notes.Api"
RUN dotnet build "Notes.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notes.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notes.Api.dll"]