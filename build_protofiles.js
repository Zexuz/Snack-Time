const util = require('util');
const exec = util.promisify(require('child_process').exec);

async function generateProtoFiles(files) {
    await exec(`pbjs -t static-module -w commonjs -o ${files.js}.js ${files.proto} --no-encode --no-decode --no-convert --no-delimted --no-create --no-verify --es6`);
    await exec(`pbts -o ${files.js}.d.ts ${files.js}.js`);
    await exec(`protoc -I ${files.protoPath} ${files.proto} --csharp_out ${files.csharpPath}`);

    console.log("Updated file successfully!");
}

async function generateCSharpGrpc(protoPath, protoName) {
    let GRPC_TOOLS_VERSION = '1.19.0';
    let NUGET_PATH = `${process.env.USERPROFILE}\\.nuget\\packages`;
    let GRPC_PATH = `${NUGET_PATH}\\Grpc.Tools\\${GRPC_TOOLS_VERSION}`;
    let TOOLS_PATH = `${GRPC_PATH}\\tools\\windows_x64`;
    let INCLUDE_PATH = `${GRPC_PATH}\\build\\native\\include`;

    let cmd = `${TOOLS_PATH}\\protoc.exe -I ${protoPath} -I ${INCLUDE_PATH} ${protoPath}\\${protoName} --csharp_out ${protoPath} --grpc_out=${protoPath} --plugin=protoc-gen-grpc=${TOOLS_PATH}\\grpc_csharp_plugin.exe`;
    await exec(cmd);
}

async function main() {
    const PROTO_FILE_NAME = 'types';

    // const seriesV1Files = {};
    // seriesV1Files.js = `./app/src/logic/api/series/protogen/series`;
    // seriesV1Files.csharpPath = `./SnackTime.Core/Media/Series/proto/gen`;
    // seriesV1Files.protoPath = `./SnackTime.Core/Media/Series/proto`;
    // seriesV1Files.proto = `${seriesV1Files.protoPath}/${PROTO_FILE_NAME}.proto`;
    //
    // const episodesV1Files = {};
    // episodesV1Files.js = `./app/src/logic/api/episodes/protogen/episodes`;
    // episodesV1Files.csharpPath = `./SnackTime.Core/Media/Episodes/proto/gen`;
    // episodesV1Files.protoPath = `./SnackTime.Core/Media/Episodes/proto`;
    // episodesV1Files.proto = `${episodesV1Files.protoPath}/${PROTO_FILE_NAME}.proto`;
    //
    // await generateProtoFiles(seriesV1Files);
    // await generateProtoFiles(episodesV1Files);

    await generateCSharpGrpc("./SnackTime.MediaServer.Proto/","Media.proto")
}


main();