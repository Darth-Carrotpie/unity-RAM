using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

    private Dictionary <EventName, BookerUnityEvent> eventDictionary;

    private static EventManager eventManager;

    public static EventManager instance {
        get {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof (EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    void Init() {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<EventName, BookerUnityEvent>();
        }
    }

    public static void StartListening(EventName eventName, UnityAction<BookerMessage> listener) {
        BookerUnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new BookerUnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(EventName eventName, UnityAction<BookerMessage> listener) {
        if (eventManager == null) return;
        BookerUnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(EventName eventName, BookerMessage message) {
        //Debug.Log("Triggered " + eventName);
        BookerUnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(message);
        }
    }
}