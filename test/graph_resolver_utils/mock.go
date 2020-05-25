package graph_resolver_utils

import "snack-time/ineternal/media_provider/sonarr"

type ClientMock struct {
	SeriesFn       func() ([]sonarr.Series, error)
	EpisodesFn     func() ([]sonarr.Episode, error)
	EpisodeFilesFn func() ([]sonarr.EpisodeFile, error)
}

func (c ClientMock) GetSeries() ([]sonarr.Series, error) {
	return c.SeriesFn()
}

func (c ClientMock) GetSeriesById(int) (*sonarr.Series, error) {
	panic("implement me")
}

func (c ClientMock) GetEpisodes(int) ([]sonarr.Episode, error) {
	return c.EpisodesFn()
}

func (c ClientMock) GetEpisodeFiles(int) ([]sonarr.EpisodeFile, error) {
	return c.EpisodeFilesFn()
}
