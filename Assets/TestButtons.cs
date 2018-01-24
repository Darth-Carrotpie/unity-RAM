using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButtons : MonoBehaviour {

    

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //music testing:
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
    //sound fx testing:
    public void TestSound1()
    {
        EventManager.TriggerEvent(EventName.StructureSelected, BookerMessage.Write());
    }

}
