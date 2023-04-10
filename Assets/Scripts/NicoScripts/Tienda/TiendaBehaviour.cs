using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    [SerializeField] GameObject carta1;
    [SerializeField] GameObject carta2;
    [SerializeField] GameObject carta3;

    [SerializeField] Sprite spriteCarta1;
    [SerializeField] Sprite spriteCarta2;
    [SerializeField] Sprite spriteCarta3;

    [SerializeField] Sprite spriteObjeto;


    
    //[SerializeField] int dineroTotal;
    private void Awake() 
    {
        codigoPlayer = GameObject.Find("/PlayerPostMerge").GetComponent<PlayerInput>();
        if (isTienda)
        {
            
            carta1.GetComponent<Image>().sprite = spriteCarta1;
            carta2.GetComponent<Image>().sprite = spriteCarta2;
            carta3.GetComponent<Image>().sprite = spriteCarta3;
        }
        else
        {
            carta1.GetComponent<Image>().sprite = spriteCarta1;
        }
        if (isCofreObjeto)
        {
            carta1.GetComponent<Image>().sprite = spriteObjeto;
        }
    }


    bool isPrimero;
    bool terminoSuUso;

    private void OnTriggerEnter(Collider other) 
    {
        
        temp2 = 0;
        isPrimero = true;
    }

    private void OnTriggerStay(Collider other) 
    {        

        if (isPrimero)
        {
            newPos = Vector3.Distance(other.transform.position, transform.position);
            if (temp2 <= 5)
            {
                oldPos = Vector3.Distance(other.transform.position, transform.position);
            }
            if (newPos == oldPos)
            {
                botonTienda.SetActive(true);
                isPrimero = false;
            }
            temp2++;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (!terminoSuUso)
        {
            botonTienda.SetActive(false);
        }
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

    public void SeleccionarCarta(Image sprite, GameObject carta, int coste)
    {
        //dineroTotal = SistemaDeTurnos.Instance.Get_DineroTotal();
        Debug.Log("comprar");
        if (isTienda && dineroTotal >= coste && !isCofreObjeto)
        {
            temp++;
            SistemaDeTurnos.Instance.RestarDinero(coste);
            cantidadDineroTotal.text = dineroTotal.ToString();
            MazoManager.Instance.AñadirCartaAlInventario(sprite);
            carta.SetActive(false);
            if (temp >= 3)
            {
                SalirTienda();
                terminoSuUso = true;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                Destroy(padre);
            }
        }
        else if (!isTienda && !isCofreObjeto)
        {

            opciones.SetActive(false);
            MazoManager.Instance.AñadirCartaAlInventario(sprite);
            SalirTienda();
            terminoSuUso = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(padre);
        }
        else if(isCofreObjeto)
        {
            opciones.SetActive(false);
            InventarioBehaviour.Instance.añadirAlInventario(objeto);
            SalirTienda();
            terminoSuUso = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
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
        terminoSuUso = true;
        Destroy(padre);
    }



    

}
