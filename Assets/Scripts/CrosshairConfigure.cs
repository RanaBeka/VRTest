using UnityEngine;
using System.Collections;

public class CrosshairConfigure : MonoBehaviour 
{
	
	// Singleton instance
	public static CrosshairConfigure Instance;
	
	// public variables
	public Camera cameraFacing;

	// private variables
	MeshRenderer mr;
	float r;
	float g;
	float b;

	// Use this for initialization
	void Start () 
	{
		Instance = this;

		mr = GetComponent<MeshRenderer>();
		r = mr.material.color.r;
		g = mr.material.color.g;
		b = mr.material.color.b;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = cameraFacing.transform.position + cameraFacing.transform.rotation * Vector3.forward;
		transform.LookAt (cameraFacing.transform.position);

		GetComponent<MeshRenderer>().material.color = new Color (r, g, b, 0.2f);

		Ray ray = new Ray (transform.position, -transform.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit))
		{
			if  (hit.collider.gameObject.name.Equals ("Crosshair Range"))
			{
				GetComponent<MeshRenderer>().material.color = new Color (r, g, b, 1.0f);
			}
		}
	}
}
