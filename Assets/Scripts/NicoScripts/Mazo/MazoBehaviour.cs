using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazoBehaviour : MonoBehaviour
{

    

    [SerializeField] List<Sprite> mazo = new List<Sprite>();

    [SerializeField] GameObject señalDeError;

    //[SerializeField] float tamañoMazo = 6f;
    [SerializeField] List<Sprite> cartasSeleccionables = new List<Sprite>();


    //implementar las cartas del mazo dentro de este script


    private void OnEnable() 
    {
        cartasSeleccionables = new List<Sprite>(MazoManager.Instance.Get_Cartas());
    }


    public void AñadirCarta(Sprite carta)
    {

        for (int i = 0; i < mazo.Count; i++)
        {
            if(mazo[i] == null)
            {
                mazo.RemoveAt(i);
                mazo.Add(carta);
                break;
            }
        }
        
    }
    public void EliminarCarta (Sprite carta)
    {
        for (int i = 0; i < mazo.Count; i++)
        {
            if (mazo[i] == carta)
            {
                mazo[i] = null;
                break;
            }
        }
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

}
