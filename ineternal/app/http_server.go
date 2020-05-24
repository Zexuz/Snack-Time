package app

import (
	"fmt"
	"github.com/go-chi/chi"
	"github.com/graphql-go/handler"
	"log"
	"net/http"
	"os"
	"os/exec"
	"snack-time/graph"
	"snack-time/ineternal/infrastructure/http/middleware"

	mp "snack-time/ineternal/media_player"
	mpFactory "snack-time/ineternal/media_player/factory"
	"time"
)

func Start(addr string) {
	schema, err := graph.GetSchema()
	if err != nil {
		log.Fatalf("failed to create new schema, error: %v", err)
	}

	h := handler.New(&handler.Config{
		Schema:     &schema,
		Pretty:     true,
		Playground: true,
	})

	r := chi.NewRouter()
	r.Use(middleware.CorsMiddleware())

	r.Handle("/graphql", h)

	go func() {
		for true {
			select {
			case mediaFile := <-graph.FilesToPlayChan:
				startMpvProcess(mediaFile)
			}
		}
	}()

	log.Printf("connect to http://%s for GraphQL playground", addr)
	log.Fatal(http.ListenAndServe(addr, r))

	//mediaFile := "D:\\Downloads\\TorrentDay\\Brooklyn Nine-Nine\\Season 7\\Brooklyn Nine-Nine - S07E13 - Lights Out WEBDL-1080p.mkv"

	//TODO
	// Get media player type and preference
	// Play mediaFile

	//u, err := url.Parse("http://localhost:8989")
	//if err != nil {
	//	panic(err)
	//}
	//client := sonarr.NewClient("2e8fcac32bf147608239cab343617485", u)
	//series, err := clinet.GetSeries()
	//if err != nil {
	//	panic(err)
	//}
	//log.Println(series)

	//r := chi.NewRouter()
	//
	//r.Use(_httpMiddleware.CorsMiddleware())
	//
	//mediaPlayer()
	//
	//httpServer := http.Server{
	//	Addr: addr,
	//	Handler: http.HandlerFunc(func(resp http.ResponseWriter, req *http.Request) {
	//		r.ServeHTTP(resp, req)
	//	}),
	//}
	//if err := httpServer.ListenAndServe(); err != nil {
	//	grpclog.Fatalf("failed starting http server: %v", err)
	//}
}

type playerProcessOptions struct {
	Path string
	Args []string
}

func startMpvProcess(mediaFile string) {
	// TODO Get from some kind of DB
	path := "C:\\Program Files (x86)\\SVP 4\\mpv64\\mpv.exe"
	// TODO get the socket name, it's OS dependant..
	// TODO instead of harc-coding the args, let the user provide args from the interface.
	args := []string{path, mediaFile, "--input-ipc-server=\\\\.\\pipe\\mpvpipe"}
	_, err := startProcess(args...)
	if err != nil {
		panic(err)
	}
	log.Println("OK!")
}

func mediaPlayer() {
	player := mpFactory.CreateMediaPlayer(mp.MPV)

	//TODO Events to listen to
	// * TimePosition
	// * OnPaused
	// * OnResume
	// * OnStop
	// * OnSeek (Might be covered by TimePos?)
	last := time.Now()
	err := player.AddEventHandler(mp.TimePos, func(data interface{}) {
		current := time.Now()
		delta := time.Now().Sub(last)
		fmt.Println(delta)
		if delta < time.Millisecond*100 {
			return
		}
		last = current

		//dur := time.Duration(data.(float64) * float64(time.Second))
		//eventChan <- &Event{
		//	Id:           TimePos,
		//	Value:        dur.Seconds(),
		//	PrettyString: dur.String(),
		//}
	})
	if err != nil {
		panic(err)
	}

	player.Start()
	log.Printf("mpv closed socket")
}

func startProcess(args ...string) (p *os.Process, err error) {
	if args[0], err = exec.LookPath(args[0]); err == nil {
		var procAttr os.ProcAttr
		procAttr.Files = []*os.File{os.Stdin,
			os.Stdout, os.Stderr}
		p, err := os.StartProcess(args[0], args, &procAttr)
		if err == nil {
			return p, nil
		}
	}
	return nil, err
}
