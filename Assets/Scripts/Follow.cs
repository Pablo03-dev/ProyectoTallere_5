using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform target;
    //public void Evaluado(float newspeed)
    //{
    //    speed = newspeed;
    //}
    // Start is called before the first frame update
    void Start()
    {
        //speed = 1;
        //if (GameManager.manager.timer > 10)
        //{
        //    speed = GameManager.manager.timer / 10;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.LookAt(target);
    }
}
