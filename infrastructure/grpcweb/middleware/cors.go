package middleware

import "github.com/improbable-eng/grpc-web/go/grpcweb"

func CorsMiddleware() grpcweb.Option {
	return grpcweb.WithOriginFunc(func(origin string) bool {
		return true
	})
}
