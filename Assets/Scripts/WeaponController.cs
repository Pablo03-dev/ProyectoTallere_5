using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private UnityEvent enPistola;
    [SerializeField] private UnityEvent enGranada;
    [SerializeField] private UnityEvent enCuchillo;

    [Header("Keybinds")]
    public KeyCode inGun = KeyCode.Alpha1;
    public KeyCode inGrenade = KeyCode.Alpha2;
    public KeyCode inKnife = KeyCode.Alpha3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(inGun))
        {
            enPistola?.Invoke();
        }

        if (Input.GetKey(inGrenade))
        {
            enGranada?.Invoke();
        }

        if (Input.GetKey(inKnife))
        {
            enCuchillo?.Invoke();
        }
    }
}
