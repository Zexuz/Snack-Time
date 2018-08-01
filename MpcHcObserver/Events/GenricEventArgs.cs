using System;
using LocalNetflix.Protobuf.MediaPlayerModels;

namespace MpcHcObserver.Events
{
    public delegate void PropertyChangedEventHandler<T>(object sender, PropertyChangedEventArgs e);

    public class PropertyChangedEventArgs:EventArgs
    {

        public PlayingMediaInfoChanged PlayingMediaInfoChanged { get; }

        public PropertyChangedEventArgs(PlayingMediaInfoChanged playingMediaInfoChanged)
        {
            PlayingMediaInfoChanged = playingMediaInfoChanged;
        }
        
        
    }

}