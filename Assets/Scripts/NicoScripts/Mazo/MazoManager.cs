 using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 using System.Linq;


 
 public class MazoManager : MonoBehaviour
 {

    public static MazoManager Instance { get; private set; }

    public List<Sprite> mazoGuardado = new List<Sprite>();
    //private List<Sprite> mazoExportado = new List<Sprite>();
    public List<Sprite> cartasParaInventario = new List<Sprite>();


    private void Awake() 
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }


        DontDestroyOnLoad(this.gameObject);
        //Añado las cartas por defecto
        //cartasParaInventario.Push();


    }

    public void GuardarMazo(List<Sprite> imazo)
    {

        mazoGuardado = new List<Sprite>(imazo);
        //mazoGuardado = Barajar();
    }

    public List<Sprite> Get_Mazo()
    {
        List<Sprite> mazoBarajado = new List<Sprite>(mazoGuardado);
        return new List<Sprite>(mazoBarajado);
    }

    private List<Sprite> Barajar()
    {  
        for (int i = 0; i < mazoGuardado.Count; i++)
        {
            int indexToSwap = Random.Range(i, mazoGuardado.Count);
            var oldValue = mazoGuardado[i];
            mazoGuardado[i] = mazoGuardado[indexToSwap];
            mazoGuardado[indexToSwap] = oldValue;
        }
        return mazoGuardado;
    }


    //Control de cartas, para las listas
    [SerializeField] int numeroDeCarta = 0;
    [SerializeField] Sprite spriteActual;

     public void ContadorDeCartas()
     {
        if(numeroDeCarta == 0)
        {
            mazoGuardado = Barajar();
        }
        else if (numeroDeCarta >= mazoGuardado.Count)
        {
            numeroDeCarta = 0;
            mazoGuardado = Barajar();
        }
        spriteActual = mazoGuardado[numeroDeCarta];
        numeroDeCarta++;
     }

     public Sprite Get_SpriteActual()
     {
        return spriteActual;
     }

    //Recordatorio: me quede en la parte de los mazos y el generador de cartas (tambien falta el daño y demas)


    public List<Sprite> Get_Cartas()
    {
        return cartasParaInventario;
    }

    public void AñadirCartaAlInventario(SpriteRenderer spriteRenderer)
    {
        Sprite sp = spriteRenderer.sprite;
        cartasParaInventario.Add(sp);

    }



    //añadir carta: (int daño, sprite, bloqueo, cantidad)

}