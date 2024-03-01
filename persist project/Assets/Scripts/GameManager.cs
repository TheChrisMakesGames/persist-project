using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public Button restartButton;
    public GameObject titleScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public TextMeshProUGUI livesText;
    public bool isGameActive;
    private int score;
    private int lives;
    // Start is called before the first frame update
    void Start()
    {

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

    public void GameOver()
    {
       gameOverText.gameObject.SetActive(true);
       restartButton.gameObject.SetActive(true); 
       isGameActive = false;       
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
}