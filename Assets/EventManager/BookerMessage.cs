using UnityEngine;
using System.Collections;

public class BookerMessage {
    
    /*public float educationIncrement;

    public float gendarmeActivityIncrement;

    public float nationalityIncrement;

    public float demandIncrement;

    public Element.Booker booker;

    public Structure structure;

    public Zone zone;

    public BookerCommand bookerCommand;

    public long turnCounter;

    public float radiusOfEffect;

    public Vector2 pointOfOrigin;

    public EventName zoneEventName;
    */
    public float gameSpeed;
    /*
    public float price;

    public float income;

    public string message;

    public Language language;
    */
    private BookerMessage(){}

    public static BookerMessage Write(){
        return new BookerMessage();
    }

    public BookerMessage WithBookIncrement(float value) {
       // educationIncrement = value;
        return this;
    }

    public BookerMessage WithGendarmeActivityIncrement(float value) {
        //gendarmeActivityIncrement = value;
        return this;
    }

    public BookerMessage WithNationalityIncrement(float value) {
        //nationalityIncrement = value;
        return this;
    }

    public BookerMessage WithBooker(/*Element.Booker value*/) {
        //booker = value;
        return this;
    }

    public BookerMessage WithStructure(/*Structure value*/) {
        //structure = value;
        return this;
    }

    public BookerMessage WithBookerCommand(/*BookerCommand value*/) {
        //bookerCommand = value;
        return this;
    }

    public BookerMessage WithTurnCounter(long value) {
        //turnCounter = value;
        return this;
    }

    public BookerMessage WithDemandIncrement(float value) {
        //demandIncrement = value;
        return this;
    }

    public BookerMessage WithRadiusOfEffect(float value) {
        //radiusOfEffect = value;
        return this;
    }

    public BookerMessage WithPointOfOrigin(Vector2 value) {
        //pointOfOrigin = value;
        return this;
    }

    public BookerMessage WithZone(/*Zone value*/)
    {
        //zone = value;
        return this;
    }

    public BookerMessage WithZoneEventName(EventName value) {
        //zoneEventName = value;
        return this;
    }

    public BookerMessage WithGameSpeed(float value) {
        //gameSpeed = value;
        return this;
    }

    public BookerMessage WithPrice(float value) {
       // price = value;
        return this;
    }

    public BookerMessage WithIncome(float value) {
        //income = value;
        return this;
    }

    public BookerMessage WithMessage(string value) {
        //message = value;
        return this;
    }

    public BookerMessage WithLanguage(/*Language value*/)
    {
        //language = value;
        return this;
    }
}


