dotnet restore
dotnet build
dotnet publish -o out
docker build . -t api-test-sabado:2
docker tag api-test-sabado:2 REGISTRY/api-test-sabado:2
docker push REGISTRY/api-test-sabado:2