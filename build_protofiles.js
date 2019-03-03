const util = require('util');
const fs = require("fs");
const exec = util.promisify(require('child_process').exec);

async function generateProtoFiles(files) {
    await exec(`pbjs -t static-module -w commonjs -o ${files.js}.js ${files.proto} --no-encode --no-decode --no-convert --no-delimted --no-create --no-verify --es6`);
    await exec(`pbts -o ${files.js}.d.ts ${files.js}.js`);
    await exec(`protoc -I ${files.protoPath} ${files.proto} --csharp_out ${files.csharpPath}`);

    console.log("Updated file successfully!");
}

async function main() {
    const PROTO_FILE_NAME = 'types';

    const seriesV1Files = {};
    seriesV1Files.js = `./app/src/logic/api/series/protogen/series`;
    seriesV1Files.csharpPath = `./SnackTime.Core/Series/proto/gen`;
    seriesV1Files.protoPath = `./SnackTime.Core/Series/proto`;
    seriesV1Files.proto = `${seriesV1Files.protoPath}/${PROTO_FILE_NAME}.proto`;

    const episodesV1Files = {};
    episodesV1Files.js = `./app/src/logic/api/episodes/protogen/episodes`;
    episodesV1Files.csharpPath = `./SnackTime.Core/Episodes/proto/gen`;
    episodesV1Files.protoPath = `./SnackTime.Core/Episodes/proto`;
    episodesV1Files.proto = `${episodesV1Files.protoPath}/${PROTO_FILE_NAME}.proto`;

    await generateProtoFiles(seriesV1Files);
    await generateProtoFiles(episodesV1Files);

}


main();