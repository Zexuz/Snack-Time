export interface PlayableMedia {
    id: Number // This is the id for the physical file.
    title: string
    type: MediaType
    mediaId: Number
}

export interface Media {
    title: string
    type: MediaType
    id: Number
}

export interface MediaInfo {
    title: string
    type: MediaType
    id: Number
    description: string
}

export enum MediaType {
    Series = "series",
    Movie = "movie"
}
