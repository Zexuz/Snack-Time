import * as $protobuf from "protobufjs";
/** Namespace snacktime. */
export namespace snacktime {

    /** Namespace episode. */
    namespace episode {

        /** Namespace service. */
        namespace service {

            /** Properties of a GetByIdRequest. */
            interface IGetByIdRequest {

                /** GetByIdRequest id */
                id?: (number|null);
            }

            /** Represents a GetByIdRequest. */
            class GetByIdRequest implements IGetByIdRequest {

                /**
                 * Constructs a new GetByIdRequest.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.episode.service.IGetByIdRequest);

                /** GetByIdRequest id. */
                public id: number;
            }

            /** Properties of a GetByIdResponse. */
            interface IGetByIdResponse {

                /** GetByIdResponse episode */
                episode?: (snacktime.media.IEpisode|null);
            }

            /** Represents a GetByIdResponse. */
            class GetByIdResponse implements IGetByIdResponse {

                /**
                 * Constructs a new GetByIdResponse.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.episode.service.IGetByIdResponse);

                /** GetByIdResponse episode. */
                public episode?: (snacktime.media.IEpisode|null);
            }

            /** Properties of a GetBySeriesIdRequest. */
            interface IGetBySeriesIdRequest {

                /** GetBySeriesIdRequest seriesId */
                seriesId?: (number|null);
            }

            /** Represents a GetBySeriesIdRequest. */
            class GetBySeriesIdRequest implements IGetBySeriesIdRequest {

                /**
                 * Constructs a new GetBySeriesIdRequest.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.episode.service.IGetBySeriesIdRequest);

                /** GetBySeriesIdRequest seriesId. */
                public seriesId: number;
            }

            /** Properties of a GetBySeriesIdResponse. */
            interface IGetBySeriesIdResponse {

                /** GetBySeriesIdResponse episodes */
                episodes?: (snacktime.media.IEpisode[]|null);
            }

            /** Represents a GetBySeriesIdResponse. */
            class GetBySeriesIdResponse implements IGetBySeriesIdResponse {

                /**
                 * Constructs a new GetBySeriesIdResponse.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.episode.service.IGetBySeriesIdResponse);

                /** GetBySeriesIdResponse episodes. */
                public episodes: snacktime.media.IEpisode[];
            }

            /** Represents an Episode */
            class Episode extends $protobuf.rpc.Service {

                /**
                 * Constructs a new Episode service.
                 * @param rpcImpl RPC implementation
                 * @param [requestDelimited=false] Whether requests are length-delimited
                 * @param [responseDelimited=false] Whether responses are length-delimited
                 */
                constructor(rpcImpl: $protobuf.RPCImpl, requestDelimited?: boolean, responseDelimited?: boolean);

                /**
                 * Calls GetBySeriesId.
                 * @param request GetBySeriesIdRequest message or plain object
                 * @param callback Node-style callback called with the error, if any, and GetBySeriesIdResponse
                 */
                public getBySeriesId(request: snacktime.episode.service.IGetBySeriesIdRequest, callback: snacktime.episode.service.Episode.GetBySeriesIdCallback): void;

                /**
                 * Calls GetBySeriesId.
                 * @param request GetBySeriesIdRequest message or plain object
                 * @returns Promise
                 */
                public getBySeriesId(request: snacktime.episode.service.IGetBySeriesIdRequest): Promise<snacktime.episode.service.GetBySeriesIdResponse>;

                /**
                 * Calls GetById.
                 * @param request GetByIdRequest message or plain object
                 * @param callback Node-style callback called with the error, if any, and GetByIdResponse
                 */
                public getById(request: snacktime.episode.service.IGetByIdRequest, callback: snacktime.episode.service.Episode.GetByIdCallback): void;

                /**
                 * Calls GetById.
                 * @param request GetByIdRequest message or plain object
                 * @returns Promise
                 */
                public getById(request: snacktime.episode.service.IGetByIdRequest): Promise<snacktime.episode.service.GetByIdResponse>;
            }

            namespace Episode {

                /**
                 * Callback as used by {@link snacktime.episode.service.Episode#getBySeriesId}.
                 * @param error Error, if any
                 * @param [response] GetBySeriesIdResponse
                 */
                type GetBySeriesIdCallback = (error: (Error|null), response?: snacktime.episode.service.GetBySeriesIdResponse) => void;

                /**
                 * Callback as used by {@link snacktime.episode.service.Episode#getById}.
                 * @param error Error, if any
                 * @param [response] GetByIdResponse
                 */
                type GetByIdCallback = (error: (Error|null), response?: snacktime.episode.service.GetByIdResponse) => void;
            }
        }
    }

    /** Namespace series. */
    namespace series {

        /** Namespace file. */
        namespace file {

            /** Properties of a DownloadFileRequest. */
            interface IDownloadFileRequest {

                /** DownloadFileRequest mediaFileId */
                mediaFileId?: (string|null);
            }

            /** Represents a DownloadFileRequest. */
            class DownloadFileRequest implements IDownloadFileRequest {

                /**
                 * Constructs a new DownloadFileRequest.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.series.file.IDownloadFileRequest);

                /** DownloadFileRequest mediaFileId. */
                public mediaFileId: string;
            }

            /** Properties of a ResponseDownloadFile. */
            interface IResponseDownloadFile {

                /** ResponseDownloadFile started */
                started?: (snacktime.series.file.IStarted|null);

                /** ResponseDownloadFile progress */
                progress?: (snacktime.series.file.IChunk|null);

                /** ResponseDownloadFile done */
                done?: (snacktime.series.file.IDone|null);
            }

            /** Represents a ResponseDownloadFile. */
            class ResponseDownloadFile implements IResponseDownloadFile {

                /**
                 * Constructs a new ResponseDownloadFile.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.series.file.IResponseDownloadFile);

                /** ResponseDownloadFile started. */
                public started?: (snacktime.series.file.IStarted|null);

                /** ResponseDownloadFile progress. */
                public progress?: (snacktime.series.file.IChunk|null);

                /** ResponseDownloadFile done. */
                public done?: (snacktime.series.file.IDone|null);

                /** ResponseDownloadFile type. */
                public type?: ("started"|"progress"|"done");
            }

            /** Properties of a Started. */
            interface IStarted {

                /** Started lenght */
                lenght?: (number|null);

                /** Started sizePerChunk */
                sizePerChunk?: (number|null);

                /** Started FileName */
                FileName?: (string|null);
            }

            /** Represents a Started. */
            class Started implements IStarted {

                /**
                 * Constructs a new Started.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.series.file.IStarted);

                /** Started lenght. */
                public lenght: number;

                /** Started sizePerChunk. */
                public sizePerChunk: number;

                /** Started FileName. */
                public FileName: string;
            }

            /** Properties of a Chunk. */
            interface IChunk {

                /** Chunk Content */
                Content?: (Uint8Array|null);
            }

            /** Represents a Chunk. */
            class Chunk implements IChunk {

                /**
                 * Constructs a new Chunk.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.series.file.IChunk);

                /** Chunk Content. */
                public Content: Uint8Array;
            }

            /** Properties of a Done. */
            interface IDone {

                /** Done Hash */
                Hash?: (string|null);
            }

            /** Represents a Done. */
            class Done implements IDone {

                /**
                 * Constructs a new Done.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.series.file.IDone);

                /** Done Hash. */
                public Hash: string;
            }

            /** Represents a File */
            class File extends $protobuf.rpc.Service {

                /**
                 * Constructs a new File service.
                 * @param rpcImpl RPC implementation
                 * @param [requestDelimited=false] Whether requests are length-delimited
                 * @param [responseDelimited=false] Whether responses are length-delimited
                 */
                constructor(rpcImpl: $protobuf.RPCImpl, requestDelimited?: boolean, responseDelimited?: boolean);

                /**
                 * Calls Download.
                 * @param request DownloadFileRequest message or plain object
                 * @param callback Node-style callback called with the error, if any, and ResponseDownloadFile
                 */
                public download(request: snacktime.series.file.IDownloadFileRequest, callback: snacktime.series.file.File.DownloadCallback): void;

                /**
                 * Calls Download.
                 * @param request DownloadFileRequest message or plain object
                 * @returns Promise
                 */
                public download(request: snacktime.series.file.IDownloadFileRequest): Promise<snacktime.series.file.ResponseDownloadFile>;
            }

            namespace File {

                /**
                 * Callback as used by {@link snacktime.series.file.File#download}.
                 * @param error Error, if any
                 * @param [response] ResponseDownloadFile
                 */
                type DownloadCallback = (error: (Error|null), response?: snacktime.series.file.ResponseDownloadFile) => void;
            }
        }

        /** Namespace service. */
        namespace service {

            /** Properties of a GetAllRequest. */
            interface IGetAllRequest {
            }

            /** Represents a GetAllRequest. */
            class GetAllRequest implements IGetAllRequest {

                /**
                 * Constructs a new GetAllRequest.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.series.service.IGetAllRequest);
            }

            /** Properties of a GetAllResponse. */
            interface IGetAllResponse {

                /** GetAllResponse series */
                series?: (snacktime.media.ISeries[]|null);
            }

            /** Represents a GetAllResponse. */
            class GetAllResponse implements IGetAllResponse {

                /**
                 * Constructs a new GetAllResponse.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.series.service.IGetAllResponse);

                /** GetAllResponse series. */
                public series: snacktime.media.ISeries[];
            }

            /** Properties of a GetByIdRequest. */
            interface IGetByIdRequest {

                /** GetByIdRequest id */
                id?: (number|null);
            }

            /** Represents a GetByIdRequest. */
            class GetByIdRequest implements IGetByIdRequest {

                /**
                 * Constructs a new GetByIdRequest.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.series.service.IGetByIdRequest);

                /** GetByIdRequest id. */
                public id: number;
            }

            /** Properties of a GetByIdResponse. */
            interface IGetByIdResponse {

                /** GetByIdResponse series */
                series?: (snacktime.media.ISeries|null);
            }

            /** Represents a GetByIdResponse. */
            class GetByIdResponse implements IGetByIdResponse {

                /**
                 * Constructs a new GetByIdResponse.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.series.service.IGetByIdResponse);

                /** GetByIdResponse series. */
                public series?: (snacktime.media.ISeries|null);
            }

            /** Properties of a GetLastDownloadedRequest. */
            interface IGetLastDownloadedRequest {
            }

            /** Represents a GetLastDownloadedRequest. */
            class GetLastDownloadedRequest implements IGetLastDownloadedRequest {

                /**
                 * Constructs a new GetLastDownloadedRequest.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.series.service.IGetLastDownloadedRequest);
            }

            /** Properties of a GetLastDownloadedResponse. */
            interface IGetLastDownloadedResponse {

                /** GetLastDownloadedResponse series */
                series?: (snacktime.media.ISeries[]|null);
            }

            /** Represents a GetLastDownloadedResponse. */
            class GetLastDownloadedResponse implements IGetLastDownloadedResponse {

                /**
                 * Constructs a new GetLastDownloadedResponse.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.series.service.IGetLastDownloadedResponse);

                /** GetLastDownloadedResponse series. */
                public series: snacktime.media.ISeries[];
            }

            /** Represents a Series */
            class Series extends $protobuf.rpc.Service {

                /**
                 * Constructs a new Series service.
                 * @param rpcImpl RPC implementation
                 * @param [requestDelimited=false] Whether requests are length-delimited
                 * @param [responseDelimited=false] Whether responses are length-delimited
                 */
                constructor(rpcImpl: $protobuf.RPCImpl, requestDelimited?: boolean, responseDelimited?: boolean);

                /**
                 * Calls GetLastDownloaded.
                 * @param request GetLastDownloadedRequest message or plain object
                 * @param callback Node-style callback called with the error, if any, and GetLastDownloadedResponse
                 */
                public getLastDownloaded(request: snacktime.series.service.IGetLastDownloadedRequest, callback: snacktime.series.service.Series.GetLastDownloadedCallback): void;

                /**
                 * Calls GetLastDownloaded.
                 * @param request GetLastDownloadedRequest message or plain object
                 * @returns Promise
                 */
                public getLastDownloaded(request: snacktime.series.service.IGetLastDownloadedRequest): Promise<snacktime.series.service.GetLastDownloadedResponse>;

                /**
                 * Calls GetAll.
                 * @param request GetAllRequest message or plain object
                 * @param callback Node-style callback called with the error, if any, and GetAllResponse
                 */
                public getAll(request: snacktime.series.service.IGetAllRequest, callback: snacktime.series.service.Series.GetAllCallback): void;

                /**
                 * Calls GetAll.
                 * @param request GetAllRequest message or plain object
                 * @returns Promise
                 */
                public getAll(request: snacktime.series.service.IGetAllRequest): Promise<snacktime.series.service.GetAllResponse>;

                /**
                 * Calls GetById.
                 * @param request GetByIdRequest message or plain object
                 * @param callback Node-style callback called with the error, if any, and GetByIdResponse
                 */
                public getById(request: snacktime.series.service.IGetByIdRequest, callback: snacktime.series.service.Series.GetByIdCallback): void;

                /**
                 * Calls GetById.
                 * @param request GetByIdRequest message or plain object
                 * @returns Promise
                 */
                public getById(request: snacktime.series.service.IGetByIdRequest): Promise<snacktime.series.service.GetByIdResponse>;
            }

            namespace Series {

                /**
                 * Callback as used by {@link snacktime.series.service.Series#getLastDownloaded}.
                 * @param error Error, if any
                 * @param [response] GetLastDownloadedResponse
                 */
                type GetLastDownloadedCallback = (error: (Error|null), response?: snacktime.series.service.GetLastDownloadedResponse) => void;

                /**
                 * Callback as used by {@link snacktime.series.service.Series#getAll}.
                 * @param error Error, if any
                 * @param [response] GetAllResponse
                 */
                type GetAllCallback = (error: (Error|null), response?: snacktime.series.service.GetAllResponse) => void;

                /**
                 * Callback as used by {@link snacktime.series.service.Series#getById}.
                 * @param error Error, if any
                 * @param [response] GetByIdResponse
                 */
                type GetByIdCallback = (error: (Error|null), response?: snacktime.series.service.GetByIdResponse) => void;
            }
        }
    }

    /** Namespace media. */
    namespace media {

        /** Properties of a Series. */
        interface ISeries {

            /** Series id */
            id?: (number|null);

            /** Series title */
            title?: (string|null);

            /** Series imagesUrl */
            imagesUrl?: (snacktime.media.IImagesUrl|null);

            /** Series overview */
            overview?: (string|null);

            /** Series monitored */
            monitored?: (boolean|null);
        }

        /** Represents a Series. */
        class Series implements ISeries {

            /**
             * Constructs a new Series.
             * @param [properties] Properties to set
             */
            constructor(properties?: snacktime.media.ISeries);

            /** Series id. */
            public id: number;

            /** Series title. */
            public title: string;

            /** Series imagesUrl. */
            public imagesUrl?: (snacktime.media.IImagesUrl|null);

            /** Series overview. */
            public overview: string;

            /** Series monitored. */
            public monitored: boolean;
        }

        /** Properties of an ImagesUrl. */
        interface IImagesUrl {

            /** ImagesUrl banner */
            banner?: (string|null);

            /** ImagesUrl fanart */
            fanart?: (string|null);

            /** ImagesUrl poster */
            poster?: (string|null);
        }

        /** Represents an ImagesUrl. */
        class ImagesUrl implements IImagesUrl {

            /**
             * Constructs a new ImagesUrl.
             * @param [properties] Properties to set
             */
            constructor(properties?: snacktime.media.IImagesUrl);

            /** ImagesUrl banner. */
            public banner: string;

            /** ImagesUrl fanart. */
            public fanart: string;

            /** ImagesUrl poster. */
            public poster: string;
        }

        /** Properties of an Episode. */
        interface IEpisode {

            /** Episode seriesId */
            seriesId?: (number|null);

            /** Episode episodeFileId */
            episodeFileId?: (number|null);

            /** Episode seasonNumber */
            seasonNumber?: (number|null);

            /** Episode episideNumber */
            episideNumber?: (number|null);

            /** Episode title */
            title?: (string|null);

            /** Episode overview */
            overview?: (string|null);

            /** Episode playableId */
            playableId?: (string|null);

            /** Episode progress */
            progress?: (snacktime.storage.IProgress|null);
        }

        /** Represents an Episode. */
        class Episode implements IEpisode {

            /**
             * Constructs a new Episode.
             * @param [properties] Properties to set
             */
            constructor(properties?: snacktime.media.IEpisode);

            /** Episode seriesId. */
            public seriesId: number;

            /** Episode episodeFileId. */
            public episodeFileId: number;

            /** Episode seasonNumber. */
            public seasonNumber: number;

            /** Episode episideNumber. */
            public episideNumber: number;

            /** Episode title. */
            public title: string;

            /** Episode overview. */
            public overview: string;

            /** Episode playableId. */
            public playableId: string;

            /** Episode progress. */
            public progress?: (snacktime.storage.IProgress|null);
        }

        /** Providers enum. */
        enum Providers {
            Sonarr = 0,
            Radarr = 1
        }
    }

    /** Namespace app. */
    namespace app {

        /** Namespace settings. */
        namespace settings {

            /** Properties of a Settings. */
            interface ISettings {

                /** Settings fileDir */
                fileDir?: (string|null);

                /** Settings tempFileDir */
                tempFileDir?: (string|null);

                /** Settings mpvPath */
                mpvPath?: (string|null);

                /** Settings svpPath */
                svpPath?: (string|null);

                /** Settings mediaServerAddress */
                mediaServerAddress?: (string|null);
            }

            /** Represents a Settings. */
            class Settings implements ISettings {

                /**
                 * Constructs a new Settings.
                 * @param [properties] Properties to set
                 */
                constructor(properties?: snacktime.app.settings.ISettings);

                /** Settings fileDir. */
                public fileDir: string;

                /** Settings tempFileDir. */
                public tempFileDir: string;

                /** Settings mpvPath. */
                public mpvPath: string;

                /** Settings svpPath. */
                public svpPath: string;

                /** Settings mediaServerAddress. */
                public mediaServerAddress: string;
            }
        }
    }

    /** Namespace storage. */
    namespace storage {

        /** Properties of a MediaFile. */
        interface IMediaFile {

            /** MediaFile fileName */
            fileName?: (string|null);

            /** MediaFile mediaName */
            mediaName?: (string|null);

            /** MediaFile downloadedUTC */
            downloadedUTC?: (string|null);

            /** MediaFile lastWatchedUTC */
            lastWatchedUTC?: (string|null);
        }

        /** Represents a MediaFile. */
        class MediaFile implements IMediaFile {

            /**
             * Constructs a new MediaFile.
             * @param [properties] Properties to set
             */
            constructor(properties?: snacktime.storage.IMediaFile);

            /** MediaFile fileName. */
            public fileName: string;

            /** MediaFile mediaName. */
            public mediaName: string;

            /** MediaFile downloadedUTC. */
            public downloadedUTC: string;

            /** MediaFile lastWatchedUTC. */
            public lastWatchedUTC: string;
        }

        /** Properties of a Session. */
        interface ISession {

            /** Session id */
            id?: (string|null);

            /** Session startUTC */
            startUTC?: (number|Long|null);

            /** Session endUTC */
            endUTC?: (number|Long|null);

            /** Session mediaId */
            mediaId?: (string|null);

            /** Session duration */
            duration?: (snacktime.storage.IDuration|null);

            /** Session mediaLenghtInSec */
            mediaLenghtInSec?: (number|null);

            /** Session fromDevice */
            fromDevice?: (string|null);
        }

        /** Represents a Session. */
        class Session implements ISession {

            /**
             * Constructs a new Session.
             * @param [properties] Properties to set
             */
            constructor(properties?: snacktime.storage.ISession);

            /** Session id. */
            public id: string;

            /** Session startUTC. */
            public startUTC: (number|Long);

            /** Session endUTC. */
            public endUTC: (number|Long);

            /** Session mediaId. */
            public mediaId: string;

            /** Session duration. */
            public duration?: (snacktime.storage.IDuration|null);

            /** Session mediaLenghtInSec. */
            public mediaLenghtInSec: number;

            /** Session fromDevice. */
            public fromDevice: string;
        }

        /** Properties of a Duration. */
        interface IDuration {

            /** Duration startPostionInSec */
            startPostionInSec?: (number|null);

            /** Duration endPostionInSec */
            endPostionInSec?: (number|null);
        }

        /** Represents a Duration. */
        class Duration implements IDuration {

            /**
             * Constructs a new Duration.
             * @param [properties] Properties to set
             */
            constructor(properties?: snacktime.storage.IDuration);

            /** Duration startPostionInSec. */
            public startPostionInSec: number;

            /** Duration endPostionInSec. */
            public endPostionInSec: number;
        }

        /** Properties of a Progress. */
        interface IProgress {

            /** Progress watchedInSec */
            watchedInSec?: (number|null);

            /** Progress lenght */
            lenght?: (number|null);

            /** Progress lastWatchedUtc */
            lastWatchedUtc?: (number|null);
        }

        /** Represents a Progress. */
        class Progress implements IProgress {

            /**
             * Constructs a new Progress.
             * @param [properties] Properties to set
             */
            constructor(properties?: snacktime.storage.IProgress);

            /** Progress watchedInSec. */
            public watchedInSec: number;

            /** Progress lenght. */
            public lenght: number;

            /** Progress lastWatchedUtc. */
            public lastWatchedUtc: number;
        }
    }
}
