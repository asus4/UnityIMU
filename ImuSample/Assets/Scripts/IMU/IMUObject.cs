using UnityEngine;
using Imu;

public class IMUObject : MonoBehaviour {
	#region privates
	Transform _transform;
	bool inited = false;

	// rotation
	Quaternion initialRotation;
	Quaternion gyroInitialRotation;

	// position
	DVector3 accele;
	DVector3 initialPosition;
	DVector3 totalMovement;
	#endregion

	#region life cycle
	void Start ()
	{	
		_transform = this.transform;
		
		// set syro
		Input.gyro.enabled = true;
		Input.gyro.updateInterval = 100;
		
		initialRotation = _transform.localRotation;
		gyroInitialRotation = Input.gyro.attitude;
		
		initialPosition = new DVector3 (_transform.localPosition);
		
		// set compass
		accele = new DVector3 ();
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
		
		// position
		accele = updateAcceleration (accele);
		totalMovement += accele;
		_transform.localPosition = (initialPosition + totalMovement).ToVector3 ();
		
		// reset flag
		if (Input.touchCount > 0) {
			_transform.localPosition = this.initialPosition.ToVector3 ();
			totalMovement = new DVector3 (0, 0, 0);
		}
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

	DVector3 updateAcceleration (DVector3 acc)
	{
		/*
		Vector3 acceleration = Vector3.zero;
		float deltaTime = Time.deltaTime;
		float accDelta = deltaTime / (float)Input.accelerationEvents.Length;
		
		foreach (AccelerationEvent accEvent in Input.accelerationEvents) {
			//acceleration += accEvent.acceleration * accEvent.deltaTime;
			//Debug.Log (string.Format ("gyro acc:{0} delataTime:{1}", accEvent.acceleration, accEvent.deltaTime));
		}
		*/
		
		DVector3 gravAcc = new DVector3 (Input.gyro.gravity);
		gravAcc *= 0.98;
		
		DVector3 userAcc = new DVector3 (Input.acceleration) - gravAcc;
		
		userAcc *= Time.deltaTime;
		acc += userAcc;
		acc *= 0.98;
		
		//Debug.Log (string.Format ("acc unity:{0} my:{1} gravity:{2}", Input.gyro.userAcceleration, acceleration-Input.gyro.gravity, Input.gyro.gravity));
		
		return acc;
	}
	#endregion
}