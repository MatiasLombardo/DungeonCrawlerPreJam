using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaBehaviour : MonoBehaviour
{

    // abre la tienda cuando lo vez
    //[SerializeField] GameObject tienda;
    [SerializeField] GameObject opciones;
    // son 3 opciones de cartas, crear una lista de todas las cartas, la lista total
    //[SerializeField] List<SpriteRenderer> cartas = new List<SpriteRenderer>();
    [SerializeField] GameObject botonTienda;

    //[SerializeField] int dineroTotal;

    private void OnTriggerStay(Collider other) 
    {
        botonTienda.SetActive(true);
    }

    public void ActivarTienda(bool valor)
    {
        opciones.SetActive(valor);
    }

    public void SeleccionarCarta(SpriteRenderer sprite)
    {
        opciones.SetActive(false);
        //guerda la carta en MazoManager
        MazoManager.Instance.AñadirCartaAlInventario(sprite);
    }






}
