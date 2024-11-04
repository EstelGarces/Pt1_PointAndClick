using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CafetraProperties : MonoBehaviour, IPointerClickHandler
{
    public GameObject gameManager;
    public GameObject inventoryManager;
    public GameObject tProperties;
    public GameObject sManager;

    private ButtonsBehaviour buttonsBehaviour;
    private DialogueManager dialogueManager;
    private InventarioManager inventarioManager;
    private TazaProperties tazaProperties;
    private SoundManager soundManager;

    public string[] dialogueCafetera1 = { "Es una cafetera" };
    public string[] dialogueCafetera2 = { "Si tuvieras un vaso podrías llenarlo" };
    public string[] dialogueCafetera3 = { "¡No te puedes llevar la cafetera!" };

    private int indexObj;
    private string heldObj;
    private string objUsable = "taza";

    // Start is called before the first frame update
    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        inventarioManager = inventoryManager.GetComponent<InventarioManager>();
        tazaProperties = tProperties.GetComponent<TazaProperties>();
        soundManager = sManager.GetComponent<SoundManager>();

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (buttonsBehaviour.GetlookBtn())
        {
            dialogueManager.setDialogues(dialogueCafetera1);
            dialogueManager.StartDialogue();
            buttonsBehaviour.resetBtn();
        }
        if (buttonsBehaviour.GetuseBtn())
        {
            dialogueManager.setDialogues(dialogueCafetera2);
            dialogueManager.StartDialogue();
            buttonsBehaviour.resetBtn();
        }
        if (buttonsBehaviour.GetcatchBtn())
        {
            dialogueManager.setDialogues(dialogueCafetera3);
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
            soundManager.SeleccionAudio(5, 0.5f);

            Debug.Log(heldObj == objUsable);
            tazaProperties.LlenarTaza();
            tazaProperties.ActivarTaza();
            inventarioManager.RemoveItem(indexObj);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
