using Spine;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

//https://daekyoulibrary.tistory.com/entry/Unity-%EC%9D%B4%EB%B2%A4%ED%8A%B8-%EC%A3%BC%EB%8F%84%EC%A0%81-%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%98%EB%B0%8D-Event-Driven-Programming-%EC%9D%B8%ED%84%B0%ED%8E%98%EC%9D%B4%EC%8A%A4%EB%A5%BC-%EC%9D%B4%EC%9A%A9%ED%95%9C-%EB%B0%A9%EB%B2%95
public enum EnEventType
{
    GameInitialize,
    GameEnd,
    Restart,
    End,
    Length
}

public class EventManager : Singleton<EventManager>
{
    public delegate void OnEvent(EnEventType eventType, Component Sender, object Param = null);
    private Dictionary<EnEventType, List<OnEvent>> Listeners = new Dictionary<EnEventType, List<OnEvent>>();

    public void AddListener(EnEventType eventType, OnEvent listener)
    {
        List<OnEvent> ListenerList = null;
        if (Listeners.TryGetValue(eventType, out ListenerList))
        {
            ListenerList.Add(listener);
            return;
        }

        ListenerList = new List<OnEvent>();
        ListenerList.Add(listener);
        Listeners.Add(eventType, ListenerList);
    }

    public void Notification(EnEventType eventType, Component Sender, object param = null)
    {
        List<OnEvent> ListenerList = null;
        if (Listeners.TryGetValue(eventType, out ListenerList))
            return;

        for (int i = 0; i < ListenerList.Count; i++)
            ListenerList?[i](eventType, Sender, param);
    }

    public void RemoveEvent(EnEventType eventType) => Listeners.Remove(eventType);

    public void RemoveRedundancies()
    {
        Dictionary<EnEventType, List<OnEvent>> newListeners = new Dictionary<EnEventType, List<OnEvent>>();

        foreach (KeyValuePair<EnEventType, List<OnEvent>> Item in Listeners)
        {
            for (int i = Item.Value.Count - 1; i >= 0; i--)
            {
                if (Item.Value[i].Equals(null))
                    Item.Value.RemoveAt(i);
            }

            if (Item.Value.Count > 0)
                newListeners.Add(Item.Key, Item.Value);
        }

        Listeners = newListeners;
    }

    void OnLevelWasLoaded()
    {
        RemoveRedundancies();
    }

}