using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyHpZone : MonoBehaviour
{
    public int daño;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //GameManager.manager.QuitarVidas(daño);
            //Audiomanager.PlaySound("HuidaPanda");
            //CameraShake.instance.StartShake(0.1f, 0.1f);
            //Destroy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.manager.QuitarVidas(daño);
        }
    }
}
