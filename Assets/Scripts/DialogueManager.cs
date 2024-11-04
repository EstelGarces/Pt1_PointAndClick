using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string[] dialogues;
    public float letterDelay = 0.05f; //Delay entre cada letra
    private Coroutine typingCoroutine;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();
    }
    public void StartDialogue()
    {
        if (!isActive)
        {
            typingCoroutine = StartCoroutine(TypeDialogue());
        }
    }

    IEnumerator TypeDialogue()
    {
        isActive = true;
        foreach (string dialogue in dialogues)
        {
            textMeshPro.text = "";
            foreach (char letter in dialogue)
            {
                textMeshPro.text += letter;
                yield return new WaitForSeconds(letterDelay);
            }
        }
        isActive = false;
    }

    public void SkipDialogue()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
            textMeshPro.text = dialogues[dialogues.Length - 1];
        }

    }

    public void setDialogues(string[] text)
    {
        dialogues = text;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
