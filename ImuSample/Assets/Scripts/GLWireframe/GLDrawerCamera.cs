using UnityEngine;

/// <summary>
/// GL drawer camera.
/// </summary>
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Wireframe/GL Drawer Camera")]
public class GLDrawerCamera : MonoBehaviour {
	
	[SerializeField]
	Material mat;
	
	[SerializeField]
	GLDrawerBase[] drawers;
	
	[SerializeField]
	int antiAliasing = 2;
	
	Camera _camera;
	
	void Start ()
	{
		QualitySettings.antiAliasing = antiAliasing;
		
		// cache
		_camera = this.camera;
	}
	
	void OnPreRender ()
	{
		GL.wireframe = true;
	}

	void OnPostRender ()
	{
		GL.wireframe = false;
		
		GL.PushMatrix ();
		mat.SetPass (0);
		
		Matrix4x4 mtx = _camera.cameraToWorldMatrix;
		foreach (var drawer in drawers) {
			drawer.Draw (mtx);
		}
		
		GL.PopMatrix ();
	}
}