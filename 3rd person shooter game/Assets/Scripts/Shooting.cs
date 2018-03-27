using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask mask;
    //public Transform player;

	// Use this for initialization
	void Start () {
		if (cam == null)
        {
            Debug.LogError("firstPCamera");
            this.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("f"))
        {
            Shoot();
        }
	}

    void Shoot ()
    {
        //player = GameObject.FindWithTag("Player").transform;

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hit, 10f, mask))
        {
            Debug.Log(hit.collider.name);
            Debug.DrawRay(cam.transform.position, cam.transform.forward * 10f, Color.green, 5.0f);
        }
    }
}
