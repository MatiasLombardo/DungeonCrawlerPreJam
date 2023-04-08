using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioBehaviour : MonoBehaviour
{

//necesito, que los objetos entren a 

    
    public static InventarioBehaviour Instance { get; private set; }

    private void Awake() 
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }




    [SerializeField] List<int> listaInventario = new List<int>();
    [SerializeField] List<Image> listaInventarioVisuales = new List<Image>();
    //[SerializeField] Transform[] slots;

    [SerializeField] Sprite pocion;
    [SerializeField] Sprite mapa1;
    [SerializeField] Sprite mapa2;
    [SerializeField] Sprite mapa3;
    [SerializeField] Sprite brujula;
    [SerializeField] Sprite llave;

    [SerializeField] GameObject brujulaO;
    [SerializeField] GameObject mapa1O;
    [SerializeField] GameObject mapa2O;
    [SerializeField] GameObject mapa3O;
    
        

    //0: brujula
    //1: mapa 1
    //2: mapa 2
    //3: mapa 3
    //4: Pocion
    //5: Llave

    public void QuitarPocion()
    {
        for (int i = 0; i < listaInventario.Count; i++)
        {
            if (listaInventario[i] == 4)
            {
                listaInventario.Remove(4);
                break;
            }
        }
    }


    public void añadirAlInventario(int objeto)
    {
        listaInventario.Add(objeto);
    }

    public List<int> Get_Inventario()
    {
        return new List<int>(listaInventario);
    }

    void OnEnable()
    {
        DefinidorDeObjetos();
    }

    /*public void EntrarInventario()
    {
        DefinidorDeObjetos();
        for (int i = 0; i < listaInventarioVisuales.Length; i++)
        {
            if (i < listaInventarioVisuales.Count)
            {
                listaInventarioVisuales[i].GetComponent<Image>() = 
            }
        }
    }*/

    void DefinidorDeObjetos()
    {
        for (int i = 0; i < listaInventario.Count; i++)
        {
            int nombre = listaInventario[i];
            Debug.Log(nombre);
            switch (nombre)
            {
                case 0 :
                    listaInventarioVisuales[i].GetComponent<Image>().sprite = brujula;
                    brujulaO.SetActive(true);
                break;

                case 1 :
                    listaInventarioVisuales[i].GetComponent<Image>().sprite = mapa1;
                    //se activa el mapa 1 GameObject
                    mapa1O.SetActive(true);
                break;
                
                case 2 :
                    listaInventarioVisuales[i].GetComponent<Image>().sprite = mapa2;
                    mapa2O.SetActive(true);
                break;

                case 3 :
                    listaInventarioVisuales[i].GetComponent<Image>().sprite = mapa3;
                    mapa3O.SetActive(true);
                break;

                case 4 :
                    listaInventarioVisuales[i].GetComponent<Image>().sprite = pocion;
                    //Ademas que setee si se puede tomar o no
                break;
                
                case 5 :
                    listaInventarioVisuales[i].GetComponent<Image>().sprite = llave;
                break;
                


                default:
                Debug.Log("Error discriminador de sprites");
                break;
            }
        }
    }
    




}
