using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Timekeeper : MonoBehaviour {
    private DateTime _time;
    private GameObject[] clocks;
	// Use this for initialization
	void Start ()
    {
        clocks = GameObject.FindGameObjectsWithTag("Clock");
        _time = DateTime.Now;
        Debug.Log(_time);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public DateTime getTime()
    {
        return _time;
    }

    public void setTime(bool clockWise)
    {
        if (clockWise)
        { 
            _time = _time.AddMinutes(1.0f);
            foreach(GameObject obj in clocks)
            {
                obj.SendMessage("setTime", _time);
            }
        }
        else
        {
            _time = _time.AddMinutes(-1.0f);
            foreach (GameObject obj in clocks)
            {
                obj.SendMessage("setTime", _time);
            }
        }
    }
}
