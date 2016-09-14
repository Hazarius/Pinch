using UnityEngine;
using UnityEngine.UI;

public class Recongnizer : MonoBehaviour {

	private bool isStarted;
	private Vector2 baseDir;
	private Vector2 basePerpendicular;
	private float baseAngle;
	private float basesig;
	private Vector3 _basePos;

	public Text txt1;
	public Text txt2;
	public Text txt3;
	public Text txt4;
	public void Update()
	{
		var t1 = Input.GetTouch(0);
		var t2 = Input.GetTouch(1);

		txt4.text = ("T1: " + t1.phase.ToString() + "\nT2: " + t2.phase.ToString());
		if (t1.phase == TouchPhase.Moved && t2.phase == TouchPhase.Moved)
		{
			if (!isStarted)
			{
				baseDir = (t2.position - t1.position).normalized;
				basePerpendicular = new Vector2(-baseDir.y, baseDir.x);
				baseAngle = Vector2.Angle(Vector2.up, baseDir);
				isStarted = true;
			}
			var currentDir = (t2.position - t1.position).normalized;
			var sig = (Vector2.Dot(currentDir, basePerpendicular) > 0 ? 1 : -1);

			var tempAngle = Vector2.Angle(baseDir, currentDir);

			var absoluteAngle = tempAngle * sig;
			var deltaAngle = Mathf.Abs(baseAngle - tempAngle) * sig;

			transform.eulerAngles = new Vector3(0, 0, absoluteAngle);
			txt1.text = absoluteAngle.ToString();
			txt2.text = sig.ToString();
			txt3.text = deltaAngle.ToString();
		}

		if (t1.phase == TouchPhase.Ended || t2.phase == TouchPhase.Ended)
		{
			isStarted = false;
		}

		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
