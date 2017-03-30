using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

    public GameObject stone;
    public GameObject camera;

    public int check = 0;
	
	// Update is called once per frame
	void Update () {
		if(check == 1)
        {
            camera.transform.position = new Vector3(stone.transform.position.x, 0, -10);
        }
        if(Input.GetKeyDown("space"))
        {
            check = 0;
            camera.transform.position = new Vector3(-0.86f, 0, -10);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        camera.transform.position = new Vector3(stone.transform.position.x,0,-10);
        check = 1;

    }

}
