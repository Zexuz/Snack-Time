import React from "react";
import {Media, PlayableMedia} from "../logic/media";
import {Link} from 'react-router-dom'

export const PlayableMediaList: React.FC<{ title: string, mediaList: PlayableMedia[] }> = ({mediaList, title}) => {

    const renderList = () => {
        return mediaList.map(value => <li><Link to={`/${value.type}/${value.id}`}>{value.title}</Link></li>)
    }

    return (
        <span>
            <h2>{title}</h2>
             <ul>
                 {renderList()}
            </ul>
        </span>
    )
};

export const MediaList: React.FC<{ title: string, mediaList: Media[] }> = ({mediaList, title}) => {

    const renderList = () => {
        return mediaList.map(value => <li><Link to={`/${value.type}/${value.id}`}>{value.title}</Link></li>)
    }

    return (
        <span>
            <h2>{title}</h2>
             <ul>
                 {renderList()}
            </ul>
        </span>
    )
};
