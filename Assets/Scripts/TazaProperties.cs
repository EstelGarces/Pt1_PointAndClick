using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TazaProperties : MonoBehaviour, IPointerClickHandler
{
    public GameObject gameManager;
    public GameObject inventoryManager;
    public GameObject sManager;

    private ButtonsBehaviour buttonsBehaviour;
    private DialogueManager dialogueManager;
    private InventarioManager inventarioManager;
    private SoundManager soundManager;

    public string[] dialogue01Taza = { "Una taza caliente de café" };
    public string[] dialogue02Taza = { "Una taza vacía" };
    public string[] dialogue03Taza = { "Ya te has bebido el café" };
    public string[] dialogue04Taza = { "La taza está llena" };

    public bool isEmpty = false;
    //public bool tazaGuardada = false;

    private Image imagenTaza;
    public Sprite tazaVacia, tazaLlena;
    private bool guardado;

    // Start is called before the first frame update
    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        inventarioManager = inventoryManager.GetComponent<InventarioManager>();
        imagenTaza = GetComponent<Image>();
        soundManager = sManager.GetComponent<SoundManager>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (buttonsBehaviour.GetuseBtn())
        {
            if (!isEmpty)
            {
                imagenTaza.sprite = tazaVacia;
                soundManager.SeleccionAudio(4, 0.7f);
                isEmpty = true;
            }
            else
            {
                dialogueManager.setDialogues(dialogue03Taza);
                dialogueManager.StartDialogue();
            }
            buttonsBehaviour.resetBtn();
        }
        if (buttonsBehaviour.GetlookBtn())
        {
            if (!isEmpty)
            {
                dialogueManager.setDialogues(dialogue01Taza);
            }
            else
            {
                dialogueManager.setDialogues(dialogue02Taza);
            }
            dialogueManager.StartDialogue();
            buttonsBehaviour.resetBtn();
        }
        if (buttonsBehaviour.GetcatchBtn())
        {
            if (!isEmpty)
            {
                dialogueManager.setDialogues(dialogue04Taza);
                dialogueManager.StartDialogue();
            }
            else
            {
                //imagenTaza.sprite = taza;
                guardado = inventarioManager.setInventario(tazaVacia, "taza");
                if (guardado)
                {
                    DesactivarTaza();
                }
            }
            buttonsBehaviour.resetBtn();
        }
    }

    public void LlenarTaza()
    {
        imagenTaza.sprite = tazaLlena;
        isEmpty = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivarTaza()
    {
        this.gameObject.SetActive(true);

    }

    public void DesactivarTaza()
    {
        this.gameObject.SetActive(false);
    }
}
