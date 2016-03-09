using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
    
    [SerializeField] public Transform player;
    [SerializeField] public float openDoorRange = 4.0f;

    private bool doorCanMove = false;
    private bool doorClosed = true;
    private bool doorStopCheck = false;
    private float doorDistance;

    public float rotationDegreesPerSecond = 45.0f;
    public const float rotationDegreesAmount = 91.0f;
    private float totalRotation = 0;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
                
        // calculate distance between player and door
        doorDistance = Vector3.Distance(transform.position, player.position);

        // check for various door states before proceeding
        CheckDoorState();

        // while amount rotated is less than total, rotate the door
        if (Mathf.Abs(totalRotation) < Mathf.Abs(rotationDegreesAmount) && Input.GetKey("e") && doorCanMove == true)
        {            
            if (doorClosed == true)
            {
                SwingOpen();
            }
            else if (doorClosed == false)
            {
                SwingClosed();
            }

            if (Mathf.Abs(totalRotation) >= Mathf.Abs(rotationDegreesAmount))
            {                
                if (doorClosed == true)
                {
                    doorClosed = false;
                    doorStopCheck = true;
                }
                else if (doorClosed == false)
                {
                    doorClosed = true;
                    doorStopCheck = true;
                }
                totalRotation = 0;
            }
        }
    }


    void CheckDoorState()
    {
        if (doorDistance > openDoorRange)
        {
            doorCanMove = false;
        }
        if (doorDistance <= openDoorRange && doorStopCheck == false)
        {
            doorCanMove = true;
        }
        if (doorDistance > openDoorRange && doorStopCheck == true)
        {
            doorCanMove = false;
            doorStopCheck = false;
        }
        if (doorDistance <= openDoorRange && doorStopCheck == true && Input.GetKey("e"))
        {
            doorCanMove = false;
        }
        if (doorDistance <= openDoorRange && doorStopCheck == true && !Input.GetKey("e"))
        {
            doorCanMove = true;
            doorStopCheck = false;
        }
    }

    // opens door over time
    void SwingOpen()
    {
        float currentAngle = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * -rotationDegreesPerSecond), Vector3.up);
        totalRotation += Time.deltaTime * rotationDegreesPerSecond;
    }

    // closes door over time
    void SwingClosed()
    {
        float currentAngle = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * rotationDegreesPerSecond), Vector3.up);
        totalRotation += Time.deltaTime * rotationDegreesPerSecond;
    }
}



//////////////////////////////////////////////////////////////////////
//openTo.transform.RotateAround(openTo.transform.position, transform.up, -openAngle);
//openTo.transform.rotation = Quaternion.Lerp(openFrom.rotation, openTo.rotation, Time.deltaTime * openSpeed);
//////////////////////////////////////////////////////////////////////



//////////////////////////////////////////////////////////////////////
//openTo.transform.RotateAround(openTo.transform.position, transform.up, openAngle);
//openTo.transform.rotation = Quaternion.Lerp(openFrom.rotation, openTo.rotation, Time.deltaTime * openSpeed);
//////////////////////////////////////////////////////////////////////