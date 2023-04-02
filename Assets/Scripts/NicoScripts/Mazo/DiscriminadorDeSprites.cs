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

    private void OnEnable() 
    {
        
        string nombre = gameObject.GetComponent<SpriteRenderer>().sprite.name;
        Debug.Log(nombre);
        switch (nombre)
        {
            case var value when value == sprites[0].name :
                cantidadTotal = 12;
                cantidadActual = cantidadTotal;
                Debug.Log(cantidadTotal);
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;

            case var value when value == sprites[1].name :
                cantidadTotal = 4;
                cantidadActual = cantidadTotal;
                Debug.Log(cantidadTotal);
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;

            case var value when value == sprites[2].name :
                cantidadTotal = 5;
                cantidadActual = cantidadTotal;
                Debug.Log(cantidadTotal);
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;

            case var value when value == sprites[3].name :
                cantidadTotal = 8;
                cantidadActual = cantidadTotal;
                Debug.Log(cantidadTotal);
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[4].name :
                cantidadTotal = 3;
                cantidadActual = cantidadTotal;
                Debug.Log(cantidadTotal);
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[5].name :
                cantidadTotal = 5;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[6].name :
                cantidadTotal = 10;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[7].name :
                cantidadTotal = 3;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[8].name :
                cantidadTotal = 4;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[9].name :
                cantidadTotal = 3;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[10].name :
                cantidadTotal = 3;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[11].name :
                cantidadTotal = 2;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[12].name :
                cantidadTotal = 2;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[13].name :
                cantidadTotal = 1;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[14].name :
                cantidadTotal = 1;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[15].name :
                cantidadTotal = 1;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[16].name :
                cantidadTotal = 1;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[17].name :
                cantidadTotal = 1;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;
            case var value when value == sprites[18].name :
                cantidadTotal = 1;
                cantidadActual = cantidadTotal;
                texto_CantidadCartas.text = cantidadActual.ToString();
            break;



            default:
            Debug.Log("Error discriminador de sprites");
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
