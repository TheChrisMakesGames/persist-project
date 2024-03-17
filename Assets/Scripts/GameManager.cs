using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject endScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI CurrentPlayerName;
    public TextMeshProUGUI BestPlayerNameAndScore;
    private static int BestScore;
    private static string BestPlayer; 
    public bool isGameActive;
    private int score;
    private int lives;

    private void Awake()
    {
        LoadGameRankX();
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentPlayerName.text = "Player: " + PlayerDataHandleX.Instance.PlayerName;

        SetBestPlayer();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
        yield return new WaitForSeconds(spawnRate);
        int index = Random.Range(0, targets.Count);
        Instantiate(targets[index]);

        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        PlayerDataHandleX.Instance.Score = score;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int livesToDecrease)
    {
        lives += livesToDecrease;
        livesText.text = "Lives: " + lives;

        if(lives <= 0)
        {
            GameOver();
        }
    }
    private void CheckBestPlayer()
    {
        int CurrentScore = PlayerDataHandleX.Instance.Score;

        if (CurrentScore > BestScore)
        {
            BestPlayer = PlayerDataHandleX.Instance.PlayerName;
            BestScore = CurrentScore;

            BestPlayerNameAndScore.text = $"Best Score - {BestPlayer}: {BestScore}";

            SaveGameRank(BestPlayer, BestScore);
        }
    }
    public void GameOver()
    {
        endScreen.gameObject.SetActive(true);
        isGameActive = false;   
        CheckBestPlayer();    
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;

        spawnRate /= difficulty;
        StartCoroutine(SpawnTargets());
        UpdateScore(0);
        UpdateLives(3);
        titleScreen.gameObject.SetActive(false);
    }

    private void SetBestPlayer()
    {
        if (BestPlayer == null && BestScore == 0)
        {
            BestPlayerNameAndScore.text = "";
        }
        else
        {
            BestPlayerNameAndScore.text = $"Best Score - {BestPlayer}: {BestScore}";
        }

    }

    public void SaveGameRank(string bestPlaterName, int bestPlayerScore)
    {
        SaveData data = new SaveData();

        data.TheBestPlayer = bestPlaterName;
        data.HighiestScore = bestPlayerScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameRankX()
    {
        string path = Application.persistentDataPath + "/savefile.json";

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
