using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour {

    public GameObject cubePrefab;
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
                CubeGenerate();
                InvokeRepeating("MiniCubeGenerate", 3.0f, 25.0f);
                startMenu.SetActive(false);
                startMenuActive = false;
                TextMesh healthStatusText = GameObject.Find("healthStatus").GetComponent<TextMesh>();
                healthStatusText.text = "";
            }
        }
    }

    private void CubeGenerate()
    {
        Instantiate(cubePrefab, new Vector3(-4.69f, 1.0f, 5f), Quaternion.identity);
        Instantiate(cubePrefab, new Vector3(-0.4f, 1.0f, 5f), Quaternion.identity);
        Instantiate(cubePrefab, new Vector3(3.31f, 1.0f, 5f), Quaternion.identity);
    }

    private void MiniCubeGenerate()
    {
        Instantiate(miniCubePrefab, new Vector3(0.0f, 1.0f, 34.05f), Quaternion.identity);
    }
}
