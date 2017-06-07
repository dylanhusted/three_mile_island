using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SnakeManager : MonoBehaviour {

    public GameObject snakePrefab;
    public GameObject startMenu;
    public GameObject miniSnakePrefab;
    public static bool startMenuActive = true;
    public System.Random rnd = new System.Random();
    public static int health = 100;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (startMenuActive == true)
        {
            startMenu.SetActive(true);
            CancelInvoke();
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                SnakeGenerate();
                InvokeRepeating("MiniSnakeGenerate", 3.0f, 25.0f);
                startMenu.SetActive(false);
                startMenuActive = false;
                TextMesh healthStatusText = GameObject.Find("healthStatus").GetComponent<TextMesh>();
                if (health < 0)
                {
                    health = 0;
                }
                healthStatusText.text = string.Format("Health:\n {0}", health);
            }
        }
    }

    private void SnakeGenerate()
    {
        Scene current_scene = SceneManager.GetActiveScene();
        if (current_scene.name == "escape")
        {
            for (var i = 0; i < 25; i++)
            {
                float randZ = rnd.Next(290, 435);
                float randX = rnd.Next(280, 375);
                Instantiate(snakePrefab, new Vector3(randX, 0.0f, randZ), Quaternion.Euler(0, 110, 0));
            }
        }
        else
        {
            Instantiate(snakePrefab, new Vector3(327f, 0.0f, 315.8f), Quaternion.Euler(0, 110, 0));
            Instantiate(snakePrefab, new Vector3(327f, 0.0f, 333.0f), Quaternion.Euler(0, 110, 0));
            Instantiate(snakePrefab, new Vector3(327f, 0.0f, 403.2f), Quaternion.Euler(0, 110, 0));
        }
    }

    private void MiniSnakeGenerate()
    {
        Instantiate(miniSnakePrefab, new Vector3(307.7f, 0.0f, 403.2f), Quaternion.Euler(0, 110, 0));
    }
}
