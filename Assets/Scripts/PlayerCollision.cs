using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour 
{

	// Singleton Instance
	public static PlayerCollision Instance;

	// private variables
	GameObject goalSaveCount;
	Rigidbody rb;
	TextMesh tm;

	// Use this for initialization
	void Start () 
	{
		Instance = this;

		rb = GetComponent<Rigidbody>();

		goalSaveCount = GameObject.Find ("Goal Save Count");
		tm = goalSaveCount.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name.Equals ("OVR (Player)"))
		{
			if (!gameObject.GetComponent<BallInventory>().isGoalSaved)
			{
				rb.AddForce (-transform.forward * Random.Range (100, 340));
				rb.AddForce (transform.up * Random.Range (100, 250));

				int _random = Random.Range (0, 3);
				switch (_random)
				{
				case 0:
					rb.AddForce (transform.right * Random.Range (100, 350));
					break;

				case 1:
					rb.AddForce (-transform.right * Random.Range (100, 350));
					break;
				}

				gameObject.GetComponent<BallInventory>().isGoalSaved = true;

				Invoke ("CheckSuccessfulSave", 0.5f);
			}
		}
	}

	void CheckSuccessfulSave ()
	{
		if (!gameObject.GetComponent<BallInventory>().isGoalScored)
		{
			ScoreMeasurement.Instance.saveCount++;
			tm.text = "Goals Saved: "+ScoreMeasurement.Instance.saveCount.ToString ();
		}
	}
}
