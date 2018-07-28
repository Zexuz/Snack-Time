using System;

namespace MpcHcObserver.Events
{
    public delegate void GenericPropertyChangedEventHandler<T>(object sender, GenericPropertyChangedEventArgs<T> e);

    public class GenericPropertyChangedEventArgs<T>:EventArgs
    {
        public T OldValue { get; }
        public T NewValue { get; }
        public Property Property { get; }

        public GenericPropertyChangedEventArgs(T oldValue, T newValue, Property property)
        {
            OldValue = oldValue;
            NewValue = newValue;
            Property = property;
        }
        
    }

    public enum Property
    {
        State,
        Position,
        File
    }

}