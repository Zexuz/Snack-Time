import React from "react";
import {MediaList,PlayableMediaList} from "../components/MediaList";
import {MediaType} from "../logic/media";

const Main: React.FC = () => {

    const renderLatest = () => {
        return <PlayableMediaList title={"Latest Downloaded"} mediaList={
            [
                {title: "Silicon valley S06E02 - Blood money", type: MediaType.Series, id: 1, mediaId: 201},
                {title: "The Rockie S02E06 - Fallout", type: MediaType.Series, id: 2, mediaId: 202},
                {title: "Mr. Robot S04E04 - Not Found", type: MediaType.Series, id: 3, mediaId: 203},
            ]
        }/>
    };


    const renderOtherUnwatched = () => {
        return <PlayableMediaList title={"Other Unwatched Episodes"} mediaList={
            [
                {title: "Titans S02E02 - Some title", type: MediaType.Series, id: 4, mediaId: 204},
                {title: "Jack Ryan S02E01 - Interesting title", type: MediaType.Series, id: 5, mediaId: 205},
                {title: "Superstore S0XE0Y - Other title", type: MediaType.Series, id: 6, mediaId: 206},
            ]
        }/>
    }

    //This is something other than "Media", Maybe it's a "MediaContainer"?
    const renderBrowser = () => {
        return (
            <MediaList title={"Other Unwatched Episodes"} mediaList={
                [
                    {title: "Billions", type: MediaType.Series, id: 7},
                    {title: "Modern Family", type: MediaType.Series, id: 8},
                    {title: "The 100", type: MediaType.Series, id: 9},
                    {title: "The expanse", type: MediaType.Series, id: 10},
                    {title: "Taboo", type: MediaType.Series, id: 11},
                    {title: "Lucifer", type: MediaType.Series, id: 12},
                    {title: "Spider-man: Far from home", type: MediaType.Movie, id: 1},
                ]
            }/>
        )
    }


    return (
        <span>
        <h1>Snack-Time</h1>
            {renderLatest()}
            {renderOtherUnwatched()}
            {renderBrowser()}
        </span>
    )
};

export default Main;
