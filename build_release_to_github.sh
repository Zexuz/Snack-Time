#!/bin/sh
curl -Lo warp-packer https://github.com/dgiagio/warp/releases/download/v0.3.0/linux-x64.warp-packer
chmod +x warp-packer

./warp-packer --arch windows-x64 --input_dir ./media-server --exec SnackTime.MediaServer.Runner.exe --output media-server.exe

FILE="media-server.exe"

LATEST_GIT_RELEASE_ID=$(curl https://api.github.com/repos/zexuz/Snack-Time/releases/latest 2>/dev/null | jq -r '.id')

curl -H "Authorization: token bac496186582ab605c2e16c44d14dfd4287f469d" -H "Content-Type: application/octet-stream" --data-binary @"media-server.exe" "https://uploads.github.com/repos/Zexuz/Snack-Time/releases/$LATEST_GIT_RELEASE_ID/assets?name=Test.exe"

read

