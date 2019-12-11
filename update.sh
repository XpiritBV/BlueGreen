dotnet build -c Release
dotnet publish -o "./bin/Release/netcoreapp3.0/publish"

docker build -f Dockerfile.blue -t bluegreen:blue -t xpiritbv/bluegreen:blue .
docker build -f Dockerfile.green -t bluegreen:green -t xpiritbv/bluegreen:green .
docker build -f Dockerfile.buggy -t bluegreen:buggy -t xpiritbv/bluegreen:buggy .

docker push xpiritbv/bluegreen:blue
docker push xpiritbv/bluegreen:green
docker push xpiritbv/bluegreen:buggy