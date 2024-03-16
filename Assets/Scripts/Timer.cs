using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public bool isPlaying;
    public float threshold = 30.0f;
    public float elapsedTime;
    public bool time;
    public TextMeshProUGUI timerText;
    private GameManager4BallCatcher gameManager;
    void Awake() 
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0.0f;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager4BallCatcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time == true)
        {
            elapsedTime += Time.deltaTime;
            string formattedTime = System.TimeSpan.FromSeconds(elapsedTime).ToString("mm\\:ss");
            Debug.Log(formattedTime);
            timerText.SetText("Time: " + formattedTime);

            if(elapsedTime > threshold)
            {
                Debug.Log("Time out!");
                elapsedTime = 0.0f;
                isPlaying = false;
                time = false;
                gameManager.GameOver();
            }
        } 
    }
}
