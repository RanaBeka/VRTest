using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour 
{

	// Singleton instance
	public static BallMovement Instance;

	// public variables
	public Rigidbody ballPrefab;
	public Transform target;

	// private variables
	int mouseCount = 0;
	Vector3 delta;
	Vector3 pos;
	

	// Use this for initialization
	void Start () 
	{
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		

		
		

		
                   

			
	}

	public void KickBall ()
	{
		Rigidbody rBody = Instantiate (ballPrefab, new Vector3 (0.0f, 0.35f,0), Quaternion.identity) as Rigidbody;
		rBody.AddForce (target.forward * 2000);
		rBody.AddForce (target.up * Random.Range (400, 481));

		int _random = Random.Range (0, 3);
		switch (_random)
		{
		case 0:
			rBody.AddForce (target.right * Random.Range (100, 301));
			break;
			
		case 1:
			rBody.AddForce (-target.right * Random.Range (100, 301));
			break;
		}
	}

	void ResetCount ()
	{
		mouseCount = 0;
	}
}
