using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public interface IEvent
{
}

public enum EventResult
{
    Continue,
    Break
}

public delegate EventResult EventHandler<T>(T eventData) where T : IEvent;

internal sealed record class Subscription(Delegate Handler, int Priority);

public sealed class EventBus
{
    private readonly Dictionary<Type, List<Subscription>> subs;

    public EventBus()
    {
        subs = [];
    }

    public void Subscribe<T>(EventHandler<T> h, int p = 0) where T : IEvent
    {
        var type = typeof(T);

        if (!subs.TryGetValue(type, out var list))
        {
            list = [];
            subs[type] = list;
        }

        list.Add(new Subscription(h, p));

        list.Sort(static (a, b) => b.Priority.CompareTo(a.Priority));
    }

    public void Unsubscribe<T>(EventHandler<T> h) where T : IEvent
    {
        if (!subs.TryGetValue(typeof(T), out var list))
        {
            return;
        }

        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (ReferenceEquals(list[i].Handler, h))
            {
                list.RemoveAt(i);
            }
        }
    }

    public EventResult Trigger<T>(T eventData) where T : IEvent
    {
        if (!subs.TryGetValue(typeof(T), out var list))
        {
            return EventResult.Continue;
        }

        foreach (var s in list)
        {
            var h = (EventHandler<T>)s.Handler;
            var result = h(eventData);

            if (result == EventResult.Break)
            {
                return EventResult.Break;
            }
        }

        return EventResult.Continue;
    }
}