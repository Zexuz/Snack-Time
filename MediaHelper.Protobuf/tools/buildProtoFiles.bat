
set PLUGIN=%UserProfile%\.nuget\packages\Grpc.Tools\1.13.1\tools\windows_x64\grpc_csharp_plugin.exe


cd ../raw
..\tools\protoc.exe  --csharp_out=../generated .\MiscModels.proto
..\tools\protoc.exe  --csharp_out=../generated .\MediaPlayerModels.proto
..\tools\protoc.exe  --csharp_out=../generated .\MediaPlayerService.proto --grpc_out ../generated  --plugin=protoc-gen-grpc=%PLUGIN%
pause
exit