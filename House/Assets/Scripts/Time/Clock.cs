using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {
    private Timekeeper timekeeper;
    private DateTime _time;

	// Use this for initialization
	void Start () {
        timekeeper = GameObject.FindWithTag("Timekeeper").GetComponent<Timekeeper>();
        _time = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
       
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
}
