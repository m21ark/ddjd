using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class TimeTicker : MonoBehaviour
{
    public TextMeshProUGUI timeTextMesh;

    // Start is called before the first frame update
    void Start()
    {
        if (timeTextMesh == null)
            Debug.LogError("TimeTextMesh is not assigned!");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeTextMesh == null)
            return;

        // Get the current time in minutes and seconds
        int minutes = Mathf.FloorToInt(Time.time / 60F);
        int seconds = Mathf.FloorToInt(Time.time % 60F);

        // Update the text to display MM:SS format
        timeTextMesh.text = String.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

