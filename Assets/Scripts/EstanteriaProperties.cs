using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.Universal.ShaderGUI.LitGUI;
using UnityEngine.EventSystems;

public class EstanteriaProperties : MonoBehaviour, IPointerClickHandler
{
    public GameObject gameManager;
    public GameObject inventoryManager;
    public GameObject lProperties;
    public GameObject sManager;

    private ButtonsBehaviour buttonsBehaviour;
    private DialogueManager dialogueManager;
    private InventarioManager inventarioManager;
    private LibroProperties libroProperties;
    private SoundManager soundManager;

    public string[] dialogueEstanteria1 = { "Hay libros para leer mientras te tomas el café" };
    public string[] dialogueEstanteria2 = { "A ver este libro" };
    public string[] dialogueEstanteria3 = { "¡Como me voy a llevar la estantería!" };
    public string[] dialogueEstanteria4 = { "Puedo dejar el libro que he cogido antes" };

    private bool bookLooked = false;
    private int indexObj;
    private string heldObj;
    private string objUsable = "libro";

    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        inventarioManager = inventoryManager.GetComponent<InventarioManager>();
        libroProperties = lProperties.GetComponent<LibroProperties>();
        soundManager = sManager.GetComponent<SoundManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (buttonsBehaviour.GetlookBtn())
        {
            dialogueManager.setDialogues(dialogueEstanteria1);
            dialogueManager.StartDialogue();
            buttonsBehaviour.resetBtn();
        }
        if (buttonsBehaviour.GetuseBtn())
        {
            if (!bookLooked)
            {
                dialogueManager.setDialogues(dialogueEstanteria2);
                soundManager.SeleccionAudio(7, 0.3f);

                libroProperties.ActivarLibro();
                //libroProperties.SetImage();
                bookLooked = true;
            }
            else
            {
                dialogueManager.setDialogues(dialogueEstanteria4);
            }
            dialogueManager.StartDialogue();
            buttonsBehaviour.resetBtn();
        }
        if (buttonsBehaviour.GetcatchBtn())
        {
            dialogueManager.setDialogues(dialogueEstanteria3);
            dialogueManager.StartDialogue();
            buttonsBehaviour.resetBtn();
        }
    }
    public void UsarObj()
    {
        indexObj = inventarioManager.GetIndexItem();
        heldObj = inventarioManager.GetHeldItem();
        Debug.Log("obj en la mano " + heldObj);

        Debug.Log(heldObj == objUsable);

        if (heldObj == objUsable)
        {
            Debug.Log(heldObj == objUsable);
            soundManager.SeleccionAudio(6, 0.8f);

            bookLooked = false;
            libroProperties.DesactivarLibro();
            inventarioManager.RemoveItem(indexObj);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

}
