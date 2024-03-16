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
    private Timer timer;
    private Counter counter;
    public Button backToStart;
    public GameObject endScreen;
    public GameObject startScreen;
    public GameObject instructionsPanelOne;
    public GameObject instructionsPanelTwo;
    public TextMeshProUGUI compliment;
    public TextMeshProUGUI score;
    public bool instructions; 
    public bool gameOver = false;
    public bool gameActive;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        counter = GameObject.Find("Crate").GetComponent<Counter>();
        backToStart.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartInstructions()
    {
        startScreen.gameObject.SetActive(false);
        instructions = true;
        instructionsPanelOne.gameObject.SetActive(true);
    }
    public void NextPage()
    {
        instructionsPanelOne.gameObject.SetActive(false);
        instructionsPanelTwo.gameObject.SetActive(true);
    }
    public void StartGame()
    {
        StartCoroutine(SpawnBalls());
        instructions = false;
        gameActive = true;
        timer.time = true;
        counter.counting = true;
        instructionsPanelTwo.gameObject.SetActive(false);
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

            if(counter.Score < 5) {
                compliment.SetText("Better Luck Next Time!");
            } else if(counter.Score > 5 && counter.Score < 10) {
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
            yield return new WaitForSeconds(2.5f);
            int ballIndex = Random.Range(0, ballPrefabs.Count);
            Instantiate(ballPrefabs[ballIndex]);
        }

    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
