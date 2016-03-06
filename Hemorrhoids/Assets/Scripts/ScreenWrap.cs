using UnityEngine;
using System.Collections;

public class ScreenWrap : MonoBehaviour {

    Vector2 screenSize;

	// Use this for initialization
	void Start () {

        //calculates screen boundries
        screenSize.y = Camera.main.orthographicSize;     // half screen height
        screenSize.x = screenSize.y * Camera.main.aspect; // half screen width
    }
	
	//If a game object goes off of screen, it is moved to the opposite side
	void Update () {
        if (transform.position.x > screenSize.x)
            transform.position = new Vector3(-screenSize.x, transform.position.y);

        else if (transform.position.x < -screenSize.x)
            transform.position = new Vector3(screenSize.x, transform.position.y);

        else if (transform.position.y > screenSize.y)
            transform.position = new Vector3(transform.position.x, -screenSize.y);

        else if (transform.position.y < -screenSize.y)
            transform.position = new Vector3(transform.position.x, screenSize.y);
    }

}
