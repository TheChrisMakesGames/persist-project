using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class GameManager4BallCatcher : MonoBehaviour
{
    public List<GameObject> ballPrefabs;
    public float spawnRate = 2f;
    private Timer timer;
    private Counter counter;
    public Button backToStart;
    public GameObject endScreen;
    public GameObject startScreen;
    public GameObject instructionsPanelOne;
    public GameObject instructionsPanelTwo;
    public TextMeshProUGUI compliment;
    public TextMeshProUGUI score;
    public TextMeshProUGUI CurrentPlayerName;
    public TextMeshProUGUI BestPlayerNameAndScore;
    private static int BestScore;
    private static string BestPlayer; 
    public bool instructions; 
    public bool gameOver = false;
    public bool gameActive;

    private void Awake()
    {
        LoadGameRankX();
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        counter = GameObject.Find("Crate").GetComponent<Counter>();
        backToStart.gameObject.SetActive(true);

        CurrentPlayerName.text = "Player: " + PlayerDataHandleX.Instance.PlayerName;

        SetBestPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartInstructions()
    {
        instructions = true;

        startScreen.gameObject.SetActive(false);
        instructionsPanelOne.gameObject.SetActive(true);
    }
    public void NextPage()
    {
        instructionsPanelOne.gameObject.SetActive(false);
        instructionsPanelTwo.gameObject.SetActive(true);
    }
    public void StartGameX()
    {
        StartCoroutine(SpawnBalls());
        instructions = false;
        gameActive = true;
        timer.time = true;
        counter.counting = true;
        instructionsPanelTwo.gameObject.SetActive(false);
    }
    private void CheckBestPlayer()
    {
        int CurrentScore = PlayerDataHandleX.Instance.Score;

        if (CurrentScore > BestScore)
        {
            BestPlayer = PlayerDataHandleX.Instance.PlayerName;
            BestScore = CurrentScore;

            BestPlayerNameAndScore.text = $"Best Score - {BestPlayer}: {BestScore + 1}";

            SaveGameRank(BestPlayer, BestScore);
        }
    }
    public void GameOver()
    {
       if(timer.time == false)
       {
            endScreen.gameObject.SetActive(true);
            gameActive = false;   
            gameOver = true;    
            counter.counting = false;
            StopCoroutine(SpawnBalls());
            backToStart.gameObject.SetActive(false);
            CheckBestPlayer();
            if(counter.score < 5) {
                compliment.SetText("Better Luck Next Time!");
            } else if(counter.score > 5 && counter.score < 10) {
                compliment.SetText("Good Job!");
            } else {
                compliment.SetText("Wow! Great Job!");
            }
        }
    }
    IEnumerator SpawnBalls()
    {
        while (!gameOver && gameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int ballIndex = Random.Range(0, ballPrefabs.Count);
            Instantiate(ballPrefabs[ballIndex]);
        }

    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void SetBestPlayer()
    {
        if (BestPlayer == null && BestScore == 0)
        {
            BestPlayerNameAndScore.text = "";
        }
        else
        {
            BestPlayerNameAndScore.text = $"Best Score - {BestPlayer}: {BestScore + 1}";
        }

    }

    public void SaveGameRank(string bestPlaterName, int bestPlayerScore)
    {
        SaveData data = new SaveData();

        data.TheBestPlayer = bestPlaterName;
        data.HighiestScore = bestPlayerScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile-ball-catcher.json", json);
    }

    public void LoadGameRankX()
    {
        string path = Application.persistentDataPath + "/savefile-ball-catcher.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayer = data.TheBestPlayer;
            BestScore = data.HighiestScore;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int HighiestScore;
        public string TheBestPlayer;
    }
}

