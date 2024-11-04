using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonsBehaviour : MonoBehaviour
{
    private bool use1Btn, look1Btn, catch1Btn = false;
    public TextMeshProUGUI btn_mirar;
    public TextMeshProUGUI btn_usar;
    public TextMeshProUGUI btn_coger;


    public bool GetuseBtn()
    {
        return use1Btn;
    }
    public bool GetlookBtn()
    {
        return look1Btn;
    }

    public bool GetcatchBtn()
    {
        return catch1Btn;
    }

    public void lookBtn()
    {
        if (!look1Btn)
        {
            use1Btn = false;
            catch1Btn = false;
            look1Btn = true;
            formatPressBtn(btn_mirar, btn_coger, btn_usar);


            Debug.Log("Has pulsado el boton mirar!!");
        }
        else
        {
            resetBtn();
            Debug.Log("El boton mirar se ha se ha apagado");

        }

    }

    public void useBtn()
    {
        if (!use1Btn)
        {
            look1Btn = false;
            catch1Btn = false;
            use1Btn = true;
            formatPressBtn(btn_usar, btn_coger, btn_mirar);

            Debug.Log("Has pulsado el boton usar!!");
        }
        else
        {
            resetBtn();
            Debug.Log("El boton usar se ha se ha apagado");
        }
    }

    public void catchBtn()
    {
        if (!catch1Btn)
        {
            look1Btn = false;
            use1Btn = false;
            catch1Btn = true;
            formatPressBtn(btn_coger, btn_mirar, btn_usar);


            Debug.Log("Has pulsado el boton coger!!");
        }
        else
        {
            resetBtn();
            Debug.Log("El boton coger se ha se ha apagado");

        }
    }
    public void formatPressBtn(TextMeshProUGUI btn_txt_on, TextMeshProUGUI btn_txt_off1, TextMeshProUGUI btn_txt_off2)
    {
        btn_txt_off1.color = new Color32(56, 56, 56, 255);
        btn_txt_off1.fontStyle = FontStyles.Normal;

        btn_txt_off2.color = new Color32(56, 56, 56, 255);
        btn_txt_off2.fontStyle = FontStyles.Normal;

        btn_txt_on.color = Color.white;
        btn_txt_on.fontStyle = FontStyles.Bold | FontStyles.Underline;
    }

    public void resetBtn()
    {
        look1Btn = false;
        catch1Btn = false;
        use1Btn = false;

        btn_coger.fontStyle = FontStyles.Normal;
        btn_coger.color = Color.white;
        btn_usar.fontStyle = FontStyles.Normal;
        btn_usar.color = Color.white;
        btn_mirar.fontStyle = FontStyles.Normal;
        btn_mirar.color = Color.white;

    }
}

