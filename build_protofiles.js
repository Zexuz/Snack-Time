const glob = require("glob");
const util = require('util');
const exec = util.promisify(require('child_process').exec);

async function generateProtoFiles(outputFile, fileList) {
    await exec(`pbjs -t static-module -w commonjs -o ${outputFile}.js ${fileList.join(" ")} --no-encode --no-decode --no-convert --no-delimted --no-create --no-verify --es6`);
    await exec(`pbts -o ${outputFile}.d.ts ${outputFile}.js`);

    console.log("Updated file successfully!");
}

async function main() {
    let outputPath = `./app/src/logic/api/protogen/types`;
    let basePath = `./SnackTime.MediaServer.Proto/proto`;

    glob(`${basePath}/**/*.proto`, async function (er, files) {
        await generateProtoFiles(outputPath, files);
    });
}

main();