#!/bin/sh

docker run --rm -i \
-v $(pwd)/app:/app \
-w /app \
node:8.15.0-jessie \
/bin/bash -c "yarn install && yarn run build"