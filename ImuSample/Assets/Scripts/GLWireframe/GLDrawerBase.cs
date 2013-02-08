using UnityEngine;

[AddComponentMenu("Wireframe/GL Drawer Base")]
public abstract class GLDrawerBase : MonoBehaviour {
	//protected Matrix4x4 translateCenterMatrix = Matrix4x4.TRS (new Vector3 (0.5f, 0.5f, 0), Quaternion.identity, Vector3.one);
	
	public void Draw (Matrix4x4 camMatrix)
	{
		if (!this.enabled) {
			return;
		}
		
		GL.PushMatrix ();
		GL.MultMatrix (camMatrix);
		GL.MultMatrix (transform.localToWorldMatrix);
		//GL.MultMatrix (transform.localToWorldMatrix * camMatrix);
		OnDraw ();
		GL.PopMatrix ();
	}
	
	/// <summary>
	/// override this method to Draw GL
	/// </summary>
	protected abstract void OnDraw ();
}
