using System;
using System.Threading;
using System.Threading.Tasks;
using MpcHcObserver.Events;
using MPC_HC.Domain;

namespace MpcHcObserver
{
    public class Observer
    {
        public event GenericPropertyChangedEventHandler<State>    StateChanged;
        public event GenericPropertyChangedEventHandler<TimeSpan> PositionChanged;
        public event GenericPropertyChangedEventHandler<string>   NewMediaFileLoaded;

        public TimeSpan UpdateFrequency { get; set; }
        public string   MpcUrl          { get; set; }

        private Info          _oldInfo, _newInfo;
        private MPCHomeCinema _mpchc;

        private bool   _isRunning;
        private Thread _thread;


        public Observer()
        {
            UpdateFrequency = TimeSpan.FromSeconds(1);
            MpcUrl = "http://localhost:13579";
        }

        public async Task Start()
        {
            _mpchc = new MPCHomeCinema(MpcUrl);
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
                    OnPropertyChanged(Property.State);
                }

                if (_newInfo.Position != _oldInfo.Position)
                {
                    OnPropertyChanged(Property.Position);
                }

                if (_newInfo.FileName != _oldInfo.FileName)
                {
                    OnPropertyChanged(Property.File);
                }

                _oldInfo = _newInfo;
                await Task.Delay(UpdateFrequency);
            }
        }

        private void OnPropertyChanged(Property propertyType)
        {
            switch (propertyType)
            {
                case Property.State:
                    StateChanged?.Invoke(this, new GenericPropertyChangedEventArgs<State>(_oldInfo.State,_newInfo.State,propertyType));
                    break;
                case Property.Position:
                    PositionChanged?.Invoke(this, new GenericPropertyChangedEventArgs<TimeSpan>(_oldInfo.Position,_newInfo.Position,propertyType));
                    break;
                case Property.File:
                    NewMediaFileLoaded?.Invoke(this, new GenericPropertyChangedEventArgs<string>(_oldInfo.FileName,_newInfo.FileName,propertyType));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}