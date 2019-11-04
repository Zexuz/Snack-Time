import React from 'react';
import Main from './pages/Main';
import Settings from './pages/Settings';
import MediaInfo from './components/MediaInfo';
import {
    BrowserRouter as Router,
    Route, Link
} from 'react-router-dom'
import {MediaInfo as Info, MediaType} from "./logic/media";

const App: React.FC = () => {
    const padding = {padding: 5};

    type mediaTypes = keyof typeof MediaType;

    function mediaInfoById(mediaType: mediaTypes, id: number): Info {
        // This will later be a fetch from a state or a store!
        return {
            description: "This is some description",
            id: id,
            title: "Some Intrestring title",
            type: MediaType[mediaType],
        }
    }

    return (
        <div>
            <Router>
                <div>
                    <div>
                        <Link style={padding} to="/">Home</Link>
                        <Link style={padding} to="/settings">Settings</Link>
                    </div>
                    <Route exact path="/" render={() => <Main/>}/>
                    <Route path="/settings" render={() => <Settings/>}/>
                    <Route exact path="/:mediaType/:id" render={({match}) =>
                        <MediaInfo info={mediaInfoById(match.params.mediaType, match.params.id)}/>
                    }/>
                </div>
            </Router>
        </div>
    )
};

export default App;
