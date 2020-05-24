package mpv

import (
	"github.com/DexterLB/mpvipc"
	"log"
	mp "snack-time/ineternal/media_player"
)

type EventHandler struct {
	mpvEvent chan *mpvipc.Event
	conn     *mpvipc.Connection
	handlers map[mp.PropertyId]func(interface{})
}

func NewEventHandler(conn *mpvipc.Connection) mp.EventHandler {
	events, _ := conn.NewEventListener()

	return &EventHandler{
		mpvEvent: events,
		conn:     conn,
		handlers: map[mp.PropertyId]func(interface{}){},
	}
}

func (m EventHandler) Start() {
	for event := range m.mpvEvent {
		m.handleEvent(event)
	}
}

func (m EventHandler) AddEventHandler(id mp.PropertyId, cb func(interface{})) error {
	if _, err := m.conn.Call("observe_property", id, propertyIdToMpvString(id)); err != nil {
		return err
	}
	m.handlers[id] = cb
	return nil
}

func (m EventHandler) handleEvent(event *mpvipc.Event) {
	if val, ok := m.handlers[mp.PropertyId(event.ID)]; ok {
		val(event.Data)
		return
	}
	log.Fatalf("event: %d is not registered", event.ID)
}
