package factory

import (
	"fmt"
	mp "snack-time/ineternal/media_player"
	"snack-time/ineternal/mpv"
)

func CreateMediaPlayer(playerType mp.MediaPlayerType) mp.MediaPlayer {
	switch playerType {
	case mp.MPV:
		return mpv.CreatePlayer()
	default:
		panic(fmt.Sprintf("Unknown MediaPlayerType %s", playerType))
	}
}
