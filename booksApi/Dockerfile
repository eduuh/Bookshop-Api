FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["booksApi/booksApi.csproj", "booksApi/"]
RUN dotnet restore "booksApi/booksApi.csproj"
COPY . .
WORKDIR "/src/booksApi"
RUN dotnet build "booksApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "booksApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "booksApi.dll"]
