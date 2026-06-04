using System.Collections.Generic;

public enum EventResult
{
    Continue,
    Break
}

public delegate EventResult EventHandler<T>(T data);

internal sealed record Subscription<T>(EventHandler<T> Handler, int Priority);

public sealed class Event<T>
{
    private readonly List<Subscription<T>> handlers = [];

    public Event()
    {
        handlers = [];
    }

    public void Subscribe(EventHandler<T> h, int priority = 0)
    {
        handlers.Add(new Subscription<T>(h, priority));

        handlers.Sort(static (a, b) => b.Priority.CompareTo(a.Priority));
    }

    public void Unsubscribe(EventHandler<T> h)
    {
        for (int i = handlers.Count - 1; i >= 0; i--)
        {
            if (handlers[i].Handler == h)
            {
                handlers.RemoveAt(i);
            }
        }
    }

    public EventResult Trigger(T data)
    {
        foreach (var h in handlers)
        {
            var result = h.Handler(data);

            if (result == EventResult.Break)
            {
                return EventResult.Break;
            }
        }

        return EventResult.Continue;
    }
}

public class Events
{
    private class Storage<T>
    {
        public static readonly Event<T> Event = new();
    }

    public Event<T> Get<T>() => Storage<T>.Event;
}