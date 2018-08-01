using System;
using System.Threading;
using System.Threading.Tasks;
using LocalNetflix.Protobuf.MediaPlayerModels;
using MpcHcObserver.Events;
using MPC_HC.Domain;

namespace MpcHcObserver
{
    public class Observer
    {
        public event PropertyChangedEventHandler<State>    StateChanged;
        public event PropertyChangedEventHandler<TimeSpan> PositionChanged;
        public event PropertyChangedEventHandler<string>   NewMediaFileLoaded;

        public TimeSpan UpdateFrequency { get; set; }

        private Info          _oldInfo, _newInfo;
        private MPCHomeCinema _mpchc;

        private bool   _isRunning;
        private Thread _thread;


        public Observer(MPCHomeCinema client)
        {
            _mpchc = client;
            UpdateFrequency = TimeSpan.FromSeconds(1);
        }

        public async Task Start()
        {
            _oldInfo = await _mpchc.GetInfo();
            _thread = new Thread(Run);

            _isRunning = true;
            _thread.Start();
        }

        public void Stop()
        {
            _isRunning = false;
            _thread.Join(TimeSpan.FromMilliseconds(500));
        }

        private async void Run()
        {
            while (_isRunning)
            {
                _newInfo = await _mpchc.GetInfo();

                if (_newInfo.State != _oldInfo.State)
                {
                    OnPropertyChanged(PlayingMediaInfoChanged.Types.MediaProperty.State);
                }

                if (_newInfo.Position != _oldInfo.Position)
                {
                    OnPropertyChanged(PlayingMediaInfoChanged.Types.MediaProperty.Position);
                }

                if (_newInfo.FileName != _oldInfo.FileName)
                {
                    OnPropertyChanged(PlayingMediaInfoChanged.Types.MediaProperty.File);
                }

                _oldInfo = _newInfo;
                await Task.Delay(UpdateFrequency);
            }
        }

        private void OnPropertyChanged(PlayingMediaInfoChanged.Types.MediaProperty propertyType)
        {
            var playingMediaInfoChanged = CreatePlayingMediaInfoChanged(_oldInfo, _newInfo, propertyType);

            switch (propertyType)
            {
                case PlayingMediaInfoChanged.Types.MediaProperty.State:
                    StateChanged?.Invoke(this, new PropertyChangedEventArgs(playingMediaInfoChanged));
                    break;
                case PlayingMediaInfoChanged.Types.MediaProperty.Position:
                    PositionChanged?.Invoke(this, new PropertyChangedEventArgs(playingMediaInfoChanged));
                    break;
                case PlayingMediaInfoChanged.Types.MediaProperty.File:
                    NewMediaFileLoaded?.Invoke(this, new PropertyChangedEventArgs(playingMediaInfoChanged));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static PlayingMediaInfoChanged CreatePlayingMediaInfoChanged(Info old, Info @new, PlayingMediaInfoChanged.Types.MediaProperty prop)
        {
            return new PlayingMediaInfoChanged
            {
                Property = prop,
                MediaInfo = FromInfo(@new),
                OldMediaInfo = FromInfo(old)
            };
        }

        private static PlayingMediaInfo FromInfo(Info info)
        {
            return new PlayingMediaInfo
            {
                FileName = info.FileName,
                State = ConvertEnum(info.State),
                Duration = info.Duration.TotalSeconds,
                Eplipsed = info.Position.TotalSeconds
            };
        }

        private static LocalNetflix.Protobuf.MediaPlayerModels.State ConvertEnum(State state)
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