using UnityEngine;

public class Fly_movement : MonoBehaviour {

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    public float gravity = 0.5f;
    public Rigidbody rigidbody;
    float translation;
    float rotation;

    private void Start()
    {
        
    }

    void Update()
    {
        translation = Input.GetAxis("Vertical") * speed;
        rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        //transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if(Input.GetKey("space"))
        {
            transform.Translate(0, y: 0.3f, z: 0);
        }

        //transform.Translate(0, -0.1f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        AudioSource pickupsound = other.GetComponent<AudioSource>();
        pickupsound.Play();

        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }
    }

        private void FixedUpdate()
    {
        rigidbody.MovePosition( transform.position + transform.forward* translation + -transform.up * gravity * Time.deltaTime);
        //rigidbody.MovePosition(transform.position + );
    }
}
