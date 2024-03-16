#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ecom_Shopper.Web/Ecom_Shopper.Web.csproj", "Ecom_Shopper.Web/"]
COPY ["Ecom_Shopper.App/Ecom_Shopper.App.csproj", "Ecom_Shopper.App/"]
COPY ["Ecom_Shopper.Domain/Ecom_Shopper.Domain.csproj", "Ecom_Shopper.Domain/"]
COPY ["Ecom_Shopper.Infra/Ecom_Shopper.Infra.csproj", "Ecom_Shopper.Infra/"]
RUN dotnet restore "./Ecom_Shopper.Web/./Ecom_Shopper.Web.csproj"
COPY . .
WORKDIR "/src/Ecom_Shopper.Web"
RUN dotnet build "./Ecom_Shopper.Web.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ecom_Shopper.Web.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecom_Shopper.Web.dll"]