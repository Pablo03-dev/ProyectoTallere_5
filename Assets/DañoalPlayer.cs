using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoalPlayer : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.manager.QuitarVidas(daño);
        }
    }
}
