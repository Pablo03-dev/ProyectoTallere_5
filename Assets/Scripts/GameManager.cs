using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public Slider barrahp;
    private int score;

    //public TMP_Text scoreText;


    //public Transform posReseteo;
    //public Rigidbody2D rb;

    //public float timer = 10;
    //private bool juegoPausado = false;

    public GameoverScreen GameOverScreen;


    private void Awake()
    {
        manager = this;
        //score = 0;
        //UpdatedScore();
        //Application.targetFrameRate = 60;


    }

    public void Start()
    {

    }

    public int vidas;
    public void GameOver()
    {
        print("EndGame");
        GameOverScreen.Setup(score);
    }


    public void WinGame()
    {

    }

    public void ResetearJuego()
    {

    }

    public void QuitarVidas(int restarhp)
    {
        vidas -= restarhp;
        barrahp.value = vidas;

        if(vidas < 1)
        {
            GameOver();
            //Over.Show();
        }
    }

    //void UpdatedScore()
    //{
    //    scoreText.text = "Score: " + score;
    //}

    //public void AddScore(int puntajesumaar)
    //{
    //    score += puntajesumaar;
    //    //Audiomanager.PlaySound("Coin");
    //    UpdatedScore();
    //}


    //public void ResetearPosicion(Transform _transform)
    //{
    //    _transform.position = posReseteo.position;
    //    rb.velocity = Vector2.zero;
    //}

    //private void Update()
    //{
    //    timer = Time.deltaTime + timer;
    //}

    //private void Update()
    //{
    //    if (juegoPausado)
    //    {
    //        Pausa();
    //    }
    //}
    //public void Pausa()
    //{
    //    juegoPausado = true;
    //    Time.timeScale = 0f;
    //    //botonPausa.SetActive(false);
    //    //menuPausa.SetActive(true);
    //}

}
