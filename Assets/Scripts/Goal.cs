using LevelUp.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            var ball = collision.gameObject.GetComponent<Ball>();

            //if (ball.hasBallCollided)
            {
                GameManager.Goal();
                //ball.HasBallCollided = true;
            }
        }
    }
}
