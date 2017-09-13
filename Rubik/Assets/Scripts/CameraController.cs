using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject playerCamera;

    private GameObject cubeCenter;
    private int i;
    private bool rotating;
	// Use this for initialization
	void Start () {
        cubeCenter = GameObject.FindGameObjectWithTag("CubeCenter");
	}
	
    void RotateRight()
    {
        rotating = true;
        if (i < 90)
        {
            playerCamera.transform.RotateAround(cubeCenter.transform.position, Vector3.down, 1);
            i++;
        }
    }

    void RotateLeft()
    {
        rotating = true;
        if (i < 90)
        {
            playerCamera.transform.RotateAround(cubeCenter.transform.position, Vector3.up, 1);
            i++;
        }
    }

    // Update is called once per frame
    void Update () {
        if (!rotating)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                InvokeRepeating("RotateRight", 0f, 0.001f);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                InvokeRepeating("RotateLeft", 0f, 0.001f);
            }
        }
        if (i >= 90)
        {
            CancelInvoke();
            rotating = false;
            i = 0;
        }
        playerCamera.transform.LookAt(cubeCenter.transform);
    }
}
