using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorStartManager : MonoBehaviour
{
    public GameObject sManager;
    private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = sManager.GetComponent<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {
        StartCoroutine(HandleDoorUse());
    }

    private IEnumerator HandleDoorUse()
    {
        soundManager.SeleccionAudio(0, 0.5f);

        // Espera 1 segundo
        yield return new WaitForSeconds(2.5f);

        // Carga la nueva escena
        SceneManager.LoadScene("MainScene");
    }

}
