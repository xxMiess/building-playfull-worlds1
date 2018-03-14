using UnityEngine;
using System.Collections;

public class Fly_movement : MonoBehaviour {

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if(Input.GetKey("space"))
        {
            transform.Translate(0, y: 0.3f, z: 0);
        }

        transform.Translate(0, -0.1f, 0);
    }
}
