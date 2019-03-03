import * as $protobuf from "protobufjs";
/** Properties of an Episode. */
export interface IEpisode {

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
}

/** Represents an Episode. */
export class Episode implements IEpisode {

    /**
     * Constructs a new Episode.
     * @param [properties] Properties to set
     */
    constructor(properties?: IEpisode);

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
}
