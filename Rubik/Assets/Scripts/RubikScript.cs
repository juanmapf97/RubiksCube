using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Class to control rubik's cube rotation
public class RubikScript : MonoBehaviour 
{
	//Public Variables
	public GameObject rubix;
	public float rotationSpeed;
	public GameObject pivotYellow;
	public GameObject pivotBlue;
	public GameObject pivotWhite;
	public GameObject pivotGreen;
	public GameObject pivotRed;
	public GameObject pivotOrange;

	//Private Variables
	private GameObject[] cubes;
    private GameObject pivot;
	private bool rotating;
	private bool stopShuffle;
	private string method;
	private int i;
	private int j;
	private Stack<char> movements;

    // Use this for initialisation
    void Start () 
	{
        pivot = new GameObject("pivot");
		//All cubes tagged as Cube
        cubes = GameObject.FindGameObjectsWithTag("Cube");
	}

	void ShuffleCube() {
		if (j < 25) {
			if (!rotating) {
				switch (Random.Range (0, 11)) {
				case 0:
					pivot.transform.position = pivotBlue.transform.position;
					method = "RotateBack";
					InvokeRepeating (method, 0f, 0.0001f);
					break;
				case 1:
					method = "RotateLeft";
					pivot.transform.position = pivotRed.transform.position;
					InvokeRepeating (method, 0f, 0.0001f);
					break;
				case 2:
					method = "RotateRight";
					pivot.transform.position = pivotRed.transform.position;
					InvokeRepeating (method, 0f, 0.0001f);
					break;
				case 3:
					method = "RotateLeft";
					pivot.transform.position = pivotOrange.transform.position;
					InvokeRepeating (method, 0f, 0.0001f);
					break;
				case 4:
					method = "RotateRight";
					pivot.transform.position = pivotOrange.transform.position;
					InvokeRepeating (method, 0f, 0.0001f);
					break;
				case 5:
					method = "RotateUp";
					pivot.transform.position = pivotYellow.transform.position;
					InvokeRepeating (method, 0f, 0.0001f);
					break;
				case 6:
					method = "RotateDown";
					pivot.transform.position = pivotYellow.transform.position;
					InvokeRepeating (method, 0f, 0.0001f);
					break;
				case 7:
					method = "RotateUp";
					pivot.transform.position = pivotWhite.transform.position;
					InvokeRepeating (method, 0f, 0.0001f);
					break;
				case 8:
					method = "RotateDown";
					pivot.transform.position = pivotWhite.transform.position;
					InvokeRepeating (method, 0f, 0.0001f);
					break;
				case 9:
					method = "RotateFront";
					pivot.transform.position = pivotGreen.transform.position;
					InvokeRepeating (method, 0f, 0.0001f);
					break;
				case 10:
					method = "RotateFront";
					pivot.transform.position = pivotBlue.transform.position;
					InvokeRepeating (method, 0f, 0.0001f);
					break;
				case 11:
					method = "RotateBack";
					pivot.transform.position = pivotGreen.transform.position;
					InvokeRepeating (method, 0f, 0.0001f);
					break;
				default:
					break;
				}
				j++;
			}
		}
	}
		
	void RotateRight()
    { 
		rotating = true;
        foreach (GameObject cube in cubes)
		{
			if(cube.transform.position.y > Mathf.Floor(pivot.transform.position.y) && cube.transform.position.y < Mathf.Ceil(pivot.transform.position.y)) {
				cube.transform.parent = pivot.transform;
			}
		}
		if (i < 90) {
			pivot.transform.RotateAround (pivot.transform.position, Vector3.down, 1);
			i++;
		}
    }

	void RotateLeft()
	{ 
		rotating = true;
		foreach (GameObject cube in cubes) {
			if (cube.transform.position.y > Mathf.Floor(pivot.transform.position.y) && cube.transform.position.y < Mathf.Ceil(pivot.transform.position.y)) {
				cube.transform.parent = pivot.transform;
			}
		}
		if (i < 90) {
			pivot.transform.RotateAround (pivot.transform.position, Vector3.up, 1);
			i++;
		}
    }

    void RotateFront()
	{ 
		rotating = true;
		foreach (GameObject cube in cubes) {
			if (cube.transform.position.x > Mathf.Floor(pivot.transform.position.x) && cube.transform.position.x < Mathf.Ceil(pivot.transform.position.x)) {
				cube.transform.parent = pivot.transform;
			}
		}
		if (i < 90) {
			pivot.transform.RotateAround (pivot.transform.position, Vector3.right, 1);
			i++;
		}
    }

    void RotateBack()
	{ 
		rotating = true;
		foreach (GameObject cube in cubes) {
			if (cube.transform.position.x > Mathf.Floor(pivot.transform.position.x) && cube.transform.position.x < Mathf.Ceil(pivot.transform.position.x)) {
				cube.transform.parent = pivot.transform;
			}
		}
		if (i < 90) {
			pivot.transform.RotateAround (pivot.transform.position, Vector3.left, 1);
			i++;
		}

    }

    void RotateUp()
	{ 
		rotating = true;
		foreach (GameObject cube in cubes) {
			if (cube.transform.position.z > Mathf.Floor(pivot.transform.position.z) && cube.transform.position.z < Mathf.Ceil(pivot.transform.position.z)) {
				cube.transform.parent = pivot.transform;
			}
		}
		if (i < 90) {
			pivot.transform.RotateAround (pivot.transform.position, Vector3.forward, 1);
			i++;
		}
    }

    void RotateDown()
	{ 
		rotating = true;
		foreach (GameObject cube in cubes) {
			if (cube.transform.position.z > Mathf.Floor(pivot.transform.position.z) && cube.transform.position.z < Mathf.Ceil(pivot.transform.position.z)) {
				cube.transform.parent = pivot.transform;
			}
		}
		if (i < 90) {
			pivot.transform.RotateAround (pivot.transform.position, Vector3.back, 1);
			i++;
		}
    }
		
    void Update()
	{
		if (!rotating) {
			if (Input.GetKeyDown ("q")) {
				pivot.transform.position = pivotRed.transform.position;
				method = "RotateLeft";
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("w")) {
				pivot.transform.position = pivotRed.transform.position;
				method = "RotateRight";
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("z")) {
				pivot.transform.position = pivotOrange.transform.position;
				method = "RotateLeft";
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("x")) {
				method = "RotateRight";
				pivot.transform.position = pivotOrange.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("e")) {
				method = "RotateUp";
				pivot.transform.position = pivotYellow.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("r")) {
				method = "RotateDown";
				pivot.transform.position = pivotYellow.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("c")) {
				method = "RotateUp";
				pivot.transform.position = pivotWhite.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("v")) {
				method = "RotateDown";
				pivot.transform.position = pivotWhite.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("t")) {
				method = "RotateFront";
				pivot.transform.position = pivotGreen.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("b")) {
				method = "RotateFront";
				pivot.transform.position = pivotBlue.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("y")) {
				method = "RotateBack";
				pivot.transform.position = pivotGreen.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("n")) {
				method = "RotateBack";
				pivot.transform.position = pivotBlue.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("o")) {
				method = "ShuffleCube";
				InvokeRepeating (method, 0f, 0.1f);
			}
		}
        foreach (var cube in cubes)
        {
            cube.transform.parent = rubix.transform;
        }
		if (i >= 90) {
			CancelInvoke (method);
			rotating = false;
			i = 0;
		}
		if (j >= 25) {
			CancelInvoke ("ShuffleCube");
			j = 0;
		}
    }
}