using System;
using LocalNetflix.Protobuf.MediaPlayerModels;

namespace MediaHelper.MediaPlayerObserver
{
    internal static class EnumConverter
    {
        
        public static PlayingMediaInfoChanged.Types.MediaProperty Convert(this Property prop)
        {
            switch (prop)
            {
                case Property.File:
                    return PlayingMediaInfoChanged.Types.MediaProperty.File;
                case Property.State:
                    return PlayingMediaInfoChanged.Types.MediaProperty.State;
                case Property.Possition:
                    return PlayingMediaInfoChanged.Types.MediaProperty.Position;
                default:
                    throw new ArgumentOutOfRangeException(nameof(prop), prop, null);
            }
        }
        
        public static LocalNetflix.Protobuf.MediaPlayerModels.State Convert(this State state)
        {
            switch (state)
            {
                case State.Stoped:
                    return LocalNetflix.Protobuf.MediaPlayerModels.State.Stoped;
                case State.Playing:
                    return LocalNetflix.Protobuf.MediaPlayerModels.State.Playing;
                case State.Paused:
                    return LocalNetflix.Protobuf.MediaPlayerModels.State.Paused;
                case State.None:
                    return LocalNetflix.Protobuf.MediaPlayerModels.State.Unknown;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
        
    }
}