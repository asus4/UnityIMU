using UnityEngine;
using Kalman;

/// <summary>
/// Test code
/// </summary>
public class Test : MonoBehaviour {
	
	[SerializeField]
	Camera cam;
	
	[SerializeField]
	Transform mouseCube;
	
	[SerializeField]
	Transform filterdCube;
	
	IKalmanWrapper kalman;
	
	void Awake ()
	{
		kalman = new MatrixKalmanWrapper ();
		//kalman = new SimpleKalmanWrapper ();
	}
		
	void Start ()
	{
		cam = Camera.mainCamera;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Vector3
		Vector3 mouse = Input.mousePosition;
		mouse.z = 10;
		mouseCube.transform.position = cam.ScreenToWorldPoint (mouse);
		
		filterdCube.transform.position = cam.ScreenToWorldPoint (kalman.Update (mouse));
	}
}
