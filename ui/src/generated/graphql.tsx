export type Maybe<T> = T | null;
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: string;
  String: string;
  Boolean: boolean;
  Int: number;
  Float: number;
};

export type RootQuery = {
  __typename?: 'RootQuery';
  /** Fetches all series */
  series: Array<Series>;
  seriesById?: Maybe<Series>;
};


export type RootQuerySeriesByIdArgs = {
  SeriesId?: Maybe<Scalars['Int']>;
};

export type Images = {
  __typename?: 'Images';
  coverType: Cover;
  url: Scalars['String'];
};

export type Season = {
  __typename?: 'Season';
  episodes: Array<Episode>;
  number: Scalars['Int'];
};

export type Series = {
  __typename?: 'Series';
  id: Scalars['Int'];
  images: Array<Images>;
  seasons: Array<Season>;
  title: Scalars['String'];
};

export type Episode = {
  __typename?: 'Episode';
  number: Scalars['Int'];
  title: Scalars['String'];
};

/** What kind of cover image */
export enum Cover {
  /** fanart */
  Fanart = 'FANART',
  /** banner */
  Banner = 'BANNER',
  /** poster */
  Poster = 'POSTER'
}

export type GetSeriesByIdQueryVariables = {
  seriesId?: Maybe<Scalars['Int']>;
};


export type GetSeriesByIdQuery = (
  { __typename?: 'RootQuery' }
  & { seriesById?: Maybe<(
    { __typename?: 'Series' }
    & Pick<Series, 'id' | 'title'>
    & { images: Array<(
      { __typename?: 'Images' }
      & Pick<Images, 'coverType' | 'url'>
    )>, seasons: Array<(
      { __typename?: 'Season' }
      & Pick<Season, 'number'>
      & { episodes: Array<(
        { __typename?: 'Episode' }
        & Pick<Episode, 'number' | 'title'>
      )> }
    )> }
  )> }
);

export type GetSeriesQueryVariables = {};


export type GetSeriesQuery = (
  { __typename?: 'RootQuery' }
  & { series: Array<(
    { __typename?: 'Series' }
    & Pick<Series, 'id' | 'title'>
  )> }
);
