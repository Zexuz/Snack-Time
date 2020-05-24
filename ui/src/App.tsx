import React from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    useParams,
    Link
} from "react-router-dom";
import {useMutation, useQuery,} from "@apollo/client";

import {
    GetSeriesQuery,
    GetSeriesByIdQuery,
    GetSeriesByIdQueryVariables,
    PlayFileMutation,
    PlayFileMutationVariables
} from "./generated/graphql";
import './App.css';
import GET_SERIES from './queries/getSeries.graphql';
import GET_SERIES_BY_ID from './queries/getSeriesById.graphql';
import PLAY_FILE from './queries/playFile.graphql';
import {sortByStringValue} from "./utils";

console.log(GET_SERIES);

function Settings() {
    return <p>Settings</p>
}

function SeriesDetails() {
    let {id} = useParams();
    const {loading, error, data} = useQuery<GetSeriesByIdQuery, GetSeriesByIdQueryVariables>(GET_SERIES_BY_ID, {variables: {seriesId: id}});
    const [playFile] = useMutation<PlayFileMutation, PlayFileMutationVariables>(PLAY_FILE);

    if (loading || !data?.seriesById) return <p>Loading...</p>;
    if (error) return <p>Error :(</p>;

    const handleOnClick = async (filepath?: string | null) => {
        if (!filepath) return

        await playFile({variables: {filepath}})
    }


    return <>
        <h2>{data.seriesById.title}</h2>

        {data.seriesById.seasons.map((season, index) =>
            <div key={`s${season.number}`}>
                <h3>Season: {season.number}</h3>
                <ul>
                    {season.episodes.map((episode, index1) =>
                        <li key={`s${season.number}e${episode.number}`}>
                            <button
                                disabled={!episode.filepath}
                                onClick={() => handleOnClick(episode.filepath)}
                            >
                                {episode.title}
                            </button>
                        </li>
                    )}
                </ul>
            </div>
        )}
    </>
}

function App() {

    return (
        <Router>
            <div>
                <nav>
                    <ul>
                        <li>
                            <Link to="/">List series</Link>
                        </li>

                        <li>
                            <Link to="/settings">Users</Link>
                        </li>
                    </ul>
                </nav>

                <Switch>
                    <Route path="/settings">
                        <Settings/>
                    </Route>

                    <Route path="/series/:id">
                        <SeriesDetails/>
                    </Route>

                    <Route path="/">
                        <ListSeries/>
                    </Route>
                </Switch>
            </div>
        </Router>
    )
}

function ListSeries() {
    const {loading, error, data} = useQuery<GetSeriesQuery>(GET_SERIES);

    if (loading || !data) return <p>Loading...</p>;
    if (error) return <p>Error :(</p>;

    return (
        <div>
            {sortByStringValue(data.series, 'title').map((series, index) =>
                <p>
                    <Link key={`series-list-${index}`} to={`/series/${series.id}`}>{series.title}</Link>
                </p>
            )}
        </ div>
    );
}

export default App;
