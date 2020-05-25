package graph_querie_utils

//func Test_seasonResolver(t *testing.T) {
//	tests := []struct {
//		name   string
//		golden string
//		query  string
//		resolver     func() func(p graphql.ResolveParams) (interface{}, error)
//	}{
//		{
//			name:   "Should resolve only called fields",
//			golden: "only_called_fields",
//			query: `query {
//					  series {
//						id
//						title
//						images {
//						  coverType
//						  url
//						}
//						seasons {
//						  number
//						  episodes {
//							filepath
//							number
//							title
//						  }
//						}
//					  }
//					}
//			`,
//			resolver: func() func(p graphql.ResolveParams) (interface{}, error) {
//				mock := clientMock{
//					getEpisodes: func() ([]sonarr.Episode, error) {
//						return []sonarr.Episode{
//							{
//								Title:         "S01E01",
//								SeasonNumber:  1,
//								EpisodeNumber: 1,
//								EpisodeFileID: 0,
//							},
//							{
//								Title:         "S01E02",
//								SeasonNumber:  1,
//								EpisodeNumber: 2,
//								EpisodeFileID: 0,
//							},
//							{
//								Title:         "S01E03",
//								SeasonNumber:  1,
//								EpisodeNumber: 3,
//								EpisodeFileID: 5,
//							},
//						}, nil
//					},
//					getEpisodeFiles: func() ([]sonarr.EpisodeFile, error) {
//						return []sonarr.EpisodeFile{
//							{
//								ID:   5,
//								Path: "/some/path",
//							},
//						}, nil
//					},
//				}
//				return seasonResolver(mock)
//			},
//		},
//	}
//	for _, tt := range tests {
//		t.Run(tt.name, func(t *testing.T) {
//			got := generate(tt.resolver())
//			want := GoldenValue(t, tt.golden, got, *Update)
//			if got != want {
//				t.Errorf("Want:\n%s\nGot:\n%s", want, got)
//			}
//		})
//	}
//}

//func generate(query *graphql.Object, requestString string) string {
//	schemaConfig := graphql.SchemaConfig{Query: query}
//	schema, err := graphql.NewSchema(schemaConfig)
//	if err != nil {
//		log.Fatalf("failed to create new schema, error: %v", err)
//	}
//
//	params := graphql.Params{Schema: schema, RequestString: requestString}
//	r := graphql.Do(params)
//	if len(r.Errors) > 0 {
//		log.Fatalf("failed to execute graphql operation, errors: %+v", r.Errors)
//	}
//	rJSON, err := json.Marshal(r)
//	if err != nil {
//		log.Fatalf("failed to create json: %v", err)
//	}
//
//	return string(rJSON)
//}
