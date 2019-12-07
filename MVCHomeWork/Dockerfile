FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MVCHomeWork/MVCHomeWork.csproj", "MVCHomeWork/"]
RUN dotnet restore "MVCHomeWork/MVCHomeWork.csproj"
COPY . .
WORKDIR "/src/MVCHomeWork"
RUN dotnet build "MVCHomeWork.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MVCHomeWork.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MVCHomeWork.dll"]