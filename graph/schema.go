package graph

import (
	"github.com/graphql-go/graphql"
	"log"
	"net/url"
	"snack-time/ineternal/media_provider/sonarr"
	"strings"
)

type Cover int

const (
	Fanart Cover = iota
	Banner
	Poster
)

type Image struct {
	CoverType Cover
	Url       string
}

type Series struct {
	Id    int
	Title string
	Image []Image
}

var rootQuery = graphql.NewObject(graphql.ObjectConfig{
	Name: "RootQuery",
	Fields: graphql.Fields{
		"series": &graphql.Field{
			Type:        graphql.NewList(seriesType),
			Description: "Fetches all series",
			Resolve: func(p graphql.ResolveParams) (interface{}, error) {
				u, err := url.Parse("http://localhost:8989")
				if err != nil {
					panic(err)
				}
				client := sonarr.NewClient("2e8fcac32bf147608239cab343617485", u)
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
						Id:    s.ID,
						Title: s.Title,
						Image: imagesMapped,
					})
				}
				return seriesMapped, nil
			},
		},
	},
})

//var rootMutation = graphql.NewObject(graphql.ObjectConfig{
//	Name: "RootMutation",
//	Fields: graphql.Fields{
//		"":graphql.Field{}
//	},
//})

var coverEnum = graphql.NewEnum(graphql.EnumConfig{
	Name:        "Cover",
	Description: "What kind of cover image",
	Values: graphql.EnumValueConfigMap{
		"FANART": &graphql.EnumValueConfig{
			Value:       Fanart,
			Description: "fanart",
		},
		"BANNER": &graphql.EnumValueConfig{
			Value:       Banner,
			Description: "banner",
		},
		"POSTER": &graphql.EnumValueConfig{
			Value:       Poster,
			Description: "poster",
		},
	},
})

var imageType = graphql.NewObject(graphql.ObjectConfig{
	Name: "Image",
	Fields: graphql.Fields{
		"url": &graphql.Field{
			Type: graphql.String,
		},
		"coverType": &graphql.Field{
			Type: coverEnum,
		},
	},
})

var seriesType = graphql.NewObject(graphql.ObjectConfig{
	Name: "Series",
	Fields: graphql.Fields{
		"id": &graphql.Field{
			Type: graphql.Int,
		},
		"title": &graphql.Field{
			Type: graphql.String,
		},
		"image": &graphql.Field{
			Type: graphql.NewList(imageType),
		},
	},
})

func GetSchema() (graphql.Schema, error) {
	schemaConfig := graphql.SchemaConfig{
		Query: rootQuery,
		//Mutation: rootMutation,
	}
	return graphql.NewSchema(schemaConfig)
}
