using Meta.XR.ImmersiveDebugger.UserInterface.Generic;
using Oculus.Interaction.Samples;


namespace LevelUp.Manager
{

    using UnityEngine;
    using UnityEngine.Analytics;
    using UnityEngine.UI;
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

    static int goalAmount;

    public static int goalCount
    {
        get { return goalAmount; }
    }

    public static int SaveAmount
    {
        get {return SaveAmount;}
    }

    [SerializeField] CountdownTimer countdownCanvas;
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject retryCanvas;
    [SerializeField] GameObject topScoreCanvas;
    [SerializeField] Button gameStartButton;
    [SerializeField] ControllerToggle ControllerToggle;
        


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
                DontDestroyOnLoad(this);
            }

            gameState = GameState.Start;

            gameStartButton.onClick.AddListener(() => GameStart());

        }

        void GameStart()
        {
            countdownCanvas.transform.parent.gameObject.SetActive(true);
            countdownCanvas.StartCountdown();
            Invoke("Activation", 4f);
        }

        void Activation()
        {
            scoreCanvas.SetActive(true);
            onStart.Invoke();
            gameState = GameState.Active;
        }

        public static void Goal()
        {
            if (gameState != GameState.Active) 
                return;

            goalAmount++;
            onGoal.Invoke(goalAmount);
        }

        public static void SaveGoal()
        {
            if (gameState != GameState.Active)
                return;

            saveAmount++;
            onSave.Invoke(SaveAmount);
        }

        public void GameOver()
        {
            gameState = GameState.Over;

            TopScoreCheck();

            scoreCanvas.SetActive(false);
            retryCanvas.SetActive(true);
            topScoreCanvas.SetActive(true);

            controllerToggle.ToggleControllerControl();

            onEnd.Invoke();
        }

        public void Reset()
        {
            SaveAmount = 0;
            goalAmount = 0;
            GameStart();
            controllerToggle.ToggleControllerControl();

        }

        void TopScoreCheck()
        {
            if (SaveAmount > PlayerPrefs.GetInt("SavedScore") || PlayerPrefs.HasKey("SavedScore") == false)
            {
                PlayerPrefs.SetInt("SavedScore", SaveAmount);
            }
        }

        public void KillAllBalls()
        {
            var loadsOfBalls = GameObject.FindGameObjectsWithTag("Ball");

            foreach (GameObject ball in loadsOfBalls)
            {
                Destroy(ball);
            }
        }


        

    }
}
