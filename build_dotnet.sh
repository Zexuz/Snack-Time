#!/bin/sh

docker run --rm -i \
-v $(pwd):/app \
-w /app \
3.0.100-preview3-alpine3.9 \
dotnet build -c Release -r win-x64 -o ./webapi ./SnackTime.WebApi/SnackTime.WebApi.csproj 

docker run --rm -i \
-v $(pwd):/app \
-w /app \
3.0.100-preview3-alpine3.9 \
dotnet build -c Release -r win-x64 -o ./media-server ./SnackTime.MediaServer.Runner/SnackTime.MediaServer.Runner.csproj

docker run --rm -i \
-v $(pwd)/app:/app \
-w /app \
node:8.15.0-jessie \
/bin/bash -c "yarn install && yarn run build"