using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparoenemigo : MonoBehaviour
{
    public int daño;
    //public float tiempoVida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.manager.QuitarVidas(daño);
        }

        if (collision.gameObject.tag == "Piso")
        {
            //gameObject.SetActive(false);
        }
    }
}
