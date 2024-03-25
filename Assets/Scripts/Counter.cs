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
    public int score = 0;

    private void Start()
    {
        score = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(counting == true)
        {
            PlayerDataHandleX.Instance.Score = score;
            score += 1;
            ScoreText.text = "Score : " + score;
        }
    }
}
