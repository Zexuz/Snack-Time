package media_player

type PropertyId int

const (
	Volume PropertyId = iota
	Duration
	TimePos
)

type EventHandler interface {
	AddEventHandler(id PropertyId, cb func(interface{})) error
	Start()
}
