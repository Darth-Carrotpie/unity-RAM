using UnityEngine;

public class TimeEventGenerator : MonoBehaviour {
    public float gameSpeed = 1f;
    public static long turnCounter;
    public float showTurn;
    float counter;
    float oldSpeed;

    void Start () {
        EventManager.StartListening(EventName.GameSpeedEvent, ChangeGameSpeed);
        EventManager.StartListening(EventName.PauseGameEvent, Pause);
        EventManager.StartListening(EventName.UnpauseGameEvent, Unpause);
    }
	void Update () {
        showTurn = turnCounter;
        counter += Time.deltaTime;
        if(gameSpeed > 0 && counter > gameSpeed )
        {
            turnCounter += 1;
            counter = 0;
            EventManager.TriggerEvent(EventName.TurnEvent, BookerMessage.Write().WithTurnCounter(turnCounter));
        }
        if (Input.GetKeyUp("space")) {
            if (gameSpeed > 0) {
                EventManager.TriggerEvent(EventName.PauseGameEvent, BookerMessage.Write());
            } else {
                EventManager.TriggerEvent(EventName.UnpauseGameEvent, BookerMessage.Write());
            }
        }
	}

    private void ChangeGameSpeed(BookerMessage msg) {
        if (msg.gameSpeed < 0 || msg.gameSpeed > 10) {
            return;
        }
        if (msg.gameSpeed == 0){
            EventManager.TriggerEvent(EventName.PauseGameEvent, BookerMessage.Write());
            return;
        }
        if (gameSpeed == 0){
            EventManager.TriggerEvent(EventName.UnpauseGameEvent, BookerMessage.Write());
        }
        gameSpeed = msg.gameSpeed;
    }

    private void Pause(BookerMessage arg0) {
        oldSpeed = gameSpeed;
        gameSpeed = 0;
    }

    private void Unpause(BookerMessage arg0) {
        if (gameSpeed == 0)
        {
            gameSpeed = oldSpeed;
        }
    }
}
