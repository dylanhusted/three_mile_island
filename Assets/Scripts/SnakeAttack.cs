using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttack : MonoBehaviour {

    public GameObject snakePrefab;
    public System.Random rnd = new System.Random();
    public bool collided = false;
    private int finalPoints;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (collided == false) {
            transform.position += new Vector3(0.35f, 0.0f, 0.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "portalMultiplier")
        {
            float randZ = rnd.Next(290, 435);
            float randX = rnd.Next(280, 375);
            Instantiate(snakePrefab, new Vector3(randX, 0.0f, randZ), Quaternion.Euler(0, 110, 0));
            float randZ2 = rnd.Next(290, 435);
            float randX2 = rnd.Next(280, 375);
            Instantiate(snakePrefab, new Vector3(randX2, 0.0f, randZ2), Quaternion.Euler(0, 110, 0));
            collided = true;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "OVRPlayerController")
        {
            Debug.Log("Player hit");
            // Reduce health
            SnakeManager.health -= 40;
            TextMesh healthStatusText = GameObject.Find("healthStatus").GetComponent<TextMesh>();
            healthStatusText.text = string.Format("Health:\n {0}", SnakeManager.health);
            // Restart game if user is killed
            if (SnakeManager.health <= 0)
            {
                RestartGame(false);
            }
        }
    }

    public void RestartGame(bool result)
    {
        // Delete all snakes
        Destroy(GameObject.FindGameObjectWithTag("Snake"));
        GameObject[] snakes = GameObject.FindGameObjectsWithTag("Snake");
        foreach (GameObject snake in snakes)
            GameObject.Destroy(snake);
        // Reset score and health
        finalPoints = ControllerInput.userPoints;
        Debug.Log("End game points: " + finalPoints);
        ControllerInput.userPoints = 0;
        SnakeManager.health = 100;
        // Open start menu
        SnakeManager.startMenuActive = true;
        // Transport user to starting position
        GameObject user = GameObject.FindGameObjectWithTag("Player");
        user.transform.position = new Vector3(423.0f, 9.06f, 333.0f); Quaternion.Euler(0, -65, 0);
        UnityEngine.VR.InputTracking.Recenter();
        // Notify restart in HUD
        if (result == true)
        {
            TextMesh healthStatusText = GameObject.Find("healthStatus").GetComponent<TextMesh>();
            healthStatusText.text = "You escaped" + System.Environment.NewLine + "the island!" + System.Environment.NewLine + finalPoints + " points" + System.Environment.NewLine + "earned";
        }
        else
        {
            TextMesh healthStatusText = GameObject.Find("healthStatus").GetComponent<TextMesh>();
            healthStatusText.text = "You were" + System.Environment.NewLine + "killed!" + System.Environment.NewLine + finalPoints + " points" + System.Environment.NewLine + "earned";
        }
    }
}
