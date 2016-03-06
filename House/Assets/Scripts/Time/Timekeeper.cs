using UnityEngine;
using System.Collections;
using System;

public class Timekeeper : MonoBehaviour {
    private DateTime _time;
	// Use this for initialization
	void Start ()
    {
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
        }
        else
        {
            _time = _time.AddMinutes(-1.0f);
            //remove minutes
        }
    }
}
