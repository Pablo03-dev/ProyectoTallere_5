using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : MonoBehaviour
{
    //public TMP_Text pointsText;
    private bool JuegoPausado = false;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        //pointsText.text = "Score: " + score.ToString();

        JuegoPausado = true;
        Pausa();
    }

    public void Pausa()
    {
        Time.timeScale = 0f;
        JuegoPausado = true;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
        JuegoPausado = false;
    }

    public void ExittButton(int escena)
    {
        SceneManager.LoadScene(escena);
        Time.timeScale = 1f;
    }
}
