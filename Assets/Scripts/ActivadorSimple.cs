using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivadorSimple : MonoBehaviour
{
    [SerializeField] private UnityEvent Cortado;

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
        if (other.gameObject.CompareTag("Melee"))
        {
            Cortado?.Invoke();
        }

        //if (other.gameObject.CompareTag("Player"))
        //{
        //    Cortado?.Invoke();
        //}
    }
}
