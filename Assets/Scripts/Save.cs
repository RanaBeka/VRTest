using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            var ball = collision.gameObject.GetComponent<Ball>();

            if ( ball.hasBallCollided)
            {
                GameManager.SaveGoal();
                ball.hasBallCollided = true;

                ball.transform.GetChild(1).gameObject.SetActive(true);

                ball.transform.GetChild(0).gameObject<MeshRenderer>().enabled = false;

                Invoke("DestroyBall", 3f);

                GetComponentInParent<XRBaseController>().SendHapticImpulse(.5f, .25f);
            }
        }
    }

    void DestroyBall(GameObject ballToDestroy)
    {
        Destroy(ballToDestroy);
    }
}
