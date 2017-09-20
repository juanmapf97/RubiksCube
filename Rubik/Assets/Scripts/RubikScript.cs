using UnityEngine;
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
	public GameObject pivotCenter;

	//Private Variables
	private GameObject[] cubes;
	private GameObject pivot;
	private bool rotating;
	private bool stopShuffle;
	private string method;
	private int i;
	private int j;
	private Stack<int> movements;

	// Use this for initialisation
	void Start ()
	{
		pivot = new GameObject ("pivot");
		//All cubes tagged as Cube
		movements = new Stack<int> ();
		cubes = GameObject.FindGameObjectsWithTag ("Cube");
	}

	void SolveCube ()
	{
		if (movements.Count > 0) {
			if (!rotating) {
				switch (movements.Peek ()) {
				case 0:
					pivot.transform.position = pivotRed.transform.position;
					method = "RotateLeft";
					movements.Pop ();
					InvokeRepeating (method, 0f, 0.0001f);
					break;
				case 1:
					pivot.transform.position = pivotRed.transform.position;
					method = "RotateRight";
					movements.Pop ();
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 2:
					pivot.transform.position = pivotOrange.transform.position;
					method = "RotateLeft";
					movements.Pop ();
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 3:
					method = "RotateRight";
					movements.Pop ();
					pivot.transform.position = pivotOrange.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 4:
					method = "RotateUp";
					movements.Pop ();
					pivot.transform.position = pivotYellow.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 5:
					method = "RotateDown";
					movements.Pop ();
					pivot.transform.position = pivotYellow.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 6:
					method = "RotateUp";
					movements.Pop ();
					pivot.transform.position = pivotWhite.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 7:
					method = "RotateDown";
					movements.Pop ();
					pivot.transform.position = pivotWhite.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 8:
					method = "RotateFront";
					movements.Pop ();
					pivot.transform.position = pivotGreen.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 9:
					method = "RotateFront";
					movements.Pop ();
					pivot.transform.position = pivotBlue.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 10:
					method = "RotateBack";
					movements.Pop ();
					pivot.transform.position = pivotGreen.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 11:
					method = "RotateBack";
					movements.Pop ();
					pivot.transform.position = pivotBlue.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 12:
					method = "RotateLeft";
					pivot.transform.position = pivotCenter.transform.position;
					movements.Pop ();
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 13:
					method = "RotateRight";
					movements.Pop ();
					pivot.transform.position = pivotCenter.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 14:
					method = "RotateFront";
					movements.Pop ();
					pivot.transform.position = pivotCenter.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 15:
					method = "RotateBack";
					movements.Pop ();
					pivot.transform.position = pivotCenter.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 16:
					method = "RotateUp";
					movements.Pop ();
					pivot.transform.position = pivotCenter.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 17:
					method = "RotateDown";
					movements.Pop ();
					pivot.transform.position = pivotCenter.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				default:
					break;
				}
			}
		} else {
			CancelInvoke ("SolveCube");
		}
	}

	void ShuffleCube ()
	{
		if (j < 25) {
			if (!rotating) {
				switch (Random.Range (0, 17)) {
				case 0:
					pivot.transform.position = pivotRed.transform.position;
					method = "RotateLeft";
					movements.Push (1);
					InvokeRepeating (method, 0f, 0.0001f);
					break;
				case 1:
					pivot.transform.position = pivotRed.transform.position;
					method = "RotateRight";
					movements.Push (0);
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 2:
					pivot.transform.position = pivotOrange.transform.position;
					method = "RotateLeft";
					movements.Push (3);
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 3:
					method = "RotateRight";
					movements.Push (2);
					pivot.transform.position = pivotOrange.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 4:
					method = "RotateUp";
					movements.Push (5);
					pivot.transform.position = pivotYellow.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 5:
					method = "RotateDown";
					movements.Push (4);
					pivot.transform.position = pivotYellow.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 6:
					method = "RotateUp";
					movements.Push (7);
					pivot.transform.position = pivotWhite.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 7:
					method = "RotateDown";
					movements.Push (6);
					pivot.transform.position = pivotWhite.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 8:
					method = "RotateFront";
					movements.Push (10);
					pivot.transform.position = pivotGreen.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 9:
					method = "RotateFront";
					movements.Push (11);
					pivot.transform.position = pivotBlue.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 10:
					method = "RotateBack";
					movements.Push (8);
					pivot.transform.position = pivotGreen.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 11:
					method = "RotateBack";
					movements.Push (9);
					pivot.transform.position = pivotBlue.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 12:
					method = "RotateLeft";
					pivot.transform.position = pivotCenter.transform.position;
					movements.Push (13);
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 13:
					method = "RotateRight";
					movements.Push (12);
					pivot.transform.position = pivotCenter.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 14:
					method = "RotateFront";
					movements.Push (15);
					pivot.transform.position = pivotCenter.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 15:
					method = "RotateBack";
					movements.Push (14);
					pivot.transform.position = pivotCenter.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 16:
					method = "RotateUp";
					movements.Push (17);
					pivot.transform.position = pivotCenter.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				case 17:
					method = "RotateDown";
					movements.Push (16);
					pivot.transform.position = pivotCenter.transform.position;
					InvokeRepeating (method, 0f, rotationSpeed);
					break;
				default:
					break;

				}
				j++;
			}
		}
	}

	void RotateRight ()
	{ 
		rotating = true;
		foreach (GameObject cube in cubes) {
			if (cube.transform.position.y > Mathf.Floor (pivot.transform.position.y) && cube.transform.position.y < Mathf.Ceil (pivot.transform.position.y)) {
				cube.transform.parent = pivot.transform;
			}
		}
		if (i < 90) {
			pivot.transform.RotateAround (pivot.transform.position, Vector3.down, 1);
			i++;
		}
	}

	void RotateLeft ()
	{ 
		rotating = true;
		foreach (GameObject cube in cubes) {
			if (cube.transform.position.y > Mathf.Floor (pivot.transform.position.y) && cube.transform.position.y < Mathf.Ceil (pivot.transform.position.y)) {
				cube.transform.parent = pivot.transform;
			}
		}
		if (i < 90) {
			pivot.transform.RotateAround (pivot.transform.position, Vector3.up, 1);
			i++;
		}
	}

	void RotateFront ()
	{ 
		rotating = true;
		foreach (GameObject cube in cubes) {
			if (cube.transform.position.x > Mathf.Floor (pivot.transform.position.x) && cube.transform.position.x < Mathf.Ceil (pivot.transform.position.x)) {
				cube.transform.parent = pivot.transform;
			}
		}
		if (i < 90) {
			pivot.transform.RotateAround (pivot.transform.position, Vector3.right, 1);
			i++;
		}
	}

	void RotateBack ()
	{ 
		rotating = true;
		foreach (GameObject cube in cubes) {
			if (cube.transform.position.x > Mathf.Floor (pivot.transform.position.x) && cube.transform.position.x < Mathf.Ceil (pivot.transform.position.x)) {
				cube.transform.parent = pivot.transform;
			}
		}
		if (i < 90) {
			pivot.transform.RotateAround (pivot.transform.position, Vector3.left, 1);
			i++;
		}

	}

	void RotateUp ()
	{ 
		rotating = true;
		foreach (GameObject cube in cubes) {
			if (cube.transform.position.z > Mathf.Floor (pivot.transform.position.z) && cube.transform.position.z < Mathf.Ceil (pivot.transform.position.z)) {
				cube.transform.parent = pivot.transform;
			}
		}
		if (i < 90) {
			pivot.transform.RotateAround (pivot.transform.position, Vector3.forward, 1);
			i++;
		}
	}

	void RotateDown ()
	{ 
		rotating = true;
		foreach (GameObject cube in cubes) {
			if (cube.transform.position.z > Mathf.Floor (pivot.transform.position.z) && cube.transform.position.z < Mathf.Ceil (pivot.transform.position.z)) {
				cube.transform.parent = pivot.transform;
			}
		}
		if (i < 90) {
			pivot.transform.RotateAround (pivot.transform.position, Vector3.back, 1);
			i++;
		}
	}

	void Update ()
	{
		if (!rotating) {
			if (Input.GetKeyDown ("q")) {
				pivot.transform.position = pivotRed.transform.position;
				method = "RotateLeft";
				movements.Push (1);
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("w")) {
				pivot.transform.position = pivotRed.transform.position;
				method = "RotateRight";
				movements.Push (0);
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("z")) {
				pivot.transform.position = pivotOrange.transform.position;
				method = "RotateLeft";
				movements.Push (3);
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("x")) {
				method = "RotateRight";
				movements.Push (2);
				pivot.transform.position = pivotOrange.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("e")) {
				method = "RotateUp";
				movements.Push (5);
				pivot.transform.position = pivotYellow.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("r")) {
				method = "RotateDown";
				movements.Push (4);
				pivot.transform.position = pivotYellow.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("c")) {
				method = "RotateUp";
				movements.Push (7);
				pivot.transform.position = pivotWhite.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("v")) {
				method = "RotateDown";
				movements.Push (6);
				pivot.transform.position = pivotWhite.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("t")) {
				method = "RotateFront";
				movements.Push (10);
				pivot.transform.position = pivotGreen.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("b")) {
				method = "RotateFront";
				movements.Push (11);
				pivot.transform.position = pivotBlue.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("y")) {
				method = "RotateBack";
				movements.Push (8);
				pivot.transform.position = pivotGreen.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("n")) {
				method = "RotateBack";
				movements.Push (9);
				pivot.transform.position = pivotBlue.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("o")) {
				method = "ShuffleCube";
				InvokeRepeating (method, 0f, 0.1f);
			} else if (Input.GetKeyDown ("l")) {
				method = "SolveCube";
				InvokeRepeating (method, 0f, 0.1f);
			} else if (Input.GetKeyDown ("a")) {
				method = "RotateLeft";
				pivot.transform.position = pivotCenter.transform.position;
				movements.Push (13);
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("s")) {
				method = "RotateRight";
				movements.Push (12);
				pivot.transform.position = pivotCenter.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("d")) {
				method = "RotateFront";
				movements.Push (15);
				pivot.transform.position = pivotCenter.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("f")) {
				method = "RotateBack";
				movements.Push (14);
				pivot.transform.position = pivotCenter.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("g")) {
				method = "RotateUp";
				movements.Push (17);
				pivot.transform.position = pivotCenter.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			} else if (Input.GetKeyDown ("h")) {
				method = "RotateDown";
				movements.Push (16);
				pivot.transform.position = pivotCenter.transform.position;
				InvokeRepeating (method, 0f, rotationSpeed);
			}
		}
		foreach (var cube in cubes) {
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