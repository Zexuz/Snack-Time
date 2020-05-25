package graph

import (
	"github.com/graphql-go/graphql"
	"snack-time/ineternal/media_provider/sonarr"
	gru "snack-time/test/graph_resolver_utils"
	"testing"
)

func Test_seasonResolver(t *testing.T) {
	tests := []gru.ResolveTest{
		{
			Name:     "Season resolver happy case",
			Golden:   "season_resolver_happy_case",
			Resolver: seasonResolver,
			Args: graphql.ResolveParams{
				Source: Series{Id: 10},
			},
			Mock: gru.ClientMock{
				EpisodesFn: func() ([]sonarr.Episode, error) {
					return []sonarr.Episode{
						{
							Title:         "S01E01",
							SeasonNumber:  1,
							EpisodeNumber: 1,
							EpisodeFileID: 0,
						},
						{
							Title:         "S01E02",
							SeasonNumber:  1,
							EpisodeNumber: 2,
							EpisodeFileID: 0,
						},
						{
							Title:         "S01E03",
							SeasonNumber:  1,
							EpisodeNumber: 3,
							EpisodeFileID: 5,
						},
					}, nil
				},
				EpisodeFilesFn: func() ([]sonarr.EpisodeFile, error) {
					return []sonarr.EpisodeFile{
						{
							ID:   5,
							Path: "/some/path",
						},
					}, nil
				},
			},
		},
	}
	for _, tt := range tests {
		t.Run(tt.Name, func(t *testing.T) {
			got, err := tt.Resolver(tt.Mock)(tt.Args)
			if err != nil {
				t.Errorf("resolver returned error: %v", err)
			}
			want := gru.GoldenValue(t, tt.Golden, got, *gru.Update)
			if gru.GenerateJSON(got) != want {
				t.Errorf("Want:\n%s\nGot:\n%s", want, got)
			}
		})
	}
}
