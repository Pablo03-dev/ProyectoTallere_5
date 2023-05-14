using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurarhp : MonoBehaviour
{
    public int sanar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.manager.RestaurarHp(sanar);
        }
    }
}
