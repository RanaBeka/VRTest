using UnityEngine;
using System.Collections;

public class BallInventory : MonoBehaviour 
{

	// Singleton instance
	public static BallInventory Instance;

	// public variables
	public bool isGoalScored = false;
	public bool isGoalSaved = false;

	// Use this for initialization
	void Start () 
	{
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
