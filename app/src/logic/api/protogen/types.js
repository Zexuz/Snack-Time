/*eslint-disable block-scoped-var, id-length, no-control-regex, no-magic-numbers, no-prototype-builtins, no-redeclare, no-shadow, no-var, sort-vars*/
import * as $protobuf from "protobufjs/minimal";

// Common aliases
const $util = $protobuf.util;

// Exported root namespace
const $root = $protobuf.roots["default"] || ($protobuf.roots["default"] = {});

export const snacktime = $root.snacktime = (() => {

    /**
     * Namespace snacktime.
     * @exports snacktime
     * @namespace
     */
    const snacktime = {};

    snacktime.episode = (function() {

        /**
         * Namespace episode.
         * @memberof snacktime
         * @namespace
         */
        const episode = {};

        episode.service = (function() {

            /**
             * Namespace service.
             * @memberof snacktime.episode
             * @namespace
             */
            const service = {};

            service.GetByIdRequest = (function() {

                /**
                 * Properties of a GetByIdRequest.
                 * @memberof snacktime.episode.service
                 * @interface IGetByIdRequest
                 * @property {number|null} [id] GetByIdRequest id
                 */

                /**
                 * Constructs a new GetByIdRequest.
                 * @memberof snacktime.episode.service
                 * @classdesc Represents a GetByIdRequest.
                 * @implements IGetByIdRequest
                 * @constructor
                 * @param {snacktime.episode.service.IGetByIdRequest=} [properties] Properties to set
                 */
                function GetByIdRequest(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * GetByIdRequest id.
                 * @member {number} id
                 * @memberof snacktime.episode.service.GetByIdRequest
                 * @instance
                 */
                GetByIdRequest.prototype.id = 0;

                return GetByIdRequest;
            })();

            service.GetByIdResponse = (function() {

                /**
                 * Properties of a GetByIdResponse.
                 * @memberof snacktime.episode.service
                 * @interface IGetByIdResponse
                 * @property {snacktime.media.IEpisode|null} [episode] GetByIdResponse episode
                 */

                /**
                 * Constructs a new GetByIdResponse.
                 * @memberof snacktime.episode.service
                 * @classdesc Represents a GetByIdResponse.
                 * @implements IGetByIdResponse
                 * @constructor
                 * @param {snacktime.episode.service.IGetByIdResponse=} [properties] Properties to set
                 */
                function GetByIdResponse(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * GetByIdResponse episode.
                 * @member {snacktime.media.IEpisode|null|undefined} episode
                 * @memberof snacktime.episode.service.GetByIdResponse
                 * @instance
                 */
                GetByIdResponse.prototype.episode = null;

                return GetByIdResponse;
            })();

            service.GetBySeriesIdRequest = (function() {

                /**
                 * Properties of a GetBySeriesIdRequest.
                 * @memberof snacktime.episode.service
                 * @interface IGetBySeriesIdRequest
                 * @property {number|null} [seriesId] GetBySeriesIdRequest seriesId
                 */

                /**
                 * Constructs a new GetBySeriesIdRequest.
                 * @memberof snacktime.episode.service
                 * @classdesc Represents a GetBySeriesIdRequest.
                 * @implements IGetBySeriesIdRequest
                 * @constructor
                 * @param {snacktime.episode.service.IGetBySeriesIdRequest=} [properties] Properties to set
                 */
                function GetBySeriesIdRequest(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * GetBySeriesIdRequest seriesId.
                 * @member {number} seriesId
                 * @memberof snacktime.episode.service.GetBySeriesIdRequest
                 * @instance
                 */
                GetBySeriesIdRequest.prototype.seriesId = 0;

                return GetBySeriesIdRequest;
            })();

            service.GetBySeriesIdResponse = (function() {

                /**
                 * Properties of a GetBySeriesIdResponse.
                 * @memberof snacktime.episode.service
                 * @interface IGetBySeriesIdResponse
                 * @property {Array.<snacktime.media.IEpisode>|null} [episodes] GetBySeriesIdResponse episodes
                 */

                /**
                 * Constructs a new GetBySeriesIdResponse.
                 * @memberof snacktime.episode.service
                 * @classdesc Represents a GetBySeriesIdResponse.
                 * @implements IGetBySeriesIdResponse
                 * @constructor
                 * @param {snacktime.episode.service.IGetBySeriesIdResponse=} [properties] Properties to set
                 */
                function GetBySeriesIdResponse(properties) {
                    this.episodes = [];
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * GetBySeriesIdResponse episodes.
                 * @member {Array.<snacktime.media.IEpisode>} episodes
                 * @memberof snacktime.episode.service.GetBySeriesIdResponse
                 * @instance
                 */
                GetBySeriesIdResponse.prototype.episodes = $util.emptyArray;

                return GetBySeriesIdResponse;
            })();

            service.Episode = (function() {

                /**
                 * Constructs a new Episode service.
                 * @memberof snacktime.episode.service
                 * @classdesc Represents an Episode
                 * @extends $protobuf.rpc.Service
                 * @constructor
                 * @param {$protobuf.RPCImpl} rpcImpl RPC implementation
                 * @param {boolean} [requestDelimited=false] Whether requests are length-delimited
                 * @param {boolean} [responseDelimited=false] Whether responses are length-delimited
                 */
                function Episode(rpcImpl, requestDelimited, responseDelimited) {
                    $protobuf.rpc.Service.call(this, rpcImpl, requestDelimited, responseDelimited);
                }

                (Episode.prototype = Object.create($protobuf.rpc.Service.prototype)).constructor = Episode;

                /**
                 * Callback as used by {@link snacktime.episode.service.Episode#getBySeriesId}.
                 * @memberof snacktime.episode.service.Episode
                 * @typedef GetBySeriesIdCallback
                 * @type {function}
                 * @param {Error|null} error Error, if any
                 * @param {snacktime.episode.service.GetBySeriesIdResponse} [response] GetBySeriesIdResponse
                 */

                /**
                 * Calls GetBySeriesId.
                 * @function getBySeriesId
                 * @memberof snacktime.episode.service.Episode
                 * @instance
                 * @param {snacktime.episode.service.IGetBySeriesIdRequest} request GetBySeriesIdRequest message or plain object
                 * @param {snacktime.episode.service.Episode.GetBySeriesIdCallback} callback Node-style callback called with the error, if any, and GetBySeriesIdResponse
                 * @returns {undefined}
                 * @variation 1
                 */
                Object.defineProperty(Episode.prototype.getBySeriesId = function getBySeriesId(request, callback) {
                    return this.rpcCall(getBySeriesId, $root.snacktime.episode.service.GetBySeriesIdRequest, $root.snacktime.episode.service.GetBySeriesIdResponse, request, callback);
                }, "name", { value: "GetBySeriesId" });

                /**
                 * Calls GetBySeriesId.
                 * @function getBySeriesId
                 * @memberof snacktime.episode.service.Episode
                 * @instance
                 * @param {snacktime.episode.service.IGetBySeriesIdRequest} request GetBySeriesIdRequest message or plain object
                 * @returns {Promise<snacktime.episode.service.GetBySeriesIdResponse>} Promise
                 * @variation 2
                 */

                /**
                 * Callback as used by {@link snacktime.episode.service.Episode#getById}.
                 * @memberof snacktime.episode.service.Episode
                 * @typedef GetByIdCallback
                 * @type {function}
                 * @param {Error|null} error Error, if any
                 * @param {snacktime.episode.service.GetByIdResponse} [response] GetByIdResponse
                 */

                /**
                 * Calls GetById.
                 * @function getById
                 * @memberof snacktime.episode.service.Episode
                 * @instance
                 * @param {snacktime.episode.service.IGetByIdRequest} request GetByIdRequest message or plain object
                 * @param {snacktime.episode.service.Episode.GetByIdCallback} callback Node-style callback called with the error, if any, and GetByIdResponse
                 * @returns {undefined}
                 * @variation 1
                 */
                Object.defineProperty(Episode.prototype.getById = function getById(request, callback) {
                    return this.rpcCall(getById, $root.snacktime.episode.service.GetByIdRequest, $root.snacktime.episode.service.GetByIdResponse, request, callback);
                }, "name", { value: "GetById" });

                /**
                 * Calls GetById.
                 * @function getById
                 * @memberof snacktime.episode.service.Episode
                 * @instance
                 * @param {snacktime.episode.service.IGetByIdRequest} request GetByIdRequest message or plain object
                 * @returns {Promise<snacktime.episode.service.GetByIdResponse>} Promise
                 * @variation 2
                 */

                return Episode;
            })();

            return service;
        })();

        return episode;
    })();

    snacktime.file = (function() {

        /**
         * Namespace file.
         * @memberof snacktime
         * @namespace
         */
        const file = {};

        file.service = (function() {

            /**
             * Namespace service.
             * @memberof snacktime.file
             * @namespace
             */
            const service = {};

            service.DownloadFileRequest = (function() {

                /**
                 * Properties of a DownloadFileRequest.
                 * @memberof snacktime.file.service
                 * @interface IDownloadFileRequest
                 * @property {string|null} [mediaFileId] DownloadFileRequest mediaFileId
                 */

                /**
                 * Constructs a new DownloadFileRequest.
                 * @memberof snacktime.file.service
                 * @classdesc Represents a DownloadFileRequest.
                 * @implements IDownloadFileRequest
                 * @constructor
                 * @param {snacktime.file.service.IDownloadFileRequest=} [properties] Properties to set
                 */
                function DownloadFileRequest(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * DownloadFileRequest mediaFileId.
                 * @member {string} mediaFileId
                 * @memberof snacktime.file.service.DownloadFileRequest
                 * @instance
                 */
                DownloadFileRequest.prototype.mediaFileId = "";

                return DownloadFileRequest;
            })();

            service.ResponseDownloadFile = (function() {

                /**
                 * Properties of a ResponseDownloadFile.
                 * @memberof snacktime.file.service
                 * @interface IResponseDownloadFile
                 * @property {snacktime.file.service.IStarted|null} [started] ResponseDownloadFile started
                 * @property {snacktime.file.service.IChunk|null} [progress] ResponseDownloadFile progress
                 * @property {snacktime.file.service.IDone|null} [done] ResponseDownloadFile done
                 */

                /**
                 * Constructs a new ResponseDownloadFile.
                 * @memberof snacktime.file.service
                 * @classdesc Represents a ResponseDownloadFile.
                 * @implements IResponseDownloadFile
                 * @constructor
                 * @param {snacktime.file.service.IResponseDownloadFile=} [properties] Properties to set
                 */
                function ResponseDownloadFile(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * ResponseDownloadFile started.
                 * @member {snacktime.file.service.IStarted|null|undefined} started
                 * @memberof snacktime.file.service.ResponseDownloadFile
                 * @instance
                 */
                ResponseDownloadFile.prototype.started = null;

                /**
                 * ResponseDownloadFile progress.
                 * @member {snacktime.file.service.IChunk|null|undefined} progress
                 * @memberof snacktime.file.service.ResponseDownloadFile
                 * @instance
                 */
                ResponseDownloadFile.prototype.progress = null;

                /**
                 * ResponseDownloadFile done.
                 * @member {snacktime.file.service.IDone|null|undefined} done
                 * @memberof snacktime.file.service.ResponseDownloadFile
                 * @instance
                 */
                ResponseDownloadFile.prototype.done = null;

                // OneOf field names bound to virtual getters and setters
                let $oneOfFields;

                /**
                 * ResponseDownloadFile type.
                 * @member {"started"|"progress"|"done"|undefined} type
                 * @memberof snacktime.file.service.ResponseDownloadFile
                 * @instance
                 */
                Object.defineProperty(ResponseDownloadFile.prototype, "type", {
                    get: $util.oneOfGetter($oneOfFields = ["started", "progress", "done"]),
                    set: $util.oneOfSetter($oneOfFields)
                });

                return ResponseDownloadFile;
            })();

            service.Started = (function() {

                /**
                 * Properties of a Started.
                 * @memberof snacktime.file.service
                 * @interface IStarted
                 * @property {number|null} [lenght] Started lenght
                 * @property {number|null} [sizePerChunk] Started sizePerChunk
                 * @property {string|null} [FileName] Started FileName
                 */

                /**
                 * Constructs a new Started.
                 * @memberof snacktime.file.service
                 * @classdesc Represents a Started.
                 * @implements IStarted
                 * @constructor
                 * @param {snacktime.file.service.IStarted=} [properties] Properties to set
                 */
                function Started(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * Started lenght.
                 * @member {number} lenght
                 * @memberof snacktime.file.service.Started
                 * @instance
                 */
                Started.prototype.lenght = 0;

                /**
                 * Started sizePerChunk.
                 * @member {number} sizePerChunk
                 * @memberof snacktime.file.service.Started
                 * @instance
                 */
                Started.prototype.sizePerChunk = 0;

                /**
                 * Started FileName.
                 * @member {string} FileName
                 * @memberof snacktime.file.service.Started
                 * @instance
                 */
                Started.prototype.FileName = "";

                return Started;
            })();

            service.Chunk = (function() {

                /**
                 * Properties of a Chunk.
                 * @memberof snacktime.file.service
                 * @interface IChunk
                 * @property {Uint8Array|null} [Content] Chunk Content
                 */

                /**
                 * Constructs a new Chunk.
                 * @memberof snacktime.file.service
                 * @classdesc Represents a Chunk.
                 * @implements IChunk
                 * @constructor
                 * @param {snacktime.file.service.IChunk=} [properties] Properties to set
                 */
                function Chunk(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * Chunk Content.
                 * @member {Uint8Array} Content
                 * @memberof snacktime.file.service.Chunk
                 * @instance
                 */
                Chunk.prototype.Content = $util.newBuffer([]);

                return Chunk;
            })();

            service.Done = (function() {

                /**
                 * Properties of a Done.
                 * @memberof snacktime.file.service
                 * @interface IDone
                 * @property {string|null} [Hash] Done Hash
                 */

                /**
                 * Constructs a new Done.
                 * @memberof snacktime.file.service
                 * @classdesc Represents a Done.
                 * @implements IDone
                 * @constructor
                 * @param {snacktime.file.service.IDone=} [properties] Properties to set
                 */
                function Done(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * Done Hash.
                 * @member {string} Hash
                 * @memberof snacktime.file.service.Done
                 * @instance
                 */
                Done.prototype.Hash = "";

                return Done;
            })();

            service.File = (function() {

                /**
                 * Constructs a new File service.
                 * @memberof snacktime.file.service
                 * @classdesc Represents a File
                 * @extends $protobuf.rpc.Service
                 * @constructor
                 * @param {$protobuf.RPCImpl} rpcImpl RPC implementation
                 * @param {boolean} [requestDelimited=false] Whether requests are length-delimited
                 * @param {boolean} [responseDelimited=false] Whether responses are length-delimited
                 */
                function File(rpcImpl, requestDelimited, responseDelimited) {
                    $protobuf.rpc.Service.call(this, rpcImpl, requestDelimited, responseDelimited);
                }

                (File.prototype = Object.create($protobuf.rpc.Service.prototype)).constructor = File;

                /**
                 * Callback as used by {@link snacktime.file.service.File#download}.
                 * @memberof snacktime.file.service.File
                 * @typedef DownloadCallback
                 * @type {function}
                 * @param {Error|null} error Error, if any
                 * @param {snacktime.file.service.ResponseDownloadFile} [response] ResponseDownloadFile
                 */

                /**
                 * Calls Download.
                 * @function download
                 * @memberof snacktime.file.service.File
                 * @instance
                 * @param {snacktime.file.service.IDownloadFileRequest} request DownloadFileRequest message or plain object
                 * @param {snacktime.file.service.File.DownloadCallback} callback Node-style callback called with the error, if any, and ResponseDownloadFile
                 * @returns {undefined}
                 * @variation 1
                 */
                Object.defineProperty(File.prototype.download = function download(request, callback) {
                    return this.rpcCall(download, $root.snacktime.file.service.DownloadFileRequest, $root.snacktime.file.service.ResponseDownloadFile, request, callback);
                }, "name", { value: "Download" });

                /**
                 * Calls Download.
                 * @function download
                 * @memberof snacktime.file.service.File
                 * @instance
                 * @param {snacktime.file.service.IDownloadFileRequest} request DownloadFileRequest message or plain object
                 * @returns {Promise<snacktime.file.service.ResponseDownloadFile>} Promise
                 * @variation 2
                 */

                return File;
            })();

            return service;
        })();

        return file;
    })();

    snacktime.media = (function() {

        /**
         * Namespace media.
         * @memberof snacktime
         * @namespace
         */
        const media = {};

        media.Series = (function() {

            /**
             * Properties of a Series.
             * @memberof snacktime.media
             * @interface ISeries
             * @property {number|null} [id] Series id
             * @property {string|null} [title] Series title
             * @property {snacktime.media.IImagesUrl|null} [imagesUrl] Series imagesUrl
             * @property {string|null} [overview] Series overview
             * @property {boolean|null} [monitored] Series monitored
             */

            /**
             * Constructs a new Series.
             * @memberof snacktime.media
             * @classdesc Represents a Series.
             * @implements ISeries
             * @constructor
             * @param {snacktime.media.ISeries=} [properties] Properties to set
             */
            function Series(properties) {
                if (properties)
                    for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                        if (properties[keys[i]] != null)
                            this[keys[i]] = properties[keys[i]];
            }

            /**
             * Series id.
             * @member {number} id
             * @memberof snacktime.media.Series
             * @instance
             */
            Series.prototype.id = 0;

            /**
             * Series title.
             * @member {string} title
             * @memberof snacktime.media.Series
             * @instance
             */
            Series.prototype.title = "";

            /**
             * Series imagesUrl.
             * @member {snacktime.media.IImagesUrl|null|undefined} imagesUrl
             * @memberof snacktime.media.Series
             * @instance
             */
            Series.prototype.imagesUrl = null;

            /**
             * Series overview.
             * @member {string} overview
             * @memberof snacktime.media.Series
             * @instance
             */
            Series.prototype.overview = "";

            /**
             * Series monitored.
             * @member {boolean} monitored
             * @memberof snacktime.media.Series
             * @instance
             */
            Series.prototype.monitored = false;

            return Series;
        })();

        media.ImagesUrl = (function() {

            /**
             * Properties of an ImagesUrl.
             * @memberof snacktime.media
             * @interface IImagesUrl
             * @property {string|null} [banner] ImagesUrl banner
             * @property {string|null} [fanart] ImagesUrl fanart
             * @property {string|null} [poster] ImagesUrl poster
             */

            /**
             * Constructs a new ImagesUrl.
             * @memberof snacktime.media
             * @classdesc Represents an ImagesUrl.
             * @implements IImagesUrl
             * @constructor
             * @param {snacktime.media.IImagesUrl=} [properties] Properties to set
             */
            function ImagesUrl(properties) {
                if (properties)
                    for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                        if (properties[keys[i]] != null)
                            this[keys[i]] = properties[keys[i]];
            }

            /**
             * ImagesUrl banner.
             * @member {string} banner
             * @memberof snacktime.media.ImagesUrl
             * @instance
             */
            ImagesUrl.prototype.banner = "";

            /**
             * ImagesUrl fanart.
             * @member {string} fanart
             * @memberof snacktime.media.ImagesUrl
             * @instance
             */
            ImagesUrl.prototype.fanart = "";

            /**
             * ImagesUrl poster.
             * @member {string} poster
             * @memberof snacktime.media.ImagesUrl
             * @instance
             */
            ImagesUrl.prototype.poster = "";

            return ImagesUrl;
        })();

        media.Episode = (function() {

            /**
             * Properties of an Episode.
             * @memberof snacktime.media
             * @interface IEpisode
             * @property {number|null} [seriesId] Episode seriesId
             * @property {number|null} [episodeFileId] Episode episodeFileId
             * @property {number|null} [seasonNumber] Episode seasonNumber
             * @property {number|null} [episideNumber] Episode episideNumber
             * @property {string|null} [title] Episode title
             * @property {string|null} [overview] Episode overview
             * @property {string|null} [playableId] Episode playableId
             * @property {snacktime.storage.IProgress|null} [progress] Episode progress
             */

            /**
             * Constructs a new Episode.
             * @memberof snacktime.media
             * @classdesc Represents an Episode.
             * @implements IEpisode
             * @constructor
             * @param {snacktime.media.IEpisode=} [properties] Properties to set
             */
            function Episode(properties) {
                if (properties)
                    for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                        if (properties[keys[i]] != null)
                            this[keys[i]] = properties[keys[i]];
            }

            /**
             * Episode seriesId.
             * @member {number} seriesId
             * @memberof snacktime.media.Episode
             * @instance
             */
            Episode.prototype.seriesId = 0;

            /**
             * Episode episodeFileId.
             * @member {number} episodeFileId
             * @memberof snacktime.media.Episode
             * @instance
             */
            Episode.prototype.episodeFileId = 0;

            /**
             * Episode seasonNumber.
             * @member {number} seasonNumber
             * @memberof snacktime.media.Episode
             * @instance
             */
            Episode.prototype.seasonNumber = 0;

            /**
             * Episode episideNumber.
             * @member {number} episideNumber
             * @memberof snacktime.media.Episode
             * @instance
             */
            Episode.prototype.episideNumber = 0;

            /**
             * Episode title.
             * @member {string} title
             * @memberof snacktime.media.Episode
             * @instance
             */
            Episode.prototype.title = "";

            /**
             * Episode overview.
             * @member {string} overview
             * @memberof snacktime.media.Episode
             * @instance
             */
            Episode.prototype.overview = "";

            /**
             * Episode playableId.
             * @member {string} playableId
             * @memberof snacktime.media.Episode
             * @instance
             */
            Episode.prototype.playableId = "";

            /**
             * Episode progress.
             * @member {snacktime.storage.IProgress|null|undefined} progress
             * @memberof snacktime.media.Episode
             * @instance
             */
            Episode.prototype.progress = null;

            return Episode;
        })();

        /**
         * Providers enum.
         * @name snacktime.media.Providers
         * @enum {string}
         * @property {number} Sonarr=0 Sonarr value
         * @property {number} Radarr=1 Radarr value
         */
        media.Providers = (function() {
            const valuesById = {}, values = Object.create(valuesById);
            values[valuesById[0] = "Sonarr"] = 0;
            values[valuesById[1] = "Radarr"] = 1;
            return values;
        })();

        return media;
    })();

    snacktime.series = (function() {

        /**
         * Namespace series.
         * @memberof snacktime
         * @namespace
         */
        const series = {};

        series.service = (function() {

            /**
             * Namespace service.
             * @memberof snacktime.series
             * @namespace
             */
            const service = {};

            service.GetAllRequest = (function() {

                /**
                 * Properties of a GetAllRequest.
                 * @memberof snacktime.series.service
                 * @interface IGetAllRequest
                 */

                /**
                 * Constructs a new GetAllRequest.
                 * @memberof snacktime.series.service
                 * @classdesc Represents a GetAllRequest.
                 * @implements IGetAllRequest
                 * @constructor
                 * @param {snacktime.series.service.IGetAllRequest=} [properties] Properties to set
                 */
                function GetAllRequest(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                return GetAllRequest;
            })();

            service.GetAllResponse = (function() {

                /**
                 * Properties of a GetAllResponse.
                 * @memberof snacktime.series.service
                 * @interface IGetAllResponse
                 * @property {Array.<snacktime.media.ISeries>|null} [series] GetAllResponse series
                 */

                /**
                 * Constructs a new GetAllResponse.
                 * @memberof snacktime.series.service
                 * @classdesc Represents a GetAllResponse.
                 * @implements IGetAllResponse
                 * @constructor
                 * @param {snacktime.series.service.IGetAllResponse=} [properties] Properties to set
                 */
                function GetAllResponse(properties) {
                    this.series = [];
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * GetAllResponse series.
                 * @member {Array.<snacktime.media.ISeries>} series
                 * @memberof snacktime.series.service.GetAllResponse
                 * @instance
                 */
                GetAllResponse.prototype.series = $util.emptyArray;

                return GetAllResponse;
            })();

            service.GetByIdRequest = (function() {

                /**
                 * Properties of a GetByIdRequest.
                 * @memberof snacktime.series.service
                 * @interface IGetByIdRequest
                 * @property {number|null} [id] GetByIdRequest id
                 */

                /**
                 * Constructs a new GetByIdRequest.
                 * @memberof snacktime.series.service
                 * @classdesc Represents a GetByIdRequest.
                 * @implements IGetByIdRequest
                 * @constructor
                 * @param {snacktime.series.service.IGetByIdRequest=} [properties] Properties to set
                 */
                function GetByIdRequest(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * GetByIdRequest id.
                 * @member {number} id
                 * @memberof snacktime.series.service.GetByIdRequest
                 * @instance
                 */
                GetByIdRequest.prototype.id = 0;

                return GetByIdRequest;
            })();

            service.GetByIdResponse = (function() {

                /**
                 * Properties of a GetByIdResponse.
                 * @memberof snacktime.series.service
                 * @interface IGetByIdResponse
                 * @property {snacktime.media.ISeries|null} [series] GetByIdResponse series
                 */

                /**
                 * Constructs a new GetByIdResponse.
                 * @memberof snacktime.series.service
                 * @classdesc Represents a GetByIdResponse.
                 * @implements IGetByIdResponse
                 * @constructor
                 * @param {snacktime.series.service.IGetByIdResponse=} [properties] Properties to set
                 */
                function GetByIdResponse(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * GetByIdResponse series.
                 * @member {snacktime.media.ISeries|null|undefined} series
                 * @memberof snacktime.series.service.GetByIdResponse
                 * @instance
                 */
                GetByIdResponse.prototype.series = null;

                return GetByIdResponse;
            })();

            service.GetLastDownloadedRequest = (function() {

                /**
                 * Properties of a GetLastDownloadedRequest.
                 * @memberof snacktime.series.service
                 * @interface IGetLastDownloadedRequest
                 */

                /**
                 * Constructs a new GetLastDownloadedRequest.
                 * @memberof snacktime.series.service
                 * @classdesc Represents a GetLastDownloadedRequest.
                 * @implements IGetLastDownloadedRequest
                 * @constructor
                 * @param {snacktime.series.service.IGetLastDownloadedRequest=} [properties] Properties to set
                 */
                function GetLastDownloadedRequest(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                return GetLastDownloadedRequest;
            })();

            service.GetLastDownloadedResponse = (function() {

                /**
                 * Properties of a GetLastDownloadedResponse.
                 * @memberof snacktime.series.service
                 * @interface IGetLastDownloadedResponse
                 * @property {Array.<snacktime.media.ISeries>|null} [series] GetLastDownloadedResponse series
                 */

                /**
                 * Constructs a new GetLastDownloadedResponse.
                 * @memberof snacktime.series.service
                 * @classdesc Represents a GetLastDownloadedResponse.
                 * @implements IGetLastDownloadedResponse
                 * @constructor
                 * @param {snacktime.series.service.IGetLastDownloadedResponse=} [properties] Properties to set
                 */
                function GetLastDownloadedResponse(properties) {
                    this.series = [];
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * GetLastDownloadedResponse series.
                 * @member {Array.<snacktime.media.ISeries>} series
                 * @memberof snacktime.series.service.GetLastDownloadedResponse
                 * @instance
                 */
                GetLastDownloadedResponse.prototype.series = $util.emptyArray;

                return GetLastDownloadedResponse;
            })();

            service.Series = (function() {

                /**
                 * Constructs a new Series service.
                 * @memberof snacktime.series.service
                 * @classdesc Represents a Series
                 * @extends $protobuf.rpc.Service
                 * @constructor
                 * @param {$protobuf.RPCImpl} rpcImpl RPC implementation
                 * @param {boolean} [requestDelimited=false] Whether requests are length-delimited
                 * @param {boolean} [responseDelimited=false] Whether responses are length-delimited
                 */
                function Series(rpcImpl, requestDelimited, responseDelimited) {
                    $protobuf.rpc.Service.call(this, rpcImpl, requestDelimited, responseDelimited);
                }

                (Series.prototype = Object.create($protobuf.rpc.Service.prototype)).constructor = Series;

                /**
                 * Callback as used by {@link snacktime.series.service.Series#getLastDownloaded}.
                 * @memberof snacktime.series.service.Series
                 * @typedef GetLastDownloadedCallback
                 * @type {function}
                 * @param {Error|null} error Error, if any
                 * @param {snacktime.series.service.GetLastDownloadedResponse} [response] GetLastDownloadedResponse
                 */

                /**
                 * Calls GetLastDownloaded.
                 * @function getLastDownloaded
                 * @memberof snacktime.series.service.Series
                 * @instance
                 * @param {snacktime.series.service.IGetLastDownloadedRequest} request GetLastDownloadedRequest message or plain object
                 * @param {snacktime.series.service.Series.GetLastDownloadedCallback} callback Node-style callback called with the error, if any, and GetLastDownloadedResponse
                 * @returns {undefined}
                 * @variation 1
                 */
                Object.defineProperty(Series.prototype.getLastDownloaded = function getLastDownloaded(request, callback) {
                    return this.rpcCall(getLastDownloaded, $root.snacktime.series.service.GetLastDownloadedRequest, $root.snacktime.series.service.GetLastDownloadedResponse, request, callback);
                }, "name", { value: "GetLastDownloaded" });

                /**
                 * Calls GetLastDownloaded.
                 * @function getLastDownloaded
                 * @memberof snacktime.series.service.Series
                 * @instance
                 * @param {snacktime.series.service.IGetLastDownloadedRequest} request GetLastDownloadedRequest message or plain object
                 * @returns {Promise<snacktime.series.service.GetLastDownloadedResponse>} Promise
                 * @variation 2
                 */

                /**
                 * Callback as used by {@link snacktime.series.service.Series#getAll}.
                 * @memberof snacktime.series.service.Series
                 * @typedef GetAllCallback
                 * @type {function}
                 * @param {Error|null} error Error, if any
                 * @param {snacktime.series.service.GetAllResponse} [response] GetAllResponse
                 */

                /**
                 * Calls GetAll.
                 * @function getAll
                 * @memberof snacktime.series.service.Series
                 * @instance
                 * @param {snacktime.series.service.IGetAllRequest} request GetAllRequest message or plain object
                 * @param {snacktime.series.service.Series.GetAllCallback} callback Node-style callback called with the error, if any, and GetAllResponse
                 * @returns {undefined}
                 * @variation 1
                 */
                Object.defineProperty(Series.prototype.getAll = function getAll(request, callback) {
                    return this.rpcCall(getAll, $root.snacktime.series.service.GetAllRequest, $root.snacktime.series.service.GetAllResponse, request, callback);
                }, "name", { value: "GetAll" });

                /**
                 * Calls GetAll.
                 * @function getAll
                 * @memberof snacktime.series.service.Series
                 * @instance
                 * @param {snacktime.series.service.IGetAllRequest} request GetAllRequest message or plain object
                 * @returns {Promise<snacktime.series.service.GetAllResponse>} Promise
                 * @variation 2
                 */

                /**
                 * Callback as used by {@link snacktime.series.service.Series#getById}.
                 * @memberof snacktime.series.service.Series
                 * @typedef GetByIdCallback
                 * @type {function}
                 * @param {Error|null} error Error, if any
                 * @param {snacktime.series.service.GetByIdResponse} [response] GetByIdResponse
                 */

                /**
                 * Calls GetById.
                 * @function getById
                 * @memberof snacktime.series.service.Series
                 * @instance
                 * @param {snacktime.series.service.IGetByIdRequest} request GetByIdRequest message or plain object
                 * @param {snacktime.series.service.Series.GetByIdCallback} callback Node-style callback called with the error, if any, and GetByIdResponse
                 * @returns {undefined}
                 * @variation 1
                 */
                Object.defineProperty(Series.prototype.getById = function getById(request, callback) {
                    return this.rpcCall(getById, $root.snacktime.series.service.GetByIdRequest, $root.snacktime.series.service.GetByIdResponse, request, callback);
                }, "name", { value: "GetById" });

                /**
                 * Calls GetById.
                 * @function getById
                 * @memberof snacktime.series.service.Series
                 * @instance
                 * @param {snacktime.series.service.IGetByIdRequest} request GetByIdRequest message or plain object
                 * @returns {Promise<snacktime.series.service.GetByIdResponse>} Promise
                 * @variation 2
                 */

                return Series;
            })();

            return service;
        })();

        series.session = (function() {

            /**
             * Namespace session.
             * @memberof snacktime.series
             * @namespace
             */
            const session = {};

            session.GetAllRequest = (function() {

                /**
                 * Properties of a GetAllRequest.
                 * @memberof snacktime.series.session
                 * @interface IGetAllRequest
                 */

                /**
                 * Constructs a new GetAllRequest.
                 * @memberof snacktime.series.session
                 * @classdesc Represents a GetAllRequest.
                 * @implements IGetAllRequest
                 * @constructor
                 * @param {snacktime.series.session.IGetAllRequest=} [properties] Properties to set
                 */
                function GetAllRequest(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                return GetAllRequest;
            })();

            session.GetAllResponse = (function() {

                /**
                 * Properties of a GetAllResponse.
                 * @memberof snacktime.series.session
                 * @interface IGetAllResponse
                 * @property {Array.<snacktime.storage.ISession>|null} [sessions] GetAllResponse sessions
                 */

                /**
                 * Constructs a new GetAllResponse.
                 * @memberof snacktime.series.session
                 * @classdesc Represents a GetAllResponse.
                 * @implements IGetAllResponse
                 * @constructor
                 * @param {snacktime.series.session.IGetAllResponse=} [properties] Properties to set
                 */
                function GetAllResponse(properties) {
                    this.sessions = [];
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * GetAllResponse sessions.
                 * @member {Array.<snacktime.storage.ISession>} sessions
                 * @memberof snacktime.series.session.GetAllResponse
                 * @instance
                 */
                GetAllResponse.prototype.sessions = $util.emptyArray;

                return GetAllResponse;
            })();

            session.Session = (function() {

                /**
                 * Constructs a new Session service.
                 * @memberof snacktime.series.session
                 * @classdesc Represents a Session
                 * @extends $protobuf.rpc.Service
                 * @constructor
                 * @param {$protobuf.RPCImpl} rpcImpl RPC implementation
                 * @param {boolean} [requestDelimited=false] Whether requests are length-delimited
                 * @param {boolean} [responseDelimited=false] Whether responses are length-delimited
                 */
                function Session(rpcImpl, requestDelimited, responseDelimited) {
                    $protobuf.rpc.Service.call(this, rpcImpl, requestDelimited, responseDelimited);
                }

                (Session.prototype = Object.create($protobuf.rpc.Service.prototype)).constructor = Session;

                /**
                 * Callback as used by {@link snacktime.series.session.Session#getAll}.
                 * @memberof snacktime.series.session.Session
                 * @typedef GetAllCallback
                 * @type {function}
                 * @param {Error|null} error Error, if any
                 * @param {snacktime.series.session.GetAllResponse} [response] GetAllResponse
                 */

                /**
                 * Calls GetAll.
                 * @function getAll
                 * @memberof snacktime.series.session.Session
                 * @instance
                 * @param {snacktime.series.session.IGetAllRequest} request GetAllRequest message or plain object
                 * @param {snacktime.series.session.Session.GetAllCallback} callback Node-style callback called with the error, if any, and GetAllResponse
                 * @returns {undefined}
                 * @variation 1
                 */
                Object.defineProperty(Session.prototype.getAll = function getAll(request, callback) {
                    return this.rpcCall(getAll, $root.snacktime.series.session.GetAllRequest, $root.snacktime.series.session.GetAllResponse, request, callback);
                }, "name", { value: "GetAll" });

                /**
                 * Calls GetAll.
                 * @function getAll
                 * @memberof snacktime.series.session.Session
                 * @instance
                 * @param {snacktime.series.session.IGetAllRequest} request GetAllRequest message or plain object
                 * @returns {Promise<snacktime.series.session.GetAllResponse>} Promise
                 * @variation 2
                 */

                /**
                 * Callback as used by {@link snacktime.series.session.Session#upsert}.
                 * @memberof snacktime.series.session.Session
                 * @typedef UpsertCallback
                 * @type {function}
                 * @param {Error|null} error Error, if any
                 * @param {snacktime.series.session.UpsertResponse} [response] UpsertResponse
                 */

                /**
                 * Calls Upsert.
                 * @function upsert
                 * @memberof snacktime.series.session.Session
                 * @instance
                 * @param {snacktime.series.session.IUpsertRequest} request UpsertRequest message or plain object
                 * @param {snacktime.series.session.Session.UpsertCallback} callback Node-style callback called with the error, if any, and UpsertResponse
                 * @returns {undefined}
                 * @variation 1
                 */
                Object.defineProperty(Session.prototype.upsert = function upsert(request, callback) {
                    return this.rpcCall(upsert, $root.snacktime.series.session.UpsertRequest, $root.snacktime.series.session.UpsertResponse, request, callback);
                }, "name", { value: "Upsert" });

                /**
                 * Calls Upsert.
                 * @function upsert
                 * @memberof snacktime.series.session.Session
                 * @instance
                 * @param {snacktime.series.session.IUpsertRequest} request UpsertRequest message or plain object
                 * @returns {Promise<snacktime.series.session.UpsertResponse>} Promise
                 * @variation 2
                 */

                return Session;
            })();

            session.UpsertRequest = (function() {

                /**
                 * Properties of an UpsertRequest.
                 * @memberof snacktime.series.session
                 * @interface IUpsertRequest
                 * @property {snacktime.storage.ISession|null} [session] UpsertRequest session
                 */

                /**
                 * Constructs a new UpsertRequest.
                 * @memberof snacktime.series.session
                 * @classdesc Represents an UpsertRequest.
                 * @implements IUpsertRequest
                 * @constructor
                 * @param {snacktime.series.session.IUpsertRequest=} [properties] Properties to set
                 */
                function UpsertRequest(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * UpsertRequest session.
                 * @member {snacktime.storage.ISession|null|undefined} session
                 * @memberof snacktime.series.session.UpsertRequest
                 * @instance
                 */
                UpsertRequest.prototype.session = null;

                return UpsertRequest;
            })();

            session.UpsertResponse = (function() {

                /**
                 * Properties of an UpsertResponse.
                 * @memberof snacktime.series.session
                 * @interface IUpsertResponse
                 */

                /**
                 * Constructs a new UpsertResponse.
                 * @memberof snacktime.series.session
                 * @classdesc Represents an UpsertResponse.
                 * @implements IUpsertResponse
                 * @constructor
                 * @param {snacktime.series.session.IUpsertResponse=} [properties] Properties to set
                 */
                function UpsertResponse(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                return UpsertResponse;
            })();

            return session;
        })();

        return series;
    })();

    snacktime.app = (function() {

        /**
         * Namespace app.
         * @memberof snacktime
         * @namespace
         */
        const app = {};

        app.settings = (function() {

            /**
             * Namespace settings.
             * @memberof snacktime.app
             * @namespace
             */
            const settings = {};

            settings.Settings = (function() {

                /**
                 * Properties of a Settings.
                 * @memberof snacktime.app.settings
                 * @interface ISettings
                 * @property {snacktime.app.settings.ILocalSystem|null} [system] Settings system
                 * @property {snacktime.app.settings.IRemote|null} [remote] Settings remote
                 */

                /**
                 * Constructs a new Settings.
                 * @memberof snacktime.app.settings
                 * @classdesc Represents a Settings.
                 * @implements ISettings
                 * @constructor
                 * @param {snacktime.app.settings.ISettings=} [properties] Properties to set
                 */
                function Settings(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * Settings system.
                 * @member {snacktime.app.settings.ILocalSystem|null|undefined} system
                 * @memberof snacktime.app.settings.Settings
                 * @instance
                 */
                Settings.prototype.system = null;

                /**
                 * Settings remote.
                 * @member {snacktime.app.settings.IRemote|null|undefined} remote
                 * @memberof snacktime.app.settings.Settings
                 * @instance
                 */
                Settings.prototype.remote = null;

                return Settings;
            })();

            settings.LocalSystem = (function() {

                /**
                 * Properties of a LocalSystem.
                 * @memberof snacktime.app.settings
                 * @interface ILocalSystem
                 * @property {string|null} [fileDir] LocalSystem fileDir
                 * @property {string|null} [tempFileDir] LocalSystem tempFileDir
                 * @property {string|null} [mpvPath] LocalSystem mpvPath
                 * @property {string|null} [svpPath] LocalSystem svpPath
                 */

                /**
                 * Constructs a new LocalSystem.
                 * @memberof snacktime.app.settings
                 * @classdesc Represents a LocalSystem.
                 * @implements ILocalSystem
                 * @constructor
                 * @param {snacktime.app.settings.ILocalSystem=} [properties] Properties to set
                 */
                function LocalSystem(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * LocalSystem fileDir.
                 * @member {string} fileDir
                 * @memberof snacktime.app.settings.LocalSystem
                 * @instance
                 */
                LocalSystem.prototype.fileDir = "";

                /**
                 * LocalSystem tempFileDir.
                 * @member {string} tempFileDir
                 * @memberof snacktime.app.settings.LocalSystem
                 * @instance
                 */
                LocalSystem.prototype.tempFileDir = "";

                /**
                 * LocalSystem mpvPath.
                 * @member {string} mpvPath
                 * @memberof snacktime.app.settings.LocalSystem
                 * @instance
                 */
                LocalSystem.prototype.mpvPath = "";

                /**
                 * LocalSystem svpPath.
                 * @member {string} svpPath
                 * @memberof snacktime.app.settings.LocalSystem
                 * @instance
                 */
                LocalSystem.prototype.svpPath = "";

                return LocalSystem;
            })();

            settings.Remote = (function() {

                /**
                 * Properties of a Remote.
                 * @memberof snacktime.app.settings
                 * @interface IRemote
                 * @property {string|null} [mediaServerAddress] Remote mediaServerAddress
                 * @property {boolean|null} [isOnline] Remote isOnline
                 */

                /**
                 * Constructs a new Remote.
                 * @memberof snacktime.app.settings
                 * @classdesc Represents a Remote.
                 * @implements IRemote
                 * @constructor
                 * @param {snacktime.app.settings.IRemote=} [properties] Properties to set
                 */
                function Remote(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                /**
                 * Remote mediaServerAddress.
                 * @member {string} mediaServerAddress
                 * @memberof snacktime.app.settings.Remote
                 * @instance
                 */
                Remote.prototype.mediaServerAddress = "";

                /**
                 * Remote isOnline.
                 * @member {boolean} isOnline
                 * @memberof snacktime.app.settings.Remote
                 * @instance
                 */
                Remote.prototype.isOnline = false;

                return Remote;
            })();

            return settings;
        })();

        return app;
    })();

    snacktime.status = (function() {

        /**
         * Namespace status.
         * @memberof snacktime
         * @namespace
         */
        const status = {};

        status.service = (function() {

            /**
             * Namespace service.
             * @memberof snacktime.status
             * @namespace
             */
            const service = {};

            service.PingRequest = (function() {

                /**
                 * Properties of a PingRequest.
                 * @memberof snacktime.status.service
                 * @interface IPingRequest
                 */

                /**
                 * Constructs a new PingRequest.
                 * @memberof snacktime.status.service
                 * @classdesc Represents a PingRequest.
                 * @implements IPingRequest
                 * @constructor
                 * @param {snacktime.status.service.IPingRequest=} [properties] Properties to set
                 */
                function PingRequest(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                return PingRequest;
            })();

            service.PingResponse = (function() {

                /**
                 * Properties of a PingResponse.
                 * @memberof snacktime.status.service
                 * @interface IPingResponse
                 */

                /**
                 * Constructs a new PingResponse.
                 * @memberof snacktime.status.service
                 * @classdesc Represents a PingResponse.
                 * @implements IPingResponse
                 * @constructor
                 * @param {snacktime.status.service.IPingResponse=} [properties] Properties to set
                 */
                function PingResponse(properties) {
                    if (properties)
                        for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                            if (properties[keys[i]] != null)
                                this[keys[i]] = properties[keys[i]];
                }

                return PingResponse;
            })();

            service.Status = (function() {

                /**
                 * Constructs a new Status service.
                 * @memberof snacktime.status.service
                 * @classdesc Represents a Status
                 * @extends $protobuf.rpc.Service
                 * @constructor
                 * @param {$protobuf.RPCImpl} rpcImpl RPC implementation
                 * @param {boolean} [requestDelimited=false] Whether requests are length-delimited
                 * @param {boolean} [responseDelimited=false] Whether responses are length-delimited
                 */
                function Status(rpcImpl, requestDelimited, responseDelimited) {
                    $protobuf.rpc.Service.call(this, rpcImpl, requestDelimited, responseDelimited);
                }

                (Status.prototype = Object.create($protobuf.rpc.Service.prototype)).constructor = Status;

                /**
                 * Callback as used by {@link snacktime.status.service.Status#ping}.
                 * @memberof snacktime.status.service.Status
                 * @typedef PingCallback
                 * @type {function}
                 * @param {Error|null} error Error, if any
                 * @param {snacktime.status.service.PingResponse} [response] PingResponse
                 */

                /**
                 * Calls Ping.
                 * @function ping
                 * @memberof snacktime.status.service.Status
                 * @instance
                 * @param {snacktime.status.service.IPingRequest} request PingRequest message or plain object
                 * @param {snacktime.status.service.Status.PingCallback} callback Node-style callback called with the error, if any, and PingResponse
                 * @returns {undefined}
                 * @variation 1
                 */
                Object.defineProperty(Status.prototype.ping = function ping(request, callback) {
                    return this.rpcCall(ping, $root.snacktime.status.service.PingRequest, $root.snacktime.status.service.PingResponse, request, callback);
                }, "name", { value: "Ping" });

                /**
                 * Calls Ping.
                 * @function ping
                 * @memberof snacktime.status.service.Status
                 * @instance
                 * @param {snacktime.status.service.IPingRequest} request PingRequest message or plain object
                 * @returns {Promise<snacktime.status.service.PingResponse>} Promise
                 * @variation 2
                 */

                return Status;
            })();

            return service;
        })();

        return status;
    })();

    snacktime.storage = (function() {

        /**
         * Namespace storage.
         * @memberof snacktime
         * @namespace
         */
        const storage = {};

        storage.MediaFile = (function() {

            /**
             * Properties of a MediaFile.
             * @memberof snacktime.storage
             * @interface IMediaFile
             * @property {string|null} [fileName] MediaFile fileName
             * @property {string|null} [mediaName] MediaFile mediaName
             * @property {string|null} [downloadedUTC] MediaFile downloadedUTC
             * @property {string|null} [lastWatchedUTC] MediaFile lastWatchedUTC
             */

            /**
             * Constructs a new MediaFile.
             * @memberof snacktime.storage
             * @classdesc Represents a MediaFile.
             * @implements IMediaFile
             * @constructor
             * @param {snacktime.storage.IMediaFile=} [properties] Properties to set
             */
            function MediaFile(properties) {
                if (properties)
                    for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                        if (properties[keys[i]] != null)
                            this[keys[i]] = properties[keys[i]];
            }

            /**
             * MediaFile fileName.
             * @member {string} fileName
             * @memberof snacktime.storage.MediaFile
             * @instance
             */
            MediaFile.prototype.fileName = "";

            /**
             * MediaFile mediaName.
             * @member {string} mediaName
             * @memberof snacktime.storage.MediaFile
             * @instance
             */
            MediaFile.prototype.mediaName = "";

            /**
             * MediaFile downloadedUTC.
             * @member {string} downloadedUTC
             * @memberof snacktime.storage.MediaFile
             * @instance
             */
            MediaFile.prototype.downloadedUTC = "";

            /**
             * MediaFile lastWatchedUTC.
             * @member {string} lastWatchedUTC
             * @memberof snacktime.storage.MediaFile
             * @instance
             */
            MediaFile.prototype.lastWatchedUTC = "";

            return MediaFile;
        })();

        storage.Session = (function() {

            /**
             * Properties of a Session.
             * @memberof snacktime.storage
             * @interface ISession
             * @property {string|null} [id] Session id
             * @property {number|Long|null} [startUTC] Session startUTC
             * @property {number|Long|null} [endUTC] Session endUTC
             * @property {string|null} [mediaId] Session mediaId
             * @property {snacktime.storage.IDuration|null} [duration] Session duration
             * @property {number|null} [mediaLenghtInSec] Session mediaLenghtInSec
             * @property {string|null} [fromDevice] Session fromDevice
             */

            /**
             * Constructs a new Session.
             * @memberof snacktime.storage
             * @classdesc Represents a Session.
             * @implements ISession
             * @constructor
             * @param {snacktime.storage.ISession=} [properties] Properties to set
             */
            function Session(properties) {
                if (properties)
                    for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                        if (properties[keys[i]] != null)
                            this[keys[i]] = properties[keys[i]];
            }

            /**
             * Session id.
             * @member {string} id
             * @memberof snacktime.storage.Session
             * @instance
             */
            Session.prototype.id = "";

            /**
             * Session startUTC.
             * @member {number|Long} startUTC
             * @memberof snacktime.storage.Session
             * @instance
             */
            Session.prototype.startUTC = $util.Long ? $util.Long.fromBits(0,0,false) : 0;

            /**
             * Session endUTC.
             * @member {number|Long} endUTC
             * @memberof snacktime.storage.Session
             * @instance
             */
            Session.prototype.endUTC = $util.Long ? $util.Long.fromBits(0,0,false) : 0;

            /**
             * Session mediaId.
             * @member {string} mediaId
             * @memberof snacktime.storage.Session
             * @instance
             */
            Session.prototype.mediaId = "";

            /**
             * Session duration.
             * @member {snacktime.storage.IDuration|null|undefined} duration
             * @memberof snacktime.storage.Session
             * @instance
             */
            Session.prototype.duration = null;

            /**
             * Session mediaLenghtInSec.
             * @member {number} mediaLenghtInSec
             * @memberof snacktime.storage.Session
             * @instance
             */
            Session.prototype.mediaLenghtInSec = 0;

            /**
             * Session fromDevice.
             * @member {string} fromDevice
             * @memberof snacktime.storage.Session
             * @instance
             */
            Session.prototype.fromDevice = "";

            return Session;
        })();

        storage.Duration = (function() {

            /**
             * Properties of a Duration.
             * @memberof snacktime.storage
             * @interface IDuration
             * @property {number|null} [startPostionInSec] Duration startPostionInSec
             * @property {number|null} [endPostionInSec] Duration endPostionInSec
             */

            /**
             * Constructs a new Duration.
             * @memberof snacktime.storage
             * @classdesc Represents a Duration.
             * @implements IDuration
             * @constructor
             * @param {snacktime.storage.IDuration=} [properties] Properties to set
             */
            function Duration(properties) {
                if (properties)
                    for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                        if (properties[keys[i]] != null)
                            this[keys[i]] = properties[keys[i]];
            }

            /**
             * Duration startPostionInSec.
             * @member {number} startPostionInSec
             * @memberof snacktime.storage.Duration
             * @instance
             */
            Duration.prototype.startPostionInSec = 0;

            /**
             * Duration endPostionInSec.
             * @member {number} endPostionInSec
             * @memberof snacktime.storage.Duration
             * @instance
             */
            Duration.prototype.endPostionInSec = 0;

            return Duration;
        })();

        storage.Progress = (function() {

            /**
             * Properties of a Progress.
             * @memberof snacktime.storage
             * @interface IProgress
             * @property {number|null} [watchedInSec] Progress watchedInSec
             * @property {number|null} [lenght] Progress lenght
             * @property {number|null} [lastWatchedUtc] Progress lastWatchedUtc
             */

            /**
             * Constructs a new Progress.
             * @memberof snacktime.storage
             * @classdesc Represents a Progress.
             * @implements IProgress
             * @constructor
             * @param {snacktime.storage.IProgress=} [properties] Properties to set
             */
            function Progress(properties) {
                if (properties)
                    for (let keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                        if (properties[keys[i]] != null)
                            this[keys[i]] = properties[keys[i]];
            }

            /**
             * Progress watchedInSec.
             * @member {number} watchedInSec
             * @memberof snacktime.storage.Progress
             * @instance
             */
            Progress.prototype.watchedInSec = 0;

            /**
             * Progress lenght.
             * @member {number} lenght
             * @memberof snacktime.storage.Progress
             * @instance
             */
            Progress.prototype.lenght = 0;

            /**
             * Progress lastWatchedUtc.
             * @member {number} lastWatchedUtc
             * @memberof snacktime.storage.Progress
             * @instance
             */
            Progress.prototype.lastWatchedUtc = 0;

            return Progress;
        })();

        return storage;
    })();

    return snacktime;
})();

export { $root as default };
