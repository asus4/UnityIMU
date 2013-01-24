using UnityEngine;
using System.Collections;

/// <summary>
/// Only Editor Util
/// </summary>
[ExecuteInEditMode]
[AddComponentMenu("Editor/Grid Builder")]
public class GridBuilder : MonoBehaviour {
	
	#region field
	[SerializeField]
	GameObject gridPrefab;
	
	[SerializeField]
	Vector3 count;
	
	[SerializeField]
	Vector3 space;
	#endregion
	
	#region private
	Transform _transform;
	#endregion
	
	#region life cycle
	void Start ()
	{
		_transform = this.transform;
		
		if (transform.childCount > 0) {
			return;
		}
		
		if (Application.isPlaying) {
			return;
		}
		
		int x, y, z;
		
		for (x=0; x<count.x; ++x) {
			for (y=0; y<count.y; ++y) {
				for (z=0; z<count.z; ++z) {
					makeAt (new Vector3 (x, y, z));
					//yield return new WaitForSeconds(0.001f);
				}
			}
		}
	}
	#endregion
	
	#region private
	void makeAt (Vector3 index)
	{
		Vector3 position = new Vector3 (
			(index.x / count.x - .5f) * space.x,
			(index.y / count.y - .5f) * space.y,
			(index.z / count.z - .5f) * space.z
		);
		
		GameObject go = Instantiate (gridPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		go.layer = this.gameObject.layer;
		
		Transform t = go.transform;
		t.parent = _transform;
		t.localPosition = position;
	}
	#endregion
	
}
