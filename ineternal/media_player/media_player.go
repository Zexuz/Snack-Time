package media_player

type MediaPlayerType string

const (
	MPV MediaPlayerType = "player"
)

type MediaPlayer interface {
	EventHandler
	Close() error
}
