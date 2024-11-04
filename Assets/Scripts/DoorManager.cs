using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour, IPointerClickHandler
{
    public GameObject gameManager;
    public GameObject sManager;

    private ButtonsBehaviour buttonsBehaviour;
    private DialogueManager dialogueManager;
    private SoundManager soundManager;

    public string[] dialogueDoor1 = { "Es la puerta para salir" };
    public string[] dialogueDoor2 = { "Voy a ignorar esa sugerencia" };

    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        soundManager = sManager.GetComponent<SoundManager>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (buttonsBehaviour.GetuseBtn())
        {
            buttonsBehaviour.resetBtn();
            StartCoroutine(HandleDoorUse());
        }
        if (buttonsBehaviour.GetlookBtn())
        {
            dialogueManager.setDialogues(dialogueDoor1);
            dialogueManager.StartDialogue();
            buttonsBehaviour.resetBtn();
        }
        if (buttonsBehaviour.GetcatchBtn())
        {
            dialogueManager.setDialogues(dialogueDoor2);
            dialogueManager.StartDialogue();
            buttonsBehaviour.resetBtn();
        }
    }

    private IEnumerator HandleDoorUse()
    {
        soundManager.SeleccionAudio(9, 0.5f);

        // Espera 1 segundo
        yield return new WaitForSeconds(1f);

        // Carga la nueva escena
        SceneManager.LoadScene("StartScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
