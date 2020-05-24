package mpv

import (
	"github.com/DexterLB/mpvipc"
	"log"
	mp "snack-time/ineternal/media_player"
)

type player struct {
	mp.EventHandler
	close func() error
}

func (p player) AddEventHandler(id mp.PropertyId, cb func(interface{})) error {
	panic("implement me")
}

func (p player) Start() {
	panic("implement me")
}

func (p player) Close() error {
	panic("implement me")
}

func CreatePlayer() mp.MediaPlayer {
	conn := mpvipc.NewConnection("\\\\.\\pipe\\mpvpipe")
	err := conn.Open()
	if err != nil {
		log.Fatal(err)
	}
	return &player{
		EventHandler: NewEventHandler(conn),
		close:        conn.Close,
	}
}
