using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public static GameManager Instance
    {
        get { return instance; }
    }

    enum GameState
    {
        Start,
        Active,
        Over
    }
    static GameState gameState;

    public delegate void StartGame();
    public static event StartGame onStart;

    public delegate void EndGame();
    public static event EndGame onEnd;

    public delegate void goal(int goalAmount);
    public static event goal onGoal;

    public static float timerMaxTime = 120f;

    //// min 11:35
    
}
