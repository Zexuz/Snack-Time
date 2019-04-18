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

        return series;
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

        return storage;
    })();

    return snacktime;
})();

export { $root as default };
