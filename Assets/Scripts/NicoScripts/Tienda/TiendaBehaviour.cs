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
    [SerializeField] bool isCofreObjeto;
    [SerializeField] GameObject padre;
    [SerializeField] TMP_Text cantidadDineroTotal;
    int dineroTotal;
    int temp = 0;
    int temp2 = 0;
    [SerializeField] PlayerInput codigoPlayer;
    [SerializeField] Transform target;
    float newPos, oldPos;
    [SerializeField] AudioClip au_CofreOpen;
    [SerializeField] AudioClip au_TiendaOPEN;
    [SerializeField] AudioClip au_TiendaCLOSE;
    [SerializeField] AudioClip musicaTienda;
    [SerializeField] int objeto;
    
    //[SerializeField] int dineroTotal;

    private void OnTriggerEnter(Collider other) 
    {
        
        temp2 = 0;
    }

    private void OnTriggerStay(Collider other) 
    {        

        newPos = Vector3.Distance(other.transform.position, transform.position);
        if (temp2 <= 5)
        {
            oldPos = Vector3.Distance(other.transform.position, transform.position);
        }
        if (newPos == oldPos)
        {
            botonTienda.SetActive(true);
        }
        temp2++;
    }

    private void OnTriggerExit(Collider other) 
    {
        botonTienda.SetActive(false);
    }

    public void ActivarTienda(bool valor)
    {
        if (isTienda)
        {
            AudioManager.Instance.Play(au_TiendaOPEN);
            codigoPlayer.GirarCamaraA(target);
            dineroTotal = SistemaDeTurnos.Instance.Get_DineroTotal();
            cantidadDineroTotal.text = dineroTotal.ToString();
            opciones.SetActive(valor);
        }
        else
        {
            AudioManager.Instance.Play(au_CofreOpen);
            codigoPlayer.GirarCamaraA(target);
            dineroTotal = SistemaDeTurnos.Instance.Get_DineroTotal();
            cantidadDineroTotal.text = dineroTotal.ToString();
            opciones.SetActive(valor);
        }
    }

    public void SeleccionarCarta(SpriteRenderer sprite, GameObject carta, int coste)
    {
        //dineroTotal = SistemaDeTurnos.Instance.Get_DineroTotal();
        Debug.Log("comprar");
        if (isTienda && dineroTotal >= coste)
        {
            temp++;
            SistemaDeTurnos.Instance.RestarDinero(coste);
            cantidadDineroTotal.text = dineroTotal.ToString();
            MazoManager.Instance.AñadirCartaAlInventario(sprite);
            carta.SetActive(false);
            if (temp >= 3)
            {
                SalirTienda();
                Destroy(padre);
            }
        }
        else if (!isTienda && !isCofreObjeto)
        {

            opciones.SetActive(false);
            MazoManager.Instance.AñadirCartaAlInventario(sprite);
            SalirTienda();
            Destroy(padre);
        }
        else if(isCofreObjeto)
        {
            opciones.SetActive(false);
            InventarioBehaviour.Instance.añadirAlInventario(objeto);
            SalirTienda();
            Destroy(padre);
        }
        dineroTotal = SistemaDeTurnos.Instance.Get_DineroTotal();
        cantidadDineroTotal.text = dineroTotal.ToString();
        
    }

    public void SalirTienda()
    {
        AudioManager.Instance.Play(au_TiendaCLOSE);
        codigoPlayer.sePuedeMover = true;
        codigoPlayer.camaraPlayer.transform.rotation = new Quaternion (0,0,0,0);
    }

    public void borrar()
    {
        Destroy(padre);
    }

}
