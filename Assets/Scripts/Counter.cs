using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Counter : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI EndScoreText;
    public bool counting = false;
    public int Score = 0;

    private void Start()
    {
        Score = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(counting == true)
        {
            Score += 1;
            PlayerDataHandleX.Instance.Score = Score;
            ScoreText.text = "Score : " + Score;
        }
    }
}
