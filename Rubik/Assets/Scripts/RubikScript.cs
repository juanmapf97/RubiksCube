using UnityEngine;
using System.Collections;

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
	private int i;

    // Use this for initialisation
    void Start () 
	{
        pivot = new GameObject("pivot");
        //All cubes tagged as Cube
        cubes = GameObject.FindGameObjectsWithTag("Cube");
	}

	//Rotate the right face
	void RotateRight()
    { 
        foreach (GameObject cube in cubes)
		{
			if(cube.transform.position.y > Mathf.Floor(pivot.transform.position.y) && cube.transform.position.y < Mathf.Ceil(pivot.transform.position.y))
			{
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

    //Perform rotation gradually (To prove concept)
    void Update()
	{
        if (Input.GetKeyDown("q"))
		{
			pivot.transform.position = pivotRed.transform.position;
			InvokeRepeating ("RotateLeft", 0f, rotationSpeed);
        }
        else if (Input.GetKeyDown("w"))
		{
			pivot.transform.position = pivotRed.transform.position;
			InvokeRepeating ("RotateRight", 0f, rotationSpeed);
        }
        else if (Input.GetKeyDown("z"))
        {
			pivot.transform.position = pivotOrange.transform.position;
			InvokeRepeating ("RotateLeft", 0f, rotationSpeed);
        }
        else if (Input.GetKeyDown("x"))
		{
			pivot.transform.position = pivotOrange.transform.position;
			InvokeRepeating ("RotateRight", 0f, rotationSpeed);
        }
        else if (Input.GetKeyDown("e"))
        {
			pivot.transform.position = pivotYellow.transform.position;
			InvokeRepeating ("RotateUp", 0f, rotationSpeed);
        }
        else if (Input.GetKeyDown("r"))
        {
			pivot.transform.position = pivotYellow.transform.position;
			InvokeRepeating ("RotateDown", 0f, rotationSpeed);
        }
        else if (Input.GetKeyDown("c"))
        {
			pivot.transform.position = pivotWhite.transform.position;
			InvokeRepeating ("RotateUp", 0f, rotationSpeed);
        }
        else if (Input.GetKeyDown("v"))
        {
			pivot.transform.position = pivotWhite.transform.position;
			InvokeRepeating ("RotateDown", 0f, rotationSpeed);
        }
        else if (Input.GetKeyDown("t"))
        {
			pivot.transform.position = pivotGreen.transform.position;
			InvokeRepeating ("RotateFront", 0f, rotationSpeed);
        }
        else if (Input.GetKeyDown("b"))
        {
			pivot.transform.position = pivotBlue.transform.position;
			InvokeRepeating ("RotateFront", 0f, rotationSpeed);
        }
        else if (Input.GetKeyDown("y"))
        {
			pivot.transform.position = pivotGreen.transform.position;
			InvokeRepeating ("RotateBack", 0f, rotationSpeed);
        }
        else if (Input.GetKeyDown("n"))
        {
			pivot.transform.position = pivotBlue.transform.position;
			InvokeRepeating ("RotateBack", 0f, rotationSpeed);
        }
        foreach (var cube in cubes)
        {
            cube.transform.parent = rubix.transform;
        }
		if (i >= 90) {
			CancelInvoke ();
			i = 0;
		}
        //rightPivot.transform.RotateAround(new Vector3(-12.64479f,-8.834972f,3.402084f),Vector3.forward,rotationSpeed*Time.deltaTime);
    }

//	float i = 0.0f;
//	while(i < 1.0f)
//	{
//		i += rotationSpeed;
//		Quaternion rotation;
//		switch(axisName)
//		{
//		case 'x':
//			rotation = Quaternion.Euler(angle, 0, 0);
//			break;
//		case 'y':
//			rotation = Quaternion.Euler(0, angle, 0);
//			break;
//		case 'z':
//			rotation = Quaternion.Euler(0, 0, angle);
//			break;
//		default:
//			rotation = Quaternion.Euler(0, 0, 0);
//			break;
//		}
//		face.transform.rotation = Quaternion.Lerp(face.transform.rotation, rotation, i);
//		yield return null;
//	}
}