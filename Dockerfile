FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine as build
WORKDIR /app

# copy csproj and restore
COPY app/*.csproj ./aspnetapp/
RUN cd ./aspnetapp/ && dotnet restore 

# copy all files and build
COPY app/. ./aspnetapp/
WORKDIR /app/aspnetapp
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine as runtime
WORKDIR /app
COPY --from=build /app/aspnetapp/out ./
ENTRYPOINT [ "dotnet", "app.dll" ]