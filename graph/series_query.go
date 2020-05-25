package graph

import (
	"github.com/graphql-go/graphql"
	"log"
	"snack-time/ineternal/media_provider/sonarr"
	"strings"
)

var seriesQuery = &graphql.Field{
	Name:        "Series Query",
	Type:        newNoneNullList(seriesNode),
	Description: "Fetches all series",
	Resolve:     seriesResolver(client),
}

func seriesResolver(client sonarr.ProviderClient) graphql.FieldResolveFn {
	return func(p graphql.ResolveParams) (interface{}, error) {
		series, err := client.GetSeries()
		if err != nil {
			panic(err)
		}

		var seriesMapped = make([]Series, 0)
		for _, s := range series {
			var imagesMapped = make([]Image, 0)

			for _, image := range s.Images {
				getCoverType := func(t string) Cover {
					switch strings.ToLower(t) {
					case "fanart":
						return Fanart
					case "poster":
						return Poster
					case "banner":
						return Banner
					}
					log.Fatalf("unknown cover type %s", t)
					return 0
				}
				imagesMapped = append(imagesMapped, Image{
					CoverType: getCoverType(image.CoverType),
					Url:       image.Url,
				})
			}

			seriesMapped = append(seriesMapped, Series{
				Id:     s.ID,
				Title:  s.Title,
				Images: imagesMapped,
			})
		}
		return seriesMapped, nil
	}
}
