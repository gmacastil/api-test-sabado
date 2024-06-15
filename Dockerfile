FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY out/ ./
RUN apt-get update && apt-get install -y curl
ENTRYPOINT ["dotnet", "api-test-sabado.dll"]