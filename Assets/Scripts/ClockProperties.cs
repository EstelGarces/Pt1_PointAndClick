using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClockProperties : MonoBehaviour, IPointerClickHandler
{
    public GameObject gameManager;

    private ButtonsBehaviour buttonsBehaviour;
    private DialogueManager dialogueManager;
    private Animator animator;

    public Image fondo;
    //private Image imagenFondo;
    public Sprite noche, medianoche, dia, mañana;
    private Image imagenReloj;
    int i = 0;

    public Sprite[] horas;

    public string[] dialogue01Reloj = { "Son las 3" };
    public string[] dialogue02Reloj = { "Son las 6" };
    public string[] dialogue03Reloj = { "Son las 9" };
    public string[] dialogue04Reloj = { "Son las 12" };
    public string[] dialogueGuardar = { "¡No te puedes llevar el reloj!" };


    // Start is called before the first frame update
    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        animator = this.GetComponent<Animator>();

        imagenReloj = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (buttonsBehaviour.GetuseBtn())
        {

            imagenReloj.sprite = horas[i];
            switch (i)
            {
                case 0:
                    fondo.sprite = dia;
                    break;
                case 1:
                    fondo.sprite = noche;
                    break;
                case 2:
                    fondo.sprite = medianoche;
                    break;
                default:
                    fondo.sprite = mañana;
                    break;
            }
            buttonsBehaviour.resetBtn();

            i++;
            i = i % horas.Length;//circular, devuelve el resto, i = resto

        }
        if (buttonsBehaviour.GetlookBtn())
        {
            switch (i)
            {
                case 0:
                    dialogueManager.setDialogues(dialogue01Reloj);
                    break;
                case 1:
                    dialogueManager.setDialogues(dialogue02Reloj);
                    break;
                case 2:
                    dialogueManager.setDialogues(dialogue03Reloj);
                    break;
                default:
                    dialogueManager.setDialogues(dialogue04Reloj);
                    break;
            }
            dialogueManager.StartDialogue();
            buttonsBehaviour.resetBtn();
        }
        if (buttonsBehaviour.GetcatchBtn())
        {
            dialogueManager.setDialogues(dialogueGuardar);
            dialogueManager.StartDialogue();
            buttonsBehaviour.resetBtn();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
