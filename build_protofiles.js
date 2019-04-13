const glob = require("glob");
const util = require('util');
const exec = util.promisify(require('child_process').exec);

async function generateProtoFiles(outputFile, fileList) {
    await exec(`pbjs -t static-module -w commonjs -o ${outputFile}.js ${fileList.join(" ")} --no-encode --no-decode --no-convert --no-delimted --no-create --no-verify --es6`);
    await exec(`pbts -o ${outputFile}.d.ts ${outputFile}.js`);

    console.log("Updated file successfully!");
}

// async function generateCSharpGrpc(protoPath, protoName) {
//     let GRPC_TOOLS_VERSION = '1.19.0';
//     let NUGET_PATH = `${process.env.USERPROFILE}\\.nuget\\packages`;
//     let GRPC_PATH = `${NUGET_PATH}\\Grpc.Tools\\${GRPC_TOOLS_VERSION}`;
//     let TOOLS_PATH = `${GRPC_PATH}\\tools\\windows_x64`;
//     let INCLUDE_PATH = `${GRPC_PATH}\\build\\native\\include`;
//
//     let cmd = `${TOOLS_PATH}\\protoc.exe -I ${protoPath} -I ${INCLUDE_PATH} ${protoPath}\\${protoName} --csharp_out ${protoPath} --grpc_out=${protoPath} --plugin=protoc-gen-grpc=${TOOLS_PATH}\\grpc_csharp_plugin.exe`;
//     await exec(cmd);
// }

async function main() {
    let outputPath = `./app/src/logic/api/protogen/types`;
    let basePath = `./SnackTime.MediaServer.Proto/proto`;

    glob(`${basePath}/**/*.proto`, async function (er, files) {
        await generateProtoFiles(outputPath, files);
    });
}

main();