using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivarAlgo : MonoBehaviour
{
    [SerializeField] private UnityEvent Presionado;
    [SerializeField] private UnityEvent Suelto;

    [Header("Keybinds")]
    public KeyCode ActivarKey = KeyCode.T;
    public KeyCode DesactivarKey = KeyCode.G;



    private void Update()
    {
        if (Input.GetKey(ActivarKey))
        {
            Presionado?.Invoke();
        }

        if (Input.GetKey(DesactivarKey))
        {
            Suelto?.Invoke();
        }
       
    }

    
  

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Bola"))
    //    {
    //        Presionado?.Invoke();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Bola"))
        //{
        //    Presionado?.Invoke();
        //    Audiomanager.PlaySound("BolaInicia");
        //}
    }
}
