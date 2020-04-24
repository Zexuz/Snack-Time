package grpc

import (
	"context"
	"fmt"
	"google.golang.org/grpc"
	pb "snack-time/echo_service"
)

type greeterServer struct {
}

func NewGreeterHandler(s *grpc.Server) {
	pb.RegisterGreeterServer(s, &greeterServer{})
}

func (g greeterServer) SayHello(ctx context.Context, r *pb.HelloRequest) (*pb.HelloReply, error) {
	return &pb.HelloReply{Message: fmt.Sprintf("Hello %s %s", r.Name, r.LastName)}, nil
}
