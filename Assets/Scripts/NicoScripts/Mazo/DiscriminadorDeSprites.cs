using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiscriminadorDeSprites : MonoBehaviour
{

    [SerializeField] Sprite[] sprites;
    [SerializeField] TMP_Text texto_CantidadCartas;
    [SerializeField] MazoBehaviour mazoBehaviour;
    [SerializeField] GameObject botonAñadir;
    [SerializeField] GameObject botonQuitar;
 
    int cantidadTotal;
    int cantidadActual;

    private void Awake() 
    {
        string nombre = gameObject.GetComponent<SpriteRenderer>().sprite.name;
        switch (nombre)
        {
            case var value when value == sprites[0].name :
                cantidadTotal = 12;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;

            case var value when value == sprites[1].name :
                cantidadTotal = 6;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;

            case var value when value == sprites[2].name :
                cantidadTotal = 7;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;

            case var value when value == sprites[3].name :
                cantidadTotal = 4;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[4].name :
                cantidadTotal = 1;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[5].name :
                cantidadTotal = 3;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[6].name :
                cantidadTotal = 4;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[7].name :
                cantidadTotal = 2;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[8].name :
                cantidadTotal = 6;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[9].name :
                cantidadTotal = 4;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;



            default:
            Debug.LogError("Error discriminador de sprites");
            break;
        }

    }

    private void Update() 
    {
        if (cantidadActual == 0 || mazoBehaviour.TotalDeCartas() == 12)
        {
            botonAñadir.SetActive(false);
        }
        else
        {
            botonAñadir.SetActive(true);
        }
        if (cantidadActual == cantidadTotal)
        {
            botonQuitar.SetActive(false);
        }
        else
        {
            botonQuitar.SetActive(true);
        }
    }
    

    public void BajarNumero()
    {
        if (cantidadActual <= cantidadTotal && cantidadActual > 0 && mazoBehaviour.TotalDeCartas() < 12)
        {
            cantidadActual --;
            texto_CantidadCartas.text = cantidadActual.ToString();
            mazoBehaviour.AñadirCarta(this.gameObject);
        }
    }

    public void SubirNumero()
    {
        if (cantidadActual < cantidadTotal)
        {
            cantidadActual ++;
            texto_CantidadCartas.text = cantidadActual.ToString();
            mazoBehaviour.EliminarCarta(this.gameObject);
        }
    }

    /*public void DesactivarBoton()
    {
        if (cantidadActual == 0 || mazoBehaviour.TotalDeCartas() == 12)
        {
            botonAñadir.SetActive(false);
        }
        else
        {
            botonAñadir.SetActive(true);
        }
        if (cantidadActual == cantidadTotal)
        {
            botonQuitar.SetActive(false);
        }
        else
        {
            botonQuitar.SetActive(true);
        }
    }*/

}
