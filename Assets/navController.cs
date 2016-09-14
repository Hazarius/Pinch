using UnityEngine;

public class navController : MonoBehaviour
{

	public NavMeshAgent agent;
	private NavMeshPath _path;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000f))
			{
				if (agent != null)
				{
					agent.destination = hit.point;
				}
			}
		}
	}
}
