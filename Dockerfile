
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["ToDoApi.API/ToDoApi.API.csproj", "ToDoApi.API/"]
COPY ["ToDoApi.Application/ToDoApi.Application.csproj", "ToDoApi.Application/"]
COPY ["ToDoApi.Domain/ToDoApi.Domain.csproj", "ToDoApi.Domain/"]
COPY ["ToDoApi.Infrastructure/ToDoApi.Infrastructure.csproj", "ToDoApi.Infrastructure/"]
COPY ["ToDoApi.Core/ToDoApi.Core.csproj", "ToDoApi.Core/"]
RUN dotnet restore "ToDoApi.API/ToDoApi.API.csproj"

COPY . .
WORKDIR "/src/YourProject.API"
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "ToDoApi.API.dll"]