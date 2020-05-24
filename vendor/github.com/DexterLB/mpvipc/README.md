# mpvipc
[![GoDoc](https://godoc.org/github.com/DexterLB/mpvipc?status.svg)](http://godoc.org/github.com/DexterLB/mpvipc)
[![Build Status](https://travis-ci.org/DexterLB/mpvipc.svg?branch=master)](https://travis-ci.org/DexterLB/mpvipc)
[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/DexterLB/mpvipc/master/LICENSE)

A Go implementation of [mpv](http://mpv.io)'s [IPC interface](https://mpv.io/manual/master/#json-ipc)

## Sample usage

* Run mpv

    ```
    $ mpv some_file.mkv --input-unix-socket=/tmp/mpv_socket
    ```

* Do things to it!
    
    ```go
    package main

    import (
        "fmt"
        "log"

        "github.com/DexterLB/mpvipc"
    )

    func main() {
        conn := mpvipc.NewConnection("/tmp/mpv_rpc")
        err := conn.Open()
        if err != nil {
            log.Fatal(err)
        }
        defer conn.Close()

        events, stopListening := conn.NewEventListener()

        path, err := conn.Get("path")
        if err != nil {
            log.Fatal(err)
        }
        log.Printf("current file playing: %s", path)

        err = conn.Set("pause", true)
        if err != nil {
            log.Fatal(err)
        }
        log.Printf("paused!")

        _, err = conn.Call("observe_property", 42, "volume")
        if err != nil {
            fmt.Print(err)
        }

        go func() {
            conn.WaitUntilClosed()
            stopListening <- struct{}{}
        }()

        for event := range events {
            if event.ID == 42 {
                log.Printf("volume now is %f", event.Data.(float64))
            } else {
                log.Printf("received event: %s", event.Name)
            }
        }

        log.Printf("mpv closed socket")
    }
    ```

See more examples at the [documentation](http://godoc.org/github.com/DexterLB/mpvipc).

All of mpv's functions and properties are listed [here](https://mpv.io/manual/master/#json-ipc).
