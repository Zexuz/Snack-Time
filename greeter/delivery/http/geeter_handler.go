package http

import (
	"fmt"
	"github.com/go-chi/chi"
	"github.com/go-chi/render"
	"net/http"
	infra "snack-time/infrastructure/http"
)

type GreeterHandler struct {
}

type EchoResponse struct {
	Data string `json:"data"`
}

type EchoRequest struct {
	Name string `json:"name"`
}

func NewGreeterHandler(r *chi.Mux) {
	r.Get("/api/v1/hello", getHelloText)
	r.Post("/api/v1/echo", echo)
}

func echo(w http.ResponseWriter, r *http.Request) {
	data := &EchoRequest{}
	if err := render.Bind(r, data); err != nil {
		render.Render(w, r, infra.ErrInvalidRequest(err))
		return
	}

	render.Status(r, http.StatusCreated)
	render.Render(w, r, NewEchoResponse(data))
}

func getHelloText(w http.ResponseWriter, r *http.Request) {
	render.Status(r, http.StatusOK)
	render.JSON(w, r, "Hello, World!")
}

func NewEchoResponse(req *EchoRequest) *EchoResponse {
	resp := &EchoResponse{
		Data: fmt.Sprintf("Hello %s", req.Name),
	}
	return resp
}

func (e EchoRequest) Bind(r *http.Request) error {
	return nil
}

func (rd *EchoResponse) Render(w http.ResponseWriter, r *http.Request) error {
	return nil
}
