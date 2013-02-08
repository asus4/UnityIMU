using UnityEngine;

[RequireComponent(typeof(MicAnalyzer))]
[AddComponentMenu("Wireframe/GL Mic Visualiser")]
public class GLMicVisualiser : GLDrawerBase {
	
	[SerializeField]
	float size = 0.3f;
	
	[SerializeField]
	float amp = 0.1f;
	
	[SerializeField]
	Color color;
	
	MicAnalyzer analyzer;
	
	void Start ()
	{
		analyzer = GetComponent<MicAnalyzer> ();
	}
	
	void Update ()
	{
		//string msg = string.Format ("RMS: {0:0.00} ({1:0.0} dB) Pitch: {2:0} Hz", analyzer.RMS, analyzer.DB, analyzer.Pitch);
		//Debug.Log (msg);
	}
	
	protected override void OnDraw ()
	{
		float[] samples = analyzer.Samples;
		int i;
		float pi2 = Mathf.PI * 2;
		//float pos
		
		GL.Begin (GL.LINES);
		GL.Color (color);
		
		for (i=1; i<1024; i+=3) {
			rotPos (i / 1024.0f * pi2, Mathf.Pow(samples [i], 2));
		}
		GL.End ();		
	}
	
	void rotPos (float rot, float volume)
	{
		float x = Mathf.Cos (rot);
		float y = Mathf.Sin (rot);
		
		//Debug.Log (volume);
		float len = size - volume * amp;
		GL.Vertex3 (x * len, y * len, 0);
		len = size + volume * amp;
		GL.Vertex3 (x * len, y * len, 0);
	}
}


