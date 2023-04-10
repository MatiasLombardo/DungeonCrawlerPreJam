using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MazoBehaviour : MonoBehaviour
{



    [SerializeField] List<Sprite> mazo = new List<Sprite>();

    [SerializeField] GameObject señalDeError;

    //[SerializeField] float tamañoMazo = 6f;
    [SerializeField] List<Sprite> cartasSeleccionables = new List<Sprite>();

    [SerializeField] GameObject[] cartasParaSeleccionar;

    [SerializeField] TMP_Text texto_CantidadCartasMazo;


    //implementar las cartas del mazo dentro de este script


    private void OnEnable() 
    {
        cartasSeleccionables = new List<Sprite>(MazoManager.Instance.Get_Cartas());

        for (int i = 0; i < cartasParaSeleccionar.Length; i++)
        {
            if (i < (cartasSeleccionables.Count))
            {
                cartasParaSeleccionar[i].GetComponent<Image>().sprite = cartasSeleccionables[i];
                cartasParaSeleccionar[i].SetActive(true);
            }
            else
            {
                cartasParaSeleccionar[i].SetActive(false);
            }
        }


    }




    public void AñadirCarta(GameObject carta)
    {

        Sprite cartaSprite = carta.GetComponent<Image>().sprite;

        for (int i = 0; i < mazo.Count; i++)
        {
            if(mazo[i] == null)
            {
                mazo.RemoveAt(i);
                mazo.Add(cartaSprite);
                break;
            }
        }
        texto_CantidadCartasMazo.text = ContarATexto();
        
    }
    public void EliminarCarta (GameObject carta)
    {

        Sprite cartaSprite = carta.GetComponent<Image>().sprite;

        for (int i = 0; i < mazo.Count; i++)
        {
            if (mazo[i] == cartaSprite)
            {
                mazo[i] = null;
                break;
            }
        }
        texto_CantidadCartasMazo.text = ContarATexto();
    }

    public void GuardarMazo ()
    {
        for (int i = 0; i < mazo.Count; i++)
        {
            if (mazo[i] == null)
            {
                señalDeError.SetActive(true);
                break;
            }
            else
            {
                MazoManager.Instance.GuardarMazo(mazo);        
            }
        }
        
    }


    private string ContarATexto()
    {
        int _count = 0;
        for (int i = 0; i < mazo.Count; i++)
        {
            if (mazo[i] == null) _count ++;
        }

        return (mazo.Count - _count).ToString();
    }



    public int TotalDeCartas()
    {
        int _count = 0;
        for (int i = 0; i < mazo.Count; i++)
        {
            if (mazo[i] == null) _count ++;
        }
        return (mazo.Count - _count);
    }
}
