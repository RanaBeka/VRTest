using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject goalkeeperPrefab;
    public Transform goalPosition;
    public float spawnInterval = 2f;
    public int maxRounds = 5;

    private GameObject currentBall;
    private GameObject currentGoalkeeper;
    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;
    private int roundNumber = 1;

    void Start()
    {
        SpawnNewBall();
        StartCoroutine(SpawnBalls());
    }

    void SpawnNewBall()
    {
        currentGoalkeeper = Instantiate(goalkeeperPrefab);
        currentGoalkeeper.transform.position = goalPosition.position + Vector3.up * 0.5f;
       
    }

    IEnumerator SpawnBalls()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (currentBall != null)
                Destroy(currentBall);

            SpawnNewBall();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            CheckGoal();
        }
    }

    void CheckGoal()
    {
        if (currentGoalkeeper.transform.position.y < goalPosition.position.y)
        {
            Debug.Log($"Round {roundNumber}: Goalkeeper missed!");
            scorePlayer1++;
            roundNumber++;

            if (scorePlayer1 >= maxRounds)
            {
                Debug.Log("Player 1 wins!");
                EndGame();
            }
            else
            {
                SpawnNewBall();
            }
        }
        else
        {
            Debug.Log($"Round {roundNumber}: Goalkeeper saved!");
            scorePlayer2++;
            roundNumber++;

            if (scorePlayer2 >= maxRounds)
            {
                Debug.Log("Player 2 wins!");
                EndGame();
            }
            else
            {
                SpawnNewBall();
            }
        }
    }

    void EndGame()
    {
        // Implementar lógica de fin del juego aquí
    }
}
