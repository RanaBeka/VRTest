using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;
    public int roundNumber = 1;

    public void AddPoint(int playerNumber, int points)
    {
        switch (playerNumber)
        {
            case 1:
                player1Score += points;
                break;
            case 2:
                player2Score += points;
                break;
        }
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (player1Score >= 5 || player2Score >= 5)
        {
            // Manejar la condición de victoria aquí
        }
    }
}
