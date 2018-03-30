using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchView : MonoBehaviour {
    [SerializeField]
    Camera firstPCamera;
    [SerializeField]
    Camera thirdPCamera;
    private bool switchCam = false;

	// Use this for initialization
	void Start ()
    {
        firstPCamera.GetComponent<Camera>().enabled = false;
        thirdPCamera.GetComponent<Camera>().enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("t"))
        {
            switchCam = !switchCam;
        }

        if(switchCam == true)
        {
            firstPCamera.GetComponent<Camera>().enabled = true;
            thirdPCamera.GetComponent<Camera>().enabled = false;
        }
        else
        {
            firstPCamera.GetComponent<Camera>().enabled = false;
            thirdPCamera.GetComponent<Camera>().enabled = true;
        }
	}
}
