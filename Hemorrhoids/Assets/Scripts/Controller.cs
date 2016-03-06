using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour {

    int score;
    int lives;

    public Text scoreText;
    public Text livesText;
    public GameObject tube;
    public GameObject butt;
    public Canvas gameOverCanvas;

    public int respawnCount; //How many enemies spawn
    public int respawnRate; //How often enemies spawn
    private float spawnDelay; //When the last enemies were spawned

	//Setups new game. Resets score and lives, spawns player and first wave of enemies
	void Start () {
        score = 0;
        lives = 3;
        scoreText.text = "" + score;
        livesText.text = "" + lives;

        Instantiate(tube, new Vector3(0, 0, 0), Quaternion.identity);

        SpawnButts();

	}
	
	//Updates the scores and lives text and spawns new enemies if needed
	void Update () {

        scoreText.text = "" + score;
        livesText.text = "" + lives;

        GameObject[] numButts = GameObject.FindGameObjectsWithTag("Butt");

        if (Time.time > spawnDelay + respawnRate || numButts.Length < 1) //if respawn timer is up, or all enemies have been destroyed
        {
            SpawnButts();
        }
	}

    //Spawns the appropriatte number of enemies
    void SpawnButts()
    {
        for(int i = 0; i < respawnCount; i++)
        {
            Instantiate(butt);

        }

        spawnDelay = Time.time;
    }

    public void incrementScore()
    {
        score++;
    }

    //decrement lives. If no more lives, shows game over else respawns player in center
    public void decrementLives()
    {
        lives--;
        if(lives == 0)
        {
            gameOverCanvas.enabled = true;
        }
        else
        {
            Instantiate(tube, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

}
