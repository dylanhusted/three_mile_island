using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniSnakeAttack : MonoBehaviour {

    public GameObject miniSnakePrefab;
    public System.Random rnd = new System.Random();
    public float randZ;
    public float randX;
    public bool collided = false;
    public SnakeAttack SnakeAttackScript;
    private int finalPoints;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (collided == false)
        {
            transform.position += new Vector3(0.4f, 0.0f, 0.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "portalMultiplier")
        {
            float randZ = rnd.Next(335, 390);
            float randX = rnd.Next(310, 330);
            Instantiate(miniSnakePrefab, new Vector3(randX, 0.0f, randZ), Quaternion.Euler(0, 110, 0));
            float randZ2 = rnd.Next(335, 390);
            float randX2 = rnd.Next(310, 330);
            Instantiate(miniSnakePrefab, new Vector3(randX2, 0.0f, randZ2), Quaternion.Euler(0, 110, 0));
            collided = true;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "OVRPlayerController")
        {
            Debug.Log("Player hit");
            // SnakeAttackScript.RestartGame();
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
