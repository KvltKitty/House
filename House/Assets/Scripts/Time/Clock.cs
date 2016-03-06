using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {
    private Timekeeper timekeeper;
    private DateTime _time;
    private Transform hourHand, minuteHand;

	// Use this for initialization
	void Start () {
        timekeeper = GameObject.FindWithTag("Timekeeper").GetComponent<Timekeeper>();
        _time = DateTime.Now;
        minuteHand = transform.GetChild(0).transform.GetChild(0);
        hourHand = transform.GetChild(0).transform.GetChild(1);
    }
	
	// Update is called once per frame
	void Update ()
    {
        rotateMinuteHand();
        rotateHourHand();
    }

    public void changeTime(bool clockWise)
    {
        timekeeper.setTime(clockWise);
        Debug.Log("time is now " + _time);
    }

    public void setTime(DateTime time)
    {
        _time = time;
    }

    public DateTime getTime()
    {
        return _time;
    }

    void rotateMinuteHand()
    {
        minuteHand.localEulerAngles = new Vector3((_time.Minute * 6), 0.0f, 0.0f);
    }

    void rotateHourHand()
    {
        hourHand.localEulerAngles = new Vector3((_time.Hour * 30), 0.0f, 0.0f);
    }
}
