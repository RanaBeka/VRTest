using UnityEngine;
using System.Collections;

public class ScoreMeasurement : MonoBehaviour 
{

	// Singleton instance
	public static ScoreMeasurement Instance;

	// public variables
	public int saveCount = 0;
	public GameObject goalScoreCount;

	// private variables
	int scoreCount = 0;
	GameObject mScore;
	TextMesh tm;

	// Use this for initialization
	void Start () 
	{
		Instance = this;

		mScore = goalScoreCount.transform.parent.gameObject;
#if UNITY_ANDROID
		mScore.transform.position = new Vector3 (0, 0, 53);
#endif
#if UNITY_EDITOR
		mScore.transform.position = new Vector3 (0, 0, 5);
#endif

		tm = goalScoreCount.GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag.Equals ("Ball"))
		{
			if (!col.gameObject.GetComponent<BallInventory>().isGoalScored)
			{
				scoreCount++;
				tm.text = "Goals Scored: "+scoreCount.ToString ();

				col.gameObject.GetComponent<BallInventory>().isGoalScored = true;
			}
		}
	}
}
