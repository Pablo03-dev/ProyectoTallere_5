using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Balaplayer : MonoBehaviour
{
    //[SerializeField] private float velocidad;
    [SerializeField] private int daño;
    //[SerializeField] private float tiempoDeVida;

    //private Action<Balaplayer> desactivarAccion;

    //private void OnEnable()
    //{
    //    StartCoroutine(DesactivarTiempo());
    //}

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            //collision.ge
            //desactivarAccion(this);
            GetComponent<HPSystem>().TakeHealth(daño);
        }

        if (collision.gameObject.tag == "Piso")
        {
            //Destroy(gameObject);
        }

        
    }

    //private IEnumerator DesactivarTiempo()
    //{
    //    yield return new WaitForSeconds(tiempoDeVida);
    //    desactivarAccion(this);
    //}

    //public void DesactivarBala(Action<Balaplayer> desactivarAccionParametro)
    //{
    //    desactivarAccion = desactivarAccionParametro;
    //}
}
