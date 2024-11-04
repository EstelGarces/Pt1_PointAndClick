using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CatProperties : MonoBehaviour, IPointerClickHandler
{
    public bool isActive = false;
    public GameObject gameManager;
    public GameObject sManager;

    private float timeActive = 0f;

    private ButtonsBehaviour buttonsBehaviour;
    private DialogueManager dialogueManager;
    private Animator animator;
    private SoundManager soundManager;

    public string[] dialogueCat = { "No molestes al gato, está durmiendo" };
    public string[] dialogueGuardar = { "¡No te puede llevar al gato!" };

    // Start is called before the first frame update
    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        animator = this.GetComponent<Animator>();
        soundManager = sManager.GetComponent<SoundManager>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isActive && buttonsBehaviour.GetuseBtn())
        {
            isActive = true;
            animator.SetBool("isTouched", true);
            soundManager.SeleccionAudio(0, 0.5f);
            buttonsBehaviour.resetBtn();
        }
        if (buttonsBehaviour.GetlookBtn())
        {
            dialogueManager.setDialogues(dialogueCat);
            dialogueManager.StartDialogue();
            soundManager.SeleccionAudio(1, 0.7f);
            buttonsBehaviour.resetBtn();
        }
        if (buttonsBehaviour.GetcatchBtn())
        {
            dialogueManager.setDialogues(dialogueGuardar);
            dialogueManager.StartDialogue();
            soundManager.SeleccionAudio(2, 0.5f);

            buttonsBehaviour.resetBtn();
        }
    }

    private void RestarAnimation()
    {
        if (isActive)
        {
            timeActive = timeActive + Time.deltaTime;

            if (timeActive > 2.0)
            {
                Debug.Log("isActive " + isActive);
                isActive = false;
                animator.SetBool("isTouched", false);
                timeActive = 0f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        RestarAnimation();
    }
}
