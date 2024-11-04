using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioManager : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject sManager;

    private ButtonsBehaviour buttonsBehaviour;
    private DialogueManager dialogueManager;
    private SoundManager soundManager;

    public string[] dialogueError = { "¡El inventario esta lleno!" };

    //VARIABLES PARA AÑADIR EN EL INVENTARIO
    //public Dictionary<int, SlotInfo> slots;
    public Image[] slotImages;
    private Dictionary<int, SlotInfo> slots = new Dictionary<int, SlotInfo>
    {
        { 0, null },
        { 1, null },
        { 2, null }
    };

    public string heldItem;
    public int indexObj;

    // Start is called before the first frame update
    void Start()
    {
        buttonsBehaviour = gameManager.GetComponent<ButtonsBehaviour>();
        dialogueManager = gameManager.GetComponent<DialogueManager>();
        //slots = new Dictionary<int, SlotInfo>();
        soundManager = sManager.GetComponent<SoundManager>();

        for (int i2 = 0; i2 < slots.Count; i2++)
        {
            if (slots[i2] != null)
            {
                Debug.Log("lista Slots " + slots[i2].Desc);

            }
            else
            {
                Debug.Log("Lista slots " + i2 + " vacío");
            }


        }

    }

    // Update is called once per frame
    void Update()
    {
    }


    public class SlotInfo
    {
        public Sprite Imagen { get; set; }
        public string Desc { get; set; }

        public SlotInfo(Sprite imagen, string desc)
        {
            Imagen = imagen;
            Desc = desc;
        }
    }
    public bool setInventario(Sprite imag, string txt)
    {

        int i = 0;
        while (i < slots.Count && slots[i] != null)
        {
            i++;
        }
        Debug.Log("index " + i);

        if (i < slotImages.Length)
        {
            slots[i] = new SlotInfo(imag, txt);

            // Actualiza la imagen en el primer slot disponible en la UI
            slotImages[i].sprite = imag;
            slotImages[i].enabled = true;  // Asegúrate de que el Image esté activo
            soundManager.SeleccionAudio(3, 0.7f);

            for (int i3 = 0; i3 < slotImages.Length; i3++)
            {
                if (slotImages[i3].sprite != null)
                {
                    Debug.Log("Slot " + i3 + " contains source image: " + slotImages[i3].sprite.name);
                }
                else
                {
                    Debug.Log("Slot " + i3 + " is empty or has no assigned source image.");
                }
            }
            for (int i2 = 0; i2 < slots.Count; i2++)
            {
                if (slots[i2] != null)
                {
                    Debug.Log("lista Slots " + slots[i2].Desc);

                }
                else
                {
                    Debug.Log("Lista slots " + i2 + " vacío");
                }
            }
            return true;
        }
        else
        {
            Debug.LogWarning("El índice es mayor al número de imágenes en slotImages. Asegúrate de que slotImages tiene suficientes elementos.");
            return false;
        }
    }

    //Comprobar
    public string GetInventoryItemByIndex(int index)
    {
        if (slots.ContainsKey(index))
        {
            return slots[index].Desc;
        }
        else
        {
            return "";
        }
    }

    //Guardar desc item clicked
    public void SetHeldItem(int index)
    {
        buttonsBehaviour.resetBtn();

        indexObj = index;
        heldItem = GetInventoryItemByIndex(index);
    }

    public int GetIndexItem()
    {
        return indexObj;
    }
    public string GetHeldItem()
    {
        return heldItem;
    }

    public void RemoveItem(int index)
    {
        if (index < slotImages.Length)
        {
            Debug.Log("index remove " + index);
            slotImages[index].GetComponent<Image>().sprite = null;

            slots[index] = null; ;
            for (int i3 = 0; i3 < slotImages.Length; i3++)
            {
                if (slotImages[i3].sprite != null)
                {
                    Debug.Log("Slot " + i3 + " contains source image: " + slotImages[i3].sprite.name);
                }
                else
                {
                    Debug.Log("Slot " + i3 + " is empty or has no assigned source image.");
                }

            }
            for (int i2 = 0; i2 < slots.Count; i2++)
            {
                if (slots[i2] != null)
                {
                    Debug.Log("lista Slots " + slots[i2].Desc);

                }
                else
                {
                    Debug.Log("Lista slots " + i2 + " vacío");
                }


            }

            //ReorganizeSlots();
        }
    }

    /*private void ReorganizeSlots()
    {
        Dictionary<int, SlotInfo> newSlots = new Dictionary<int, SlotInfo>();
        int newIndex = 0;

        // Reorganiza los slots eliminando los huecos
        foreach (var slot in slots)
        {
            newSlots[newIndex] = slot.Value; // Mantiene la SlotInfo
            newIndex++;
        }

        slots = newSlots; // Reemplaza los slots originales con los reorganizados
    }*/

}
