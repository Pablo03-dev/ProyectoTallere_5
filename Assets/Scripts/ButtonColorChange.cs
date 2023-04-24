using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour
{

   // public Color 
    
    //public Material myMaterial;

    //public Color myColor;
    public GameObject btn;
    public Color colorA;
    public Color colorB;
    [Range(0f, 1f)]
    public float transparencia = 0, transitionSpeed = 1;
    [SerializeField] private Image panelPistola;
    bool canButton = true;
    public enum Modo
    {
        Show = 0,
        Hide = 1,
        Nothing = -1,
    };

    public Modo modo;

    private void Start()
    {
        //modo = Modo.Nothing;
        //panelPistola = GetComponent<Image>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    modo = Modo.Hide;
        //}

        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    modo = Modo.Show;
        //}

        //if (modo.Equals(Modo.Hide))
        //{
        //    if (transparencia <= 0)
        //    {
        //        modo = Modo.Nothing;
        //        transparencia -= Time.deltaTime;
        //        panelPistola.color = new Color(panelPistola.color.r, panelPistola.color.g, panelPistola.color.b, transparencia);
        //    }

            
        //}

        //if (modo.Equals(Modo.Show))
        //{
        //    if (transparencia >= 1)
        //    {
        //        modo = Modo.Nothing;

        //        transparencia += Time.deltaTime / 2;
        //        panelPistola.color = new Color(panelPistola.color.r, panelPistola.color.g, panelPistola.color.b, transparencia);
        //    }

            
        //}


    }

    //public void Activate()
    //{
    //    canButton = true;
    //}

    public void BajarColor()
    {
        //btn.GetComponent<Image>().color = new Color(btn.GetComponent<Image>().color.r, btn.GetComponent<Image>().color.g, btn.GetComponent<Image>().color.b, 80);

        gameObject.GetComponent<Image>().color = colorB;
    }

    public void SubirColor()
    {
        //btn.GetComponent<Image>().color = new Color(btn.GetComponent<Image>().color.r, btn.GetComponent<Image>().color.g, btn.GetComponent<Image>().color.b, 230);

        gameObject.GetComponent<Image>().color = colorA;
    }
}
