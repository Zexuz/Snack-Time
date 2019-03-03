import * as $protobuf from "protobufjs";
/** Properties of a Series. */
export interface ISeries {

    /** Series id */
    id?: (number|null);

    /** Series title */
    title?: (string|null);

    /** Series imagesUrl */
    imagesUrl?: (IImagesUrl|null);

    /** Series overview */
    overview?: (string|null);

    /** Series monitored */
    monitored?: (boolean|null);
}

/** Represents a Series. */
export class Series implements ISeries {

    /**
     * Constructs a new Series.
     * @param [properties] Properties to set
     */
    constructor(properties?: ISeries);

    /** Series id. */
    public id: number;

    /** Series title. */
    public title: string;

    /** Series imagesUrl. */
    public imagesUrl?: (IImagesUrl|null);

    /** Series overview. */
    public overview: string;

    /** Series monitored. */
    public monitored: boolean;
}

/** Properties of an ImagesUrl. */
export interface IImagesUrl {

    /** ImagesUrl banner */
    banner?: (string|null);

    /** ImagesUrl fanart */
    fanart?: (string|null);

    /** ImagesUrl poster */
    poster?: (string|null);
}

/** Represents an ImagesUrl. */
export class ImagesUrl implements IImagesUrl {

    /**
     * Constructs a new ImagesUrl.
     * @param [properties] Properties to set
     */
    constructor(properties?: IImagesUrl);

    /** ImagesUrl banner. */
    public banner: string;

    /** ImagesUrl fanart. */
    public fanart: string;

    /** ImagesUrl poster. */
    public poster: string;
}
