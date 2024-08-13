using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Text textDialog;
    [SerializeField] private string[] sentenceDialog;
    [SerializeField] private float interval;

    private int index;

    public bool startDialog;

    private void Start() 
    {
        index = 0;    
    }

    public void StartDialog()
    {
        ShowDialogWindow(true);
        StartCoroutine(OutputSentenceDialog());
        index++;
        
    }

    public void EndDialog()
    {
        textDialog.text = "";
        ShowDialogWindow(false);
    }

    private IEnumerator OutputSentenceDialog()
    {
        foreach (char c in sentenceDialog[index])
        {
            textDialog.text += c;
            yield return new WaitForSeconds(interval);
        }
    }

    private void ShowDialogWindow(bool state) => spriteRenderer.enabled = state;
}
