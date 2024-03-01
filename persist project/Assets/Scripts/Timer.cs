using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public bool isPlaying;
    public TextMeshProUGUI txt;
    void Awake() 
    {
        txt = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying)
        {
            txt.text = Time.time.ToString("#.00");
        }
    }
}
