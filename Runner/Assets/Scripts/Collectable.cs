using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {      
    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        AudioSource pickupsound = GetComponent<AudioSource>();
        pickupsound.Play();

        if (other.gameObject.CompareTag("Collectable_coin"))
        {
            other.gameObject.SetActive(false);
            pickupsound.enabled = true;
            pickupsound.Play();
        }
    }
}
