package graph

import (
	"errors"
	"github.com/graphql-go/graphql"
	bolt "go.etcd.io/bbolt"
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

var FilesToPlayChan = make(chan string, 1)

type Image struct {
	CoverType Cover
	Url       string
}

type Series struct {
	Id     int
	Title  string
	Images []Image
}

var client sonarr.ProviderClient

func init() {
	u, err := url.Parse("http://localhost:8989")
	if err != nil {
		panic(err)
	}
	client = sonarr.NewClient("2e8fcac32bf147608239cab343617485", u)
}

func newNoneNullList(t graphql.Type) graphql.Output {
	return graphql.NewNonNull(graphql.NewList(graphql.NewNonNull(t)))
}

var rootQuery = graphql.NewObject(graphql.ObjectConfig{
	Name: "RootQuery",
	Fields: graphql.Fields{
		"settings": &graphql.Field{
			Type: graphql.NewNonNull(settingsType),
			Resolve: func(p graphql.ResolveParams) (interface{}, error) {
				db, err := bolt.Open("my.db", 0600, nil)
				if err != nil {
					log.Fatal(err)
				}
				defer db.Close()

				var mpvPath []byte
				err = db.View(func(tx *bolt.Tx) error {
					b := tx.Bucket([]byte("Settings"))
					mpvPathTemp := b.Get([]byte("mpvPath"))
					log.Printf("Path is %s", mpvPathTemp)
					mpvPath = make([]byte, len(mpvPathTemp))
					copy(mpvPath, mpvPathTemp)
					return nil
				})

				return Settings{
					MpvPath: string(mpvPath),
				}, err
			},
			Description: "Get all settings",
		},
		"series": seriesQuery,
		"seriesById": &graphql.Field{
			Type: seriesNode,
			Args: map[string]*graphql.ArgumentConfig{
				"SeriesId": {
					Type:         graphql.Int,
					DefaultValue: nil,
					Description:  "Id of series to fetch",
				},
			},
			Resolve: func(p graphql.ResolveParams) (interface{}, error) {
				value, ok := p.Args["SeriesId"].(int)
				if !ok {
					return nil, errors.New("must provide seriesId")
				}
				series, err := client.GetSeriesById(value)
				if err != nil {
					return nil, err
				}

				var imagesMapped = make([]Image, 0)
				for _, image := range series.Images {
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

				return Series{
					Id:     series.ID,
					Title:  series.Title,
					Images: imagesMapped,
				}, nil
			},
		},
	},
})

type Settings struct {
	MpvPath string
}

var settingsType = graphql.NewObject(graphql.ObjectConfig{
	Name: "Settings",
	Fields: graphql.Fields{
		"mpvPath": &graphql.Field{
			Type: graphql.String,
		},
	},
})

var rootMutation = graphql.NewObject(graphql.ObjectConfig{
	Name: "RootMutation",
	Fields: graphql.Fields{
		"updateSettings": &graphql.Field{
			Type: settingsType,
			Args: graphql.FieldConfigArgument{
				"mpvPath": &graphql.ArgumentConfig{
					Type: graphql.NewNonNull(graphql.String),
				},
			},
			Resolve: func(p graphql.ResolveParams) (interface{}, error) {
				text, _ := p.Args["mpvPath"].(string)

				// Open the my.db data file in your current directory.
				// It will be created if it doesn't exist.
				db, err := bolt.Open("my.db", 0600, nil)
				if err != nil {
					log.Fatal(err)
				}
				defer db.Close()

				err = db.Update(func(tx *bolt.Tx) error {
					b, err := tx.CreateBucketIfNotExists([]byte("Settings"))
					if err != nil {
						return err
					}
					err = b.Put([]byte("mpvPath"), []byte(text))
					return err
				})

				return Settings{MpvPath: text}, err
			},
		},
		"playFile": &graphql.Field{
			Type: graphql.Boolean,
			Args: graphql.FieldConfigArgument{
				"filepath": &graphql.ArgumentConfig{
					Type: graphql.NewNonNull(graphql.String),
				},
			},
			Resolve: func(p graphql.ResolveParams) (interface{}, error) {
				filepath, ok := p.Args["filepath"].(string)
				if !ok {
					return nil, errors.New("can't get filepath")
				}
				FilesToPlayChan <- filepath
				return true, nil
			},
		},
	},
})

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
	Name: "Images",
	Fields: graphql.Fields{
		"url": &graphql.Field{
			Type: graphql.NewNonNull(graphql.String),
		},
		"coverType": &graphql.Field{
			Type: graphql.NewNonNull(coverEnum),
		},
	},
})

type Season struct {
	Number   int
	Episodes []Episode
}

type Episode struct {
	Number   int
	Title    string
	Filepath string
}

var seasonType = graphql.NewObject(graphql.ObjectConfig{
	Name: "Season",
	Fields: graphql.Fields{
		"number": &graphql.Field{
			Type: graphql.NewNonNull(graphql.Int),
		},
		"episodes": &graphql.Field{
			Type: newNoneNullList(episodeType),
		},
	},
})

var episodeType = graphql.NewObject(graphql.ObjectConfig{
	Name: "Episode",
	Fields: graphql.Fields{
		"number": &graphql.Field{
			Type: graphql.NewNonNull(graphql.Int),
		},
		"title": &graphql.Field{
			Type: graphql.NewNonNull(graphql.String),
		},
		"filepath": &graphql.Field{
			Type: graphql.String,
		},
	},
})

func GetSchema() (graphql.Schema, error) {
	schemaConfig := graphql.SchemaConfig{
		Query:    rootQuery,
		Mutation: rootMutation,
	}
	return graphql.NewSchema(schemaConfig)
}
