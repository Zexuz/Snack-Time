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

func (c client) GetSeriesById(id int) (*Series, error) {
	u := fmt.Sprintf("%s/api/series/%d?apikey=%s", c.baseUrl.String(), id, c.apiKey)

	r, err := c.httpClient.Get(u)
	if err != nil {
		return nil, err
	}

	b, err := ioutil.ReadAll(r.Body)
	defer r.Body.Close()

	var series *Series
	err = json.Unmarshal(b, &series)

	return series, err
}

func (c client) GetEpisodes(seriesId int) ([]Episode, error) {
	u := fmt.Sprintf("%s/api/episode?seriesId=%d&apikey=%s", c.baseUrl.String(), seriesId, c.apiKey)

	r, err := c.httpClient.Get(u)
	if err != nil {
		return nil, err
	}

	b, err := ioutil.ReadAll(r.Body)
	defer r.Body.Close()

	var episodes []Episode
	err = json.Unmarshal(b, &episodes)

	return episodes, err
}

func (c client) GetEpisodeFiles(seriesId int) ([]*EpisodeFile, error) {
	u := fmt.Sprintf("%s/api/episodefile?seriesId=%d&apikey=%s", c.baseUrl.String(), seriesId, c.apiKey)

	r, err := c.httpClient.Get(u)
	if err != nil {
		return nil, err
	}

	b, err := ioutil.ReadAll(r.Body)
	defer r.Body.Close()

	var episodeFile []*EpisodeFile
	err = json.Unmarshal(b, &episodeFile)

	return episodeFile, err
}

type ProviderClient interface {
	GetSeries() ([]Series, error)
	GetSeriesById(id int) (*Series, error)
	GetEpisodes(seriesId int) ([]Episode, error)
	GetEpisodeFiles(seriesId int) ([]*EpisodeFile, error)
}

func NewClient(apiKey string, baseUrl *url.URL) *client {

	c := &http.Client{
		Timeout: 15 * time.Second,
	}

	return &client{apiKey: apiKey, baseUrl: baseUrl, httpClient: c}
}
