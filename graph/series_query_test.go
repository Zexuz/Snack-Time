package graph

import (
	"github.com/graphql-go/graphql"
	"snack-time/ineternal/media_provider/sonarr"
	gru "snack-time/test/graph_resolver_utils"
	"testing"
)

func Test_seriesResolver(t *testing.T) {
	tests := []gru.ResolveTest{
		{
			Name:   "Series resolver happy case",
			Golden: "series_resolver_happy_case",
			Args:   graphql.ResolveParams{},
			Mock: gru.ClientMock{
				SeriesFn: func() ([]sonarr.Series, error) {
					return []sonarr.Series{
						{
							ID:    5,
							Title: "Series title (5)",
							Images: []struct {
								CoverType string `json:"coverType"`
								Url       string `json:"url"`
							}{
								{CoverType: "fanart", Url: "fanartUrl:5"},
								{CoverType: "poster", Url: "posetUrl:5"},
								{CoverType: "banner", Url: "bannerUrl:5"},
							},
						},
						{
							ID:    8,
							Title: "Series title (8)",
							Images: []struct {
								CoverType string `json:"coverType"`
								Url       string `json:"url"`
							}{
								{CoverType: "fanart", Url: "fanartUrl:8"},
								{CoverType: "poster", Url: "posetUrl:8"},
								{CoverType: "banner", Url: "bannerUrl:8"},
							},
						},
					}, nil
				},
			},
			Resolver: seriesResolver,
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
