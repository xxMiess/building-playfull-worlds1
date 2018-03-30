using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//movement code used from Randy Paulus G&I1C.
//Text code used from tutorial "roll a ball"

public class PcController : MonoBehaviour {

	//Creates the variables
	public float forwardMoveSpeed = 1f;
	public float sidewaysMoveSpeed = 1f;

    public Text countText;
    public Text winText;

    private int count;

    //Runs at start
    void Start (){
		Cursor.lockState = CursorLockMode.Locked;
        count = 0;
        SetCountText();
        winText.text = "";
    }

	//Updates every Frame
	void FixedUpdate (){
		//Horizontal and Vertical Movement modified by movespeed variables
		transform.Translate (forwardMoveSpeed * Input.GetAxis ("Vertical") * Time.deltaTime, 0f, sidewaysMoveSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime);

		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}

		// Exit Game in scenes where UI isn't implemented yet
		if (Input.GetKeyDown("tab")){
			Application.Quit ();
		}
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable_coin"))
        {
            other.gameObject.SetActive(false);
            count = count + 5;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Yen: " + count.ToString();
        if (count >= 160)
        {
            winText.text = "You Win!";
        }
    }
}
