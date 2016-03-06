using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {
    private Timekeeper timekeeper;
    private DateTime _time;
	// Use this for initialization
	void Start () {
        timekeeper = GameObject.FindWithTag("Timekeeper").GetComponent<Timekeeper>();
        _time = timekeeper.getTime();
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    public void changeTime(bool clockWise)
    {
        timekeeper.setTime(clockWise);
        _time = timekeeper.getTime();
        Debug.Log("time is now " + _time);
    }
}
