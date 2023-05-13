using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    [SerializeField] private GameObject señalDialogo;
    [SerializeField, TextArea(4, 6)] private string[] dialogoLineas;

    [SerializeField] private GameObject dialogoPanel;
    [SerializeField] private TMP_Text dialogoTexto;

    private float typingTime = 0.05f;

    private bool isPlayerInRange;
    private bool dialogoStart;
    private int lineIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogoStart)
            {
                StartDialogo();
            }
            else if (dialogoTexto.text == dialogoLineas[lineIndex])
            {
                NextDialogo();
            }
            else
            {
                StopAllCoroutines();
                dialogoTexto.text = dialogoLineas[lineIndex];
            }
        }
    }

    private void StartDialogo()
    {
        dialogoStart = true;
        dialogoPanel.SetActive(true);
        señalDialogo.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogo()
    {
        lineIndex++;
        if (lineIndex < dialogoLineas.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            dialogoStart = false;
            dialogoPanel.SetActive(false);
            señalDialogo.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogoTexto.text = string.Empty;

        foreach (char ch in dialogoLineas[lineIndex])
        {
            dialogoTexto.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            señalDialogo.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            señalDialogo.SetActive(false);
        }
    }
}
