﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour {

    public GameObject snakePrefab;
    public GameObject startMenu;
    public GameObject miniCubePrefab;
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
                InvokeRepeating("MiniCubeGenerate", 3.0f, 25.0f);
                startMenu.SetActive(false);
                startMenuActive = false;
                TextMesh healthStatusText = GameObject.Find("healthStatus").GetComponent<TextMesh>();
                healthStatusText.text = "";
            }
        }
    }

    private void SnakeGenerate()
    {
        Instantiate(snakePrefab, new Vector3(327.1f, 2.6f, 366.6f), Quaternion.identity);
        Instantiate(snakePrefab, new Vector3(357.7f, 2.6f, 403.2f), Quaternion.identity);
        Instantiate(snakePrefab, new Vector3(328.8f, 2.6f, 323.8f), Quaternion.identity);
    }

    private void MiniCubeGenerate()
    {
        Instantiate(miniCubePrefab, new Vector3(307.7f, 2.6f, 403.2f), Quaternion.identity);
    }
}