using UnityEngine;
using System.Collections;

public class ButtMovement : MonoBehaviour {

    public float minTorque = -10.0f;
    public float maxTorque = 10.0f;
    public float maxSpeed = 1.0f;
    public float minSpeed = 5.0f;
    public AudioClip relief;
    public AudioClip explos;
    Controller controller;

	// Use this for initialization
	void Start () {

        controller = GameObject.FindWithTag("Controller").GetComponent<Controller>(); //A referrence to the controller script for access to external functions

        Vector2 screenSize;

        screenSize.y = Camera.main.orthographicSize;
        screenSize.x = screenSize.y * Camera.main.aspect;
        transform.position = new Vector2(

            Random.Range(-screenSize.x, screenSize.x),
            Random.Range(-screenSize.y, screenSize.y)
        ); //moves enemy to random spot within the screen

        GetComponent<Rigidbody2D>().AddTorque(Random.Range(minTorque, maxTorque)); //applies random spin
        GetComponent<Rigidbody2D>().AddForce(transform.position * Random.Range(minSpeed, maxSpeed)); //applies random force
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //handles collisions with other game objects
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Blob")) //if blob destroy enemy and blob and incremement score
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            AudioSource.PlayClipAtPoint(relief, transform.position);
            controller.incrementScore();
        } else if (col.CompareTag("Tube")) //if player, destroy player and enemie and decrement lives
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            AudioSource.PlayClipAtPoint(explos, transform.position);
            controller.decrementLives();
        }
    
    }



}
