using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "OVRPlayerController")
        {
            Debug.Log("User reached heli");
            SnakeAttack snake_attack_script = GameObject.FindGameObjectWithTag("Snake").GetComponent<SnakeAttack>();
            snake_attack_script.RestartGame(true);
        }
    }
}
