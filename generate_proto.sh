#!/bin/bash
TS_OUT=./ui/src/_proto

mkdir -p $TS_OUT

if [[ "$GOBIN" == "" ]]; then
  if [[ "$GOPATH" == "" ]]; then
    echo "Required env var GOPATH is not set; aborting with error; see the following documentation which can be invoked via the 'go help gopath' command."
    go help gopath
    exit -1
  fi

  echo "Optional env var GOBIN is not set; using default derived from GOPATH as: \"$GOPATH/bin\""
  export GOBIN="$GOPATH/bin"
fi

PROTOC=`command -v protoc`
if [[ "$PROTOC" == "" ]]; then
  echo "Required "protoc" to be installed. Please visit https://github.com/protocolbuffers/protobuf/releases (3.5.0 suggested)."
  exit -1
fi

# Install protoc-gen-go from the vendored protobu
echo "Compiling protobuf definitions"
protoc \
  --plugin=protoc-gen-ts=./ui/node_modules/.bin/protoc-gen-ts \
  --plugin=protoc-gen-go=${GOBIN}/protoc-gen-go \
  -I ./echo_service \
  --js_out=import_style=commonjs,binary:$TS_OUT \
  --ts_out=service=true:$TS_OUT \
  --go_out=plugins=grpc:. \
  ./echo_service/echo_service.proto