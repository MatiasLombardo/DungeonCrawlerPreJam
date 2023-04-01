using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TiendaBehaviour : MonoBehaviour
{

    // abre la tienda cuando lo vez
    //[SerializeField] GameObject tienda;
    [SerializeField] GameObject opciones;
    // son 3 opciones de cartas, crear una lista de todas las cartas, la lista total
    //[SerializeField] List<SpriteRenderer> cartas = new List<SpriteRenderer>();
    [SerializeField] GameObject botonTienda;
    [SerializeField] bool isTienda;
    [SerializeField] GameObject padre;
    [SerializeField] TMP_Text cantidadDineroTotal;
    int dineroTotal;

    //[SerializeField] int dineroTotal;

    private void OnTriggerStay(Collider other) 
    {
        botonTienda.SetActive(true);
    }

    public void ActivarTienda(bool valor)
    {
        dineroTotal = SistemaDeTurnos.Instance.Get_DineroTotal();
        cantidadDineroTotal.text = dineroTotal.ToString();
        opciones.SetActive(valor);
    }

    public void SeleccionarCarta(SpriteRenderer sprite, GameObject carta, int coste)
    {
        //dineroTotal = SistemaDeTurnos.Instance.Get_DineroTotal();
        Debug.Log("comprar");
        if (isTienda && dineroTotal >= coste)
        {
            
            SistemaDeTurnos.Instance.RestarDinero(coste);
            cantidadDineroTotal.text = dineroTotal.ToString();
            MazoManager.Instance.AñadirCartaAlInventario(sprite);
            //carta.SetActive(false);
        }
        else if (!isTienda)
        {

            opciones.SetActive(false);
            MazoManager.Instance.AñadirCartaAlInventario(sprite); 
            Destroy(padre);
        }
        
    }







}
