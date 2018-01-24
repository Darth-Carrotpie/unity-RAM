using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Test1()
    {
        EventManager.TriggerEvent(EventName.BookerStory, BookerMessage.Write());
    }
    public void Test2()
    {
        EventManager.TriggerEvent(EventName.StructureStory, BookerMessage.Write());
    }
    public void Test3()
    {
        EventManager.TriggerEvent(EventName.GendarmeActivityStory, BookerMessage.Write());
    }
}
