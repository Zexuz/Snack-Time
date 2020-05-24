package mpv

import mp "snack-time/ineternal/media_player"

var propertyIdMpvMap = map[mp.PropertyId]string{
	mp.Volume:   "volume",
	mp.TimePos:  "time-pos",
	mp.Duration: "duration",
}

func propertyIdToMpvString(d mp.PropertyId) string {
	return propertyIdMpvMap[d]
}
