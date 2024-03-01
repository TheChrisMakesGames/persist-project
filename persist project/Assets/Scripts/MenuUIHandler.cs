using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToHome() 
    {
        SceneManager.LoadScene(0);
    }

    public void GoToStart() 
    {
        SceneManager.LoadScene(1);
    }

    public void LeaveGame() 
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }

    public void StartBallNinja() 
    {
        SceneManager.LoadScene(2);
    }
}
