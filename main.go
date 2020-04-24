package main

import (
	"github.com/go-chi/chi"
	"github.com/improbable-eng/grpc-web/go/grpcweb"
	"google.golang.org/grpc"
	"google.golang.org/grpc/grpclog"
	"net/http"
	_greeterGrpcDelivery "snack-time/greeter/delivery/grpc"
	_greeterHttpDelivery "snack-time/greeter/delivery/http"
	_grpcwebMiddleware "snack-time/infrastructure/grpcweb/middleware"
	_httpMiddleware "snack-time/infrastructure/http/middleware"
)

func main() {
	r := chi.NewRouter()
	grpcServer := grpc.NewServer()

	r.Use(_httpMiddleware.CorsMiddleware())

	_greeterHttpDelivery.NewGreeterHandler(r)
	_greeterGrpcDelivery.NewGreeterHandler(grpcServer)

	wrappedGrpc := grpcweb.WrapServer(grpcServer, _grpcwebMiddleware.CorsMiddleware())

	httpServer := http.Server{
		Addr: "0.0.0.0:3333",
		Handler: http.HandlerFunc(func(resp http.ResponseWriter, req *http.Request) {
			if wrappedGrpc.IsAcceptableGrpcCorsRequest(req) {
				wrappedGrpc.ServeHTTP(resp, req)
				return
			}
			if wrappedGrpc.IsGrpcWebRequest(req) {
				wrappedGrpc.ServeHTTP(resp, req)
				return
			}

			r.ServeHTTP(resp, req)
		}),
	}
	if err := httpServer.ListenAndServe(); err != nil {
		grpclog.Fatalf("failed starting http server: %v", err)
	}
}
