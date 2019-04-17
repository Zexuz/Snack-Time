#!/bin/sh
if [[ "$(uname)" == "Darwin" ]]; then
    CURRENT_PATH=$(pwd)
elif [[ "$(expr substr $(uname -s) 1 5)" == "Linux" ]]; then
    CURRENT_PATH=$(pwd)
elif [[ "$(expr substr $(uname -s) 1 10)" == "MINGW32_NT" ]]; then
    CURRENT_PATH=$(cmd //c cd)
elif [[ "$(expr substr $(uname -s) 1 10)" == "MINGW64_NT" ]]; then
    CURRENT_PATH=$(cmd //c cd)
fi

MSYS_NO_PATHCONV=1 docker run --rm -i \
-v ${CURRENT_PATH}:/app \
-w /app \
mcr.microsoft.com/dotnet/core/sdk:3.0.100-preview3-alpine3.9 \
dotnet build -c Release -r win-x64 -o ./webapi ./SnackTime.WebApi/SnackTime.WebApi.csproj 

MSYS_NO_PATHCONV=1 docker run --rm -i \
-v ${CURRENT_PATH}:/app \
-w /app \
mcr.microsoft.com/dotnet/core/sdk:3.0.100-preview3-alpine3.9 \
dotnet publish -c Release -r win-x64 -o ./media-server ./SnackTime.MediaServer.Runner/SnackTime.MediaServer.Runner.csproj

