using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHandleX : MonoBehaviour
{
    public static PlayerDataHandleX Instance;
    public string PlayerName;
    public int Score;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
