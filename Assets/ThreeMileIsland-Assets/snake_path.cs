using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class snake_path : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print("Hello world");	
	}

    int cnt = 0;
    int direction = 0;

    // Update is called once per frame
    void Update () {

        cnt++;
        if (cnt == 100)
        {
            direction = Random.Range(0, 3);
            cnt = 0;


            int y_rot = 0;
            if (direction == 0)
            {
                // left
                y_rot = 9000;
            }
            if (direction == 1)
            {
                // right
                y_rot = 9000;
            }
            if (direction == 2)
            {
                // forward
                y_rot = 9000;
            }
            if (direction == 3)
            {
                // back
                y_rot = 9000;
            }

            transform.Rotate(new Vector3(0, y_rot, 0) * Time.deltaTime);
        }

        int x_move = 0;
        int y_move = 0;

        if (direction==0)
        {
            // left
            x_move = 1;
            y_move = 1;
        }
        if (direction==1)
        {
            // right
            x_move = 1;
            y_move = -1;
        }
        if (direction==2)
        {
            // forward
            x_move = -1;
            y_move = 1;
        }
        if (direction==3)
        {
            // back
            x_move = -1;
            y_move = -1;
        }
        transform.Translate(new Vector3(x_move, 0, y_move) * Time.deltaTime);
    }
}
