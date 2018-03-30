using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Code used from CP Test (Youtube tutorial)

public class Character_movement : MonoBehaviour
{
    public float speed = 6.0f;
    public float rotateSpeed = 3.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    public Text countText;
    public Text winText;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private int jumps;

    private int count; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButtonDown("Fire1"))
            {
                moveDirection.y = jumpSpeed;
            }
            jumps = 0;
        }
        else
        {
            moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= speed;
            moveDirection.z *= speed;
            if (Input.GetButtonDown("Fire1") && jumps < 1)
            {
                moveDirection.y = jumpSpeed;
                jumps++;
            }
        }

        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
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

    void SetCountText ()
    {
        countText.text = "Yen: " + count.ToString();
        if (count >= 160)
        {
            winText.text = "You Win!";
        }
    }
}