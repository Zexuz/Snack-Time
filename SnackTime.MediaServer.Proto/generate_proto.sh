#!/usr/bin/env bash
protoc.exe -I ./ --csharp_out ./csharp/ ./proto/**/*.proto --plugin=protoc-gen-grpc=grpc_csharp_plugin.exe --grpc_out=./csharp-grpc/
protoc.exe -I ./ --csharp_out ./csharp/ ./proto/*.proto --plugin=protoc-gen-grpc=grpc_csharp_plugin.exe --grpc_out=./csharp-grpc/