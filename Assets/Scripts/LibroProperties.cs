using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LibroProperties : MonoBehaviour, IPointerClickHandler
{
    public bool isActive = false;
    public GameObject gameManager;
    public GameObject inventoryManager;
    //public GameObject eProperties;
    public GameObject sManager;

    private ButtonsBehaviour buttonsBehaviour;
    private DialogueManager dialogueManager;
    private InventarioManager inventarioManager;
    //private EstanteriaProperties estanteriaProperties;
    private Animator animator;
    private SoundManager soundManager;

    public string[] dialogueLibro1 = { "Va de ciencia ficción y aventura" };
    public string[] dialogueLibro2 = { "Había una vez una maga elfo, reconocida hace mucho tiempo por derrotar al rey demonio..." };
    public string[] dialogueLibro3 = { "Ya lo he leído" };
    public string[] dialogueLibro4 = { "El libro se titula Frieren: Beyond Journey's End" };

    public Sprite libro;
    private bool guardado;

    private Image imagenLibro;

    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        inventarioManager = inventoryManager.GetComponent<InventarioManager>();
        animator = this.GetComponent<Animator>();
        //estanteriaProperties = eProperties.GetComponent<EstanteriaProperties>();
        soundManager = sManager.GetComponent<SoundManager>();

        imagenLibro = GetComponent<Image>();
    }

   
    public void OnPointerClick(PointerEventData eventData)
    {
        if (buttonsBehaviour.GetlookBtn())
        {
            if (!isActive) 
            {
                dialogueManager.setDialogues(dialogueLibro4);
            }
            else
            {
                dialogueManager.setDialogues(dialogueLibro1);
            }
            dialogueManager.StartDialogue();
            buttonsBehaviour.resetBtn();
        }
        if (buttonsBehaviour.GetuseBtn())
        {
            if (!isActive)
            {
                dialogueManager.setDialogues(dialogueLibro2);
                isActive = true;
                animator.SetBool("isUsed", true);
                soundManager.SeleccionAudio(8, 0.5f);
            }
            else
            {
                dialogueManager.setDialogues(dialogueLibro3);
            }
            dialogueManager.StartDialogue();
            buttonsBehaviour.resetBtn();
        }
        if (buttonsBehaviour.GetcatchBtn())
        {
            guardado = inventarioManager.setInventario(libro, "libro");
            if (guardado)
            {
                DesactivarLibro();
                //isActive = false;
                //animator.SetBool("isUsed", false);
            }
            buttonsBehaviour.resetBtn();
        }
    }

    /*public void SetImage()
    {
        imagenLibro.sprite = libro;
    }*/
    // Start is called before the first frame update
    public void ActivarLibro()
    {
        this.gameObject.SetActive(true);
    }

    public void DesactivarLibro()
    {
        this.gameObject.SetActive(false);
    }
 // Update is called once per frame
    void Update()
    {
        
    }  
}
