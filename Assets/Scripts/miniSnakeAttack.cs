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
            // Reduce health
            SnakeManager.health -= 20;
            TextMesh healthStatusText = GameObject.Find("healthStatus").GetComponent<TextMesh>();
            healthStatusText.text = string.Format("Health:\n {0}", SnakeManager.health);
            // Restart game if user is killed
            if (SnakeManager.health <= 0)
            {
                SnakeAttack snake_attack_script = GameObject.FindGameObjectWithTag("Snake").GetComponent<SnakeAttack>();
                snake_attack_script.RestartGame(false);
            }
        }
    }
}
