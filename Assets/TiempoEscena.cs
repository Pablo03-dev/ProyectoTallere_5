using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiempoEscena : MonoBehaviour
{
    public float tiempo_start;
    public float tiempo_end;

    public int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo_start += Time.deltaTime;
        if (tiempo_start >= tiempo_end)
        {
            Application.LoadLevel(sceneIndex);
        }
    }
}
