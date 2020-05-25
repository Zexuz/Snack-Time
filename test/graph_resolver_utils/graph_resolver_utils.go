package graph_resolver_utils

import (
	"encoding/json"
	"flag"
	"github.com/graphql-go/graphql"
	"io/ioutil"
	"log"
	"os"
	"snack-time/ineternal/media_provider/sonarr"
	"testing"
)

var (
	Update = flag.Bool("update", false, "Update the golden files of this test")
)

type ResolveTest struct {
	Name     string
	Golden   string
	Args     graphql.ResolveParams
	Mock     sonarr.ProviderClient
	Resolver func(client sonarr.ProviderClient) graphql.FieldResolveFn
}

func GenerateJSON(v interface{}) string {
	rJSON, err := json.MarshalIndent(v, "", "\t")
	if err != nil {
		log.Fatalf("failed to create json: %v", err)
	}

	return string(rJSON)
}

func GoldenValue(t *testing.T, goldenFile string, actual interface{}, update bool) string {
	t.Helper()
	goldenPath := "testdata/" + goldenFile + ".golden"

	if _, err := os.Stat("testdata"); os.IsNotExist(err) {
		err := os.Mkdir("testdata", 0755)
		if err != nil {
			t.Fatalf("Can't create folder: %s", err)
		}
	}

	if update {
		actualJson := GenerateJSON(actual)
		err := ioutil.WriteFile(goldenPath, []byte(actualJson), 0755)
		if err != nil {
			t.Fatalf("Error writing to file %s: %s", goldenPath, err)
		}

		return actualJson
	}

	content, err := ioutil.ReadFile(goldenPath)
	if err != nil {
		t.Fatalf("Error opening file %s: %s", goldenPath, err)
	}
	return string(content)
}
