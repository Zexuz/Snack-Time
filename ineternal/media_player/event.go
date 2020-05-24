package media_player

type Event struct {
	Id           PropertyId  `json:"id"`
	Value        interface{} `json:"value"`
	PrettyString string      `json:"prettyString"`
}
