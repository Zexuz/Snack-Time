using System;
using MediaHelper.Protobuf.generated;

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
        
        public static Protobuf.generated.State Convert(this State state)
        {
            switch (state)
            {
                case State.Stoped:
                    return Protobuf.generated.State.Stoped;
                case State.Playing:
                    return Protobuf.generated.State.Playing;
                case State.Paused:
                    return Protobuf.generated.State.Paused;
                case State.None:
                    return Protobuf.generated.State.Unknown;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
        
    }
}