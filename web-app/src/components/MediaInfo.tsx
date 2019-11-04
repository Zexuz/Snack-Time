import React from "react";
import {MediaInfo as Info} from "../logic/media";

const MediaInfo: React.FC<{info:Info}> = ({info}) => {
    return (
        <span>
            <h1>{info.title}</h1>
            <h3>{info.description}</h3>
            <button>Play media</button>
            <div>
                <p>Here will episodes be listed if this is a series</p>
            </div>
        </span>
    )
};

export default MediaInfo
