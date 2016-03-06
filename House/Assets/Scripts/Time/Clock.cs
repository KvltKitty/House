using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {
    private Timekeeper timekeeper;
    private DateTime _time;
    private Transform hourHand, minuteHand;

	void Start ()
    {
        //gets Timekeeper component from timekeeper so we can call its public functions later
        timekeeper = GameObject.FindWithTag("Timekeeper").GetComponent<Timekeeper>();

        //sets time to current time in the real world
        _time = DateTime.Now;

        //gets transforms of the minute and hour hand objects for easy rotation later
        minuteHand = transform.GetChild(0).transform.GetChild(0);
        hourHand = transform.GetChild(0).transform.GetChild(1);
    }
	
	void Update ()
    {
        updateClockHands();
    }

    public void changeTime(bool clockWise)
    {
        //calls Timekeeper function to increase or decrease minute time offset from real world time
        timekeeper.setTime(clockWise);
    }

    public void setTime(DateTime time)
    {
        _time = time;
    }

    //gets the clocks current time (should be same as houseTime in Timekeeper.cs)
    public DateTime getTime()
    {
        return _time;
    }

    //this function updates the rotation of the clock hands
    void updateClockHands()
    {
        minuteHand.localEulerAngles = new Vector3((_time.Minute * 6) + (_time.Second * 0.1f) + (_time.Millisecond * 0.0001f), 0.0f, 0.0f);
        hourHand.localEulerAngles = new Vector3((_time.Hour * 30) + (_time.Minute * 0.5f) + (_time.Second * 0.0083f), 0.0f, 0.0f);
    }
}
