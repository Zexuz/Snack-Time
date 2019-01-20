using System;

namespace Mpv.JsonIpc
{
    public class MessageReceivedEventArg : EventArgs
    {
        public string Value { get; }

        public MessageReceivedEventArg(string message)
        {
            Value = message;
        }
    }
}