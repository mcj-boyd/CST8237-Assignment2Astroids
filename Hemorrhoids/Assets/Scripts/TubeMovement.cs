using UnityEngine;
using System.Collections;

public class TubeMovement : MonoBehaviour {

    public float tubeSpeed;
    public float tubeRotation;
    public float blobSpeed;
    public float fireRate;
    public GameObject blob;
    Rigidbody2D rigidBody;

    private float blobDelay;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space) && Time.time > blobDelay) //If the player hits "fire" and the fire rate time has expired
        {
            Instantiate(blob, transform.position, transform.rotation); //Creates blob with position and rotation equal to the player
            blobDelay = Time.time + fireRate; //increment fire rate timer
        }
	}

    void FixedUpdate()
    {
        
        transform.Rotate(transform.forward, -Input.GetAxis("Horizontal") * tubeRotation); //rotates the player according to left and right arrows

        if (Input.GetKey(KeyCode.UpArrow)) //If the player hits up arrow, the player is propelled forward
        {
            rigidBody.AddForce(-transform.right * tubeSpeed);
        }
    }

}
