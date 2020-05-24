package sonarr

import (
	"encoding/json"
	"fmt"
	"io/ioutil"
	"net/http"
	"net/url"
	"time"
)

type client struct {
	apiKey     string
	baseUrl    *url.URL
	httpClient *http.Client
}

func (c client) GetSeries() ([]Series, error) {
	u := fmt.Sprintf("%s/api/series?apikey=%s", c.baseUrl.String(), c.apiKey)

	r, err := c.httpClient.Get(u)
	if err != nil {
		return nil, err
	}

	b, err := ioutil.ReadAll(r.Body)
	defer r.Body.Close()

	var series []Series
	err = json.Unmarshal(b, &series)

	return series, err
}

type ProviderClient interface {
	GetSeries() ([]Series, error)
}

func NewClient(apiKey string, baseUrl *url.URL) *client {

	c := &http.Client{
		Timeout: 15 * time.Second,
	}

	return &client{apiKey: apiKey, baseUrl: baseUrl, httpClient: c}
}
