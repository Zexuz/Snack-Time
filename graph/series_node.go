package graph

import (
	"errors"
	"github.com/graphql-go/graphql"
	"snack-time/ineternal/media_provider/sonarr"
)

var seriesNode = graphql.NewObject(graphql.ObjectConfig{
	Name: "Series",
	Fields: graphql.Fields{
		"id": &graphql.Field{
			Type: graphql.NewNonNull(graphql.Int),
		},
		"title": &graphql.Field{
			Type: graphql.NewNonNull(graphql.String),
		},
		"images": &graphql.Field{
			Type: newNoneNullList(imageType),
		},
		"seasons": &graphql.Field{
			Type:    newNoneNullList(seasonType),
			Resolve: seasonResolver(client),
		},
	},
})

func seasonResolver(client sonarr.ProviderClient) graphql.FieldResolveFn {
	return func(p graphql.ResolveParams) (interface{}, error) {
		value, ok := p.Source.(Series)
		if !ok {
			return nil, errors.New("error parsing source")
		}
		season := make([]Season, 0)
		episodes, err := client.GetEpisodes(value.Id)
		if err != nil {
			return nil, err
		}

		episodeFiles, err := client.GetEpisodeFiles(value.Id)
		if err != nil {
			return nil, err
		}

		episodeFileMap := make(map[int]sonarr.EpisodeFile)
		for _, epFile := range episodeFiles {
			episodeFileMap[epFile.ID] = epFile
		}

		seasons := make(map[int][]sonarr.Episode)
		for _, episode := range episodes {
			if _, ok := seasons[episode.SeasonNumber]; !ok {
				seasons[episode.SeasonNumber] = make([]sonarr.Episode, 0)
			}
			seasons[episode.SeasonNumber] = append(seasons[episode.SeasonNumber], episode)
		}

		for seasonNumber, eps := range seasons {
			seasonEpisodes := make([]Episode, 0)

			for _, ep := range eps {
				seasonEpisodes = append(seasonEpisodes, Episode{
					Number:   ep.EpisodeNumber,
					Title:    ep.Title,
					Filepath: episodeFileMap[ep.EpisodeFileID].Path,
				})
			}

			season = append(season, Season{
				Number:   seasonNumber,
				Episodes: seasonEpisodes,
			})
		}

		return season, nil
	}
}
