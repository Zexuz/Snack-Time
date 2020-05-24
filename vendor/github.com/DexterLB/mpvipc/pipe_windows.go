// +build windows

package mpvipc

import ( 
	"gopkg.in/natefinch/npipe.v2"
	"net"
)

func dial(path string) (net.Conn, error) {
	return npipe.Dial(path)
}
