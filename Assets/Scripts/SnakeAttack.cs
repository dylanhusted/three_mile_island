﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttack : MonoBehaviour {

    public GameObject snakePrefab;
    public System.Random rnd = new System.Random();
    public float randZ;
    public float randX;
    public bool collided = false;
    private int finalPoints;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
        if (collided == false) {
            transform.position += new Vector3(0.05f, 0.0f, 0.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "portalMultiplier")
        {
            float randZ = rnd.Next(12, 24);
            float randX = rnd.Next(-1, 3);

            Instantiate(snakePrefab, new Vector3(randX, 1.0f, randZ), Quaternion.identity);
            Instantiate(snakePrefab, new Vector3(randX, 1.0f, randZ), Quaternion.identity);
            collided = true;
        }
        if (collision.gameObject.name == "OVRPlayerController")
        {
            Debug.Log("Player hit");
            RestartGame();
        }
    }

    public void RestartGame()
    {
        // Delete all cubes
        Destroy(GameObject.FindGameObjectWithTag("Snake"));
        GameObject[] snakes = GameObject.FindGameObjectsWithTag("Snake");
        foreach (GameObject snake in snakes)
            GameObject.Destroy(snake);
        // Reset Score
        finalPoints = ControllerInput.userPoints;
        Debug.Log("End game points: " + finalPoints);
        ControllerInput.userPoints = 0;
        // Open start menu
        SnakeManager.startMenuActive = true;
        // Notify restart in HUD
        TextMesh healthStatusText = GameObject.Find("healthStatus").GetComponent<TextMesh>();
        healthStatusText.text = "You've " + System.Environment.NewLine + "been hit!" + System.Environment.NewLine + finalPoints + " points" + System.Environment.NewLine + "earned";
    }
}