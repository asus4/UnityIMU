using UnityEngine;

[AddComponentMenu("IMU/IMUObject")]
public class IMUObject : MonoBehaviour {
	#region privates
	Transform _transform;
	bool inited = false;

	// rotation
	Quaternion initialRotation;
	Quaternion gyroInitialRotation;

	#endregion

	#region life cycle
	void Start ()
	{	
		_transform = this.transform;
		
		// set gyro
		Input.gyro.enabled = true;
		Input.gyro.updateInterval = 100;
		
		initialRotation = _transform.localRotation;
		gyroInitialRotation = Input.gyro.attitude;
		
	}

	void Update ()
	{
		if (!inited) {
			inited = gyroInit ();
		}
		
		// rotation
		Quaternion offsetRotation = Quaternion.Inverse (gyroInitialRotation) * Input.gyro.attitude;
		offsetRotation = this.getEulerInverse (offsetRotation);
		_transform.localRotation = initialRotation * offsetRotation;		
	}
	#endregion
	
	#region private methods
	bool gyroInit ()
	{
		Quaternion q = Input.gyro.attitude;
		
		if (q.x != 0
			|| q.y != 0
			|| q.z != 0
			|| q.w != 0) {
			gyroInitialRotation = q;
			return true;
		}
		return false;
	}

	// inverse Coordinate system
	Quaternion getEulerInverse (Quaternion q)
	{
		Vector3 e = q.eulerAngles;
		e.x *= -1;
		e.y *= -1;
		return Quaternion.Euler (e);
	}

	#endregion
}