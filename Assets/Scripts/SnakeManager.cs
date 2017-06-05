using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour {

    public GameObject snakePrefab;
    public GameObject startMenu;
    public GameObject miniSnakePrefab;
    public static bool startMenuActive = true;

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
                healthStatusText.text = "";
            }
        }
    }

    private void SnakeGenerate()
    {
        Instantiate(snakePrefab, new Vector3(327f, 0.0f, 315.8f), Quaternion.Euler(0, 110, 0));
        Instantiate(snakePrefab, new Vector3(327f, 0.0f, 333.0f), Quaternion.Euler(0, 110, 0));
        Instantiate(snakePrefab, new Vector3(327f, 0.0f, 403.2f), Quaternion.Euler(0, 110, 0));
    }

    private void MiniSnakeGenerate()
    {
        Instantiate(miniSnakePrefab, new Vector3(307.7f, 0.0f, 403.2f), Quaternion.Euler(0, 110, 0));
    }
}
