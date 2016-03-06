using UnityEngine;
using System.Collections;

public class BlobMovement : MonoBehaviour {

    Rigidbody2D rigidBody;
    public float blobSpeed;

    Vector2 screenSize;


    // Use this for initialization
    void Start () {
        screenSize.y = Camera.main.orthographicSize;     // half screen height
        screenSize.x = screenSize.y * Camera.main.aspect; // half screen width

        rigidBody = GetComponent<Rigidbody2D>();
       
	}
	
	// Update is called once per frame
	void Update () {

        //Checks if the blob has left the screen and destroys it
        if (transform.position.x > screenSize.x)
            Destroy(gameObject);
        else if (transform.position.x < -screenSize.x)
            Destroy(gameObject);
        else if (transform.position.y > screenSize.y)
            Destroy(gameObject);
        else if (transform.position.y < -screenSize.y)
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        //applies a forward force to the blob
        rigidBody.AddForce(-transform.right * blobSpeed);
    }
}
