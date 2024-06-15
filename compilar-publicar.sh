dotnet restore
dotnet build
dotnet publish -o out
docker build . -t api-test-sabado:7
docker tag api-test-sabado:7 mauron/api-test-sabado:7
docker push mauron/api-test-sabado:7