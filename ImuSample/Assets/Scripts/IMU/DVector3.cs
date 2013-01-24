using UnityEngine;

namespace Imu {
	
	/// <summary>
	/// Double Accuracy Vector3 class.
	/// </summary>
	public struct DVector3 {
		public double x;
		public double y;
		public double z;
		
		#region constractor
		public DVector3 (double xd, double yd, double zd)
		{
			x = xd;
			y = yd;
			z = zd;
		}
		
		public DVector3 (Vector3 vf)
		{
			x = vf.x;
			y = vf.y;
			z = vf.z;
		}

		public DVector3 (float xf, float yf, float zf)
		{
			x = xf;
			y = yf;
			z = zf;
		}
		#endregion
		
		#region public overrides
		
		// Indexer declaration
		public double this [int index] {
			get {
				if (index == 0) {
					return x;
				} else if (index == 1) {
					return y;
				} else if (index == 2) {
					return z;
				} else {
					throw new System.IndexOutOfRangeException ();
				}		
			}
			set {
				if (index == 0) {
					x = value;
				} else if (index == 1) {
					y = value;
				} else if (index == 2) {
					z = value;
				} else {
					throw new System.IndexOutOfRangeException ();
				}
			}
		}
		
		public override string ToString ()
		{
			return string.Format ("({0:0.000}, {1:0.000}, {2:0.000})", x, y, z);
		}
		
		
		public override bool Equals (object obj)
		{
			if (obj == null || this.GetType () != obj.GetType ()) {
				return false;
			}
			DVector3 v = (DVector3)obj;
			return this == v;
		}
		
		public override int GetHashCode ()
		{
			//XOR
			return x.GetHashCode () ^ y.GetHashCode () ^ z.GetHashCode ();
		}
		#endregion
		
		#region pubic 
		public Vector3 ToVector3 ()
		{
			return new Vector3 ((float)x, (float)y, (float)z);
		}
		#endregion
		
		#region operator overrides
		/* 
		 * OVERRIDES
		 * 
		 * operator +	 Adds two vectors.
		 * operator -	 Subtracts one vector from another.
		 * operator *	 Multiplies a vector by a number.
		 * operator /	 Divides a vector by a number.
		 * operator ==	 Returns true if the vectors are equal.
		 * operator !=	 Returns true if vectors different.
		 */
		
		// +
		public static DVector3 operator+ (DVector3 a, DVector3 b)
		{
			return new DVector3 (a.x + b.x, a.y + b.y, a.z + b.z);
		}
		
		public static DVector3 operator+ (Vector3 a, DVector3 b)
		{
			return new DVector3 (a.x + b.x, a.y + b.y, a.z + b.z);
		}
		
		public static DVector3 operator+ (DVector3 a, Vector3 b)
		{
			return new DVector3 (a.x + b.x, a.y + b.y, a.z + b.z);
		}
		
		public static DVector3 operator+ (DVector3 v, double d)
		{
			return new DVector3 (v.x + d, v.y + d, v.z + d);
		}
		
		public static DVector3 operator+ (double d, DVector3 v)
		{
			return new DVector3 (v.x + d, v.y + d, v.z + d);
		}
		
		// -
		public static DVector3 operator- (DVector3 a, DVector3 b)
		{
			return new DVector3 (a.x - b.x, a.y - b.y, a.z - b.z);
		}
		
		public static DVector3 operator- (Vector3 a, DVector3 b)
		{
			return new DVector3 (a.x - b.x, a.y - b.y, a.z - b.z);
		}
		
		public static DVector3 operator- (DVector3 a, Vector3 b)
		{
			return new DVector3 (a.x - b.x, a.y - b.y, a.z - b.z);
		}
		
		public static DVector3 operator- (DVector3 v, double d)
		{
			return new DVector3 (v.x - d, v.y - d, v.z - d);
		}
		
		public static DVector3 operator- (double d, DVector3 v)
		{
			return new DVector3 (v.x - d, v.y - d, v.z - d);
		}
		
		// *
		public static DVector3 operator* (DVector3 a, DVector3 b)
		{
			return new DVector3 (a.x * b.x, a.y * b.y, a.z * b.z);
		}
		
		public static DVector3 operator* (Vector3 a, DVector3 b)
		{
			return new DVector3 (a.x * b.x, a.y * b.y, a.z * b.z);
		}
		
		public static DVector3 operator* (DVector3 a, Vector3 b)
		{
			return new DVector3 (a.x * b.x, a.y * b.y, a.z * b.z);
		}
		
		public static DVector3 operator* (DVector3 v, double d)
		{
			return new DVector3 (v.x * d, v.y * d, v.z * d);
		}
		
		public static DVector3 operator* (double d, DVector3 v)
		{
			return new DVector3 (v.x * d, v.y * d, v.z * d);
		}
		
		// /
		public static DVector3 operator/ (DVector3 a, DVector3 b)
		{
			return new DVector3 (a.x / b.x, a.y / b.y, a.z / b.z);
		}
		
		public static DVector3 operator/ (Vector3 a, DVector3 b)
		{
			return new DVector3 (a.x / b.x, a.y / b.y, a.z / b.z);
		}
		
		public static DVector3 operator/ (DVector3 a, Vector3 b)
		{
			return new DVector3 (a.x / b.x, a.y / b.y, a.z / b.z);
		}
		
		public static DVector3 operator/ (DVector3 v, double d)
		{
			return new DVector3 (v.x / d, v.y / d, v.z / d);
		}
		
		public static DVector3 operator/ (double d, DVector3 v)
		{
			return new DVector3 (v.x / d, v.y / d, v.z / d);
		}
		
		// ==
		public static bool operator== (DVector3 a, DVector3 b)
		{
			return (a.x == b.x) && (a.y == b.y) && (a.z == b.z);
		}
		
		public static bool operator== (Vector3 a, DVector3 b)
		{
			return (a.x == b.x) && (a.y == b.y) && (a.z == b.z);
		}
		
		public static bool operator== (DVector3 a, Vector3 b)
		{
			return (a.x == b.x) && (a.y == b.y) && (a.z == b.z);
		}
		
		// !=
		public static bool operator!= (DVector3 a, DVector3 b)
		{
			return (a.x != b.x) || (a.y != b.y) || (a.z == b.z);
		}
		
		public static bool operator!= (Vector3 a, DVector3 b)
		{
			return (a.x != b.x) || (a.y != b.y) || (a.z == b.z);
		}
		
		public static bool operator!= (DVector3 a, Vector3 b)
		{
			return (a.x != b.x) || (a.y != b.y) || (a.z == b.z);
		}
		
		#endregion
	}
}