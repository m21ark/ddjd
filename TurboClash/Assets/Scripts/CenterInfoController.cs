using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CenterInfoController : MonoBehaviour
{
    public TextMeshProUGUI info_txt;
    public GameObject info_canvas;
    
    private void hidePanel(){
        info_canvas.SetActive(false);
    }

    private void showPanel(){
        info_canvas.SetActive(true);
    }

    public void showInfo(string info){
        showPanel();
        info_txt.text = info;
        info_canvas.SetActive(true);
        Invoke("hidePanel", 3.0f);
    }

    public void countdown(){
        showInfo("3");
        Invoke("CountdownToShowInfo2", 1.0f);
        Invoke("CountdownToShowInfo1", 2.0f);
        Invoke("CountdownToShowInfoGO", 3.0f);
    }

    private void CountdownToShowInfo2(){
        showInfo("2");
    }

    private void CountdownToShowInfo1(){
        showInfo("1");
    }

    private void CountdownToShowInfoGO(){
        showInfo("GO!");
    }

    public void goal(int player){
        showInfo("Player " + player + " scored!");
        Invoke("countdown", 3.0f);
    }

    public void ShowMessage(string message, float duration){
        showInfo(message);
        Invoke("hidePanel", duration);
    }
}
