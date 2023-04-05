using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
 
 public class SistemaDeTurnos : MonoBehaviour
 {
    
    //ESTO SE PUEDE LLAMAR TAMBIEN COMBATE MANAGER, porque la clase escaló mas de lo que pensé y ahora abarca y modifica todo el combate


    public static SistemaDeTurnos Instance { get; private set; }

    public bool turnoPlayer = true;
    public bool puedeAgarrarCarta = true;
    private int dañoAlEnemigo;
    [SerializeField] GameObject handUtils;
    [SerializeField] GameObject sistemaDeCombate;
    [SerializeField] GameObject[] desactivarCosasAlIniciarCombate;

    [SerializeField] TMP_Text[] comparadores;
    [SerializeField] SistemaDeVida sisVida;
    [SerializeField] Sprite pocionSpr;

    [SerializeField] GameObject contenedorDeMedidores;
    [SerializeField] TMP_Text medidorXP, medidorDinero;

    [SerializeField] Animator animacionFade;


    
    public enum BOSS
    {
    LOBO, BAILARINA, BFINAL, NONE
    }

    public BOSS estadoB;

    public bool bailarinaON;

    [SerializeField] int dineroTotal;

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


     public void IniciarCombate(int enemigoTipo, float vidaTotal, AudioClip musica, Sprite spriteNuevo)
     {
        
        
        StartCoroutine(TransicionIniciarCombate(enemigoTipo, vidaTotal, musica, spriteNuevo));



     }


    IEnumerator TransicionIniciarCombate(int enemigoTipo, float vidaTotal, AudioClip musica, Sprite spriteNuevo)
    {
        //El jugador mira al enemigo
        //Este le dice un par de cosas
        MazoEnemigoManager.Instance.Set_TipoEnemigo(enemigoTipo, spriteNuevo);
        //Setea el tipo de enemigo
        MazoEnemigoManager.Instance.MazosEnemigos();
        //Setea el mazo
        SistemaDeVida.Instance.Set_VidaMaxEnemigo(vidaTotal);
        //seteo su vida
        //desactiva los objetos y activa el combate
        foreach (GameObject a in desactivarCosasAlIniciarCombate)
        {
            a.SetActive(false);
        }
        yield return new WaitForSeconds(1f);
        //*playerController.SetActive(false);
        AudioManager.Instance.PlayMusic(musica);
        sistemaDeCombate.SetActive(true);
        yield return null;
    }



     public void TerminarCombate()
     {
        StartCoroutine(TransicionTerminarCombate());
     }


    IEnumerator TransicionTerminarCombate()
    {
        //Se pone todo negro menos el sprite enemigo y las vidas.
        //animacion cuando se rompe un sprite enemigo (cuando muere, como undertale).
        float val = nivelXP * 5 + 10;
        float xp = Random.Range(val-val/2, val);
        //Sube de nivel
        int dineroNuevo = Mathf.FloorToInt(Random.Range(val-val/2, val));
        medidorXP.text = xp.ToString();
        medidorDinero.text = dineroNuevo.ToString();
        contenedorDeMedidores.SetActive(true);
        yield return new WaitForSeconds(2f);
        AñadirDinero(dineroNuevo);
        //gana dinero
        foreach (GameObject a in desactivarCosasAlIniciarCombate)
        {
            a.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        contenedorDeMedidores.SetActive(false);
        sistemaDeCombate.SetActive(false);
        yield return new WaitForSeconds(1f);
        //se desactiva el negro en forma de fade rapido.
        yield return null;
    }


 #region LogicaTurnosYDaños

     public bool Get_AgarrarCarta ()
     {
        return puedeAgarrarCarta;
     }

     public void Set_AgarrarCartaFalse()
     {
        puedeAgarrarCarta = false;
     }

     public bool Get_TurnoPlayer ()
     {

        return turnoPlayer;
     }


    // sistema de combate puro
    // se tira la carta, es carta de combate?
    // si es asi, cuanto quita
    // le quita daño al enemigo


    public int[] choqueDeDaños =  new int[2];
    int temp = 0;

    public void DañoAlEnemigo(GameObject card)
    {
        if (temp == 0)
        {
            //tira la carta, es daño al enemigo (dependiendo de quien sea el que tire, se que esta mal explicado pero asi escaló la funcion)
            //Debug.Log("se tiró la carta:" + card.name);
            dañoAlEnemigo = card.GetComponent<Tools.UI.Card.UiCardComponent>().Get_Daño();
            int bloqueoMio = card.GetComponent<Tools.UI.Card.UiCardComponent>().Get_Absorber();

            string pocion = card.GetComponent<SpriteRenderer>().sprite.name;
            if (pocion == pocionSpr.name)
            {
                sisVida.CurarTodaLaVida();
            }

            
            
            if (estadoB == BOSS.NONE || estadoB == BOSS.BAILARINA || estadoB == BOSS.BFINAL)
            {
                choqueDeDaños[0] = dañoAlEnemigo;
                choqueDeDaños[1] = bloqueoMio;
            }
            else if (estadoB == BOSS.LOBO)
            {
                choqueDeDaños[1] = dañoAlEnemigo;
                choqueDeDaños[0] = bloqueoMio;
            }

            //0 y 1 es un par JUGADOR
            //2 y 3 otro par ENEMIGO
    
            //Debug.Log("El daño que hace es: " + dañoAlEnemigo);
    
            //hay que añadir el daño a un texto y que se vea, ademas un texto en la propia carta
            //cambiar todos los gameObjects porque luego desaparecen y crean errores
            temp++;
        }
        else if (temp == 1)
        {
            temp = 0;
            dañoAlEnemigo = card.GetComponent<Tools.UI.Card.UiCardComponent>().Get_Daño();
            int bloqueoMio = card.GetComponent<Tools.UI.Card.UiCardComponent>().Get_Absorber();

            

            if (estadoB == BOSS.BFINAL && dañoAlEnemigo == 99)
            {
                dañoAlEnemigo = 2;
                choqueDeDaños[2] = dañoAlEnemigo + choqueDeDaños[1];
                choqueDeDaños[3] = bloqueoMio;
            }
            else if (estadoB == BOSS.BFINAL && bloqueoMio == 99)
            {
                choqueDeDaños[2] = dañoAlEnemigo;
                choqueDeDaños[3] = choqueDeDaños[0];
            }
            else
            {
                choqueDeDaños[2] = dañoAlEnemigo;
                choqueDeDaños[3] = bloqueoMio;
                Debug.Log("El daño que hace es: " + dañoAlEnemigo); 
            }

            

        }
    }
    public int Get_DañoCarta()
    {
        return dañoAlEnemigo;
    }



    private void ProcesarDaño ()
    {
        /*if (valorTurno == 0)
        {
            SistemaDeVida.Instance.HacerDañoEnemigo(choqueDeDaños[0] - choqueDeDaños[3]);  
            SistemaDeVida.Instance.HacerDañoPlayer(choqueDeDaños[2] - choqueDeDaños[1]);  

            if (choqueDeDaños[0] > choqueDeDaños[1])
            {
                // daño jugador vs daño enemigo
                int dañoTotal = choqueDeDaños[0] - choqueDeDaños[1];
                Debug.Log("ganó el player, hizo: " + dañoTotal + " de daño");
                SistemaDeVida.Instance.HacerDañoEnemigo(dañoTotal);
                
            }
            else if(choqueDeDaños[0] < choqueDeDaños[1])
            {
                int dañoTotal = choqueDeDaños[1] - choqueDeDaños[0];
                Debug.Log("ganó el Enemigo, hizo: " + dañoTotal + " de daño");
                SistemaDeVida.Instance.HacerDañoPlayer(dañoTotal);
                
            }
            else if(choqueDeDaños[0] == choqueDeDaños[1])
            {
                Debug.Log("Hicieron el mismo daño, se repelieron");    
            }
        }
        else if (valorTurno == 1)
        {

            SistemaDeVida.Instance.HacerDañoPlayer(choqueDeDaños[0] - choqueDeDaños[3]);  
            SistemaDeVida.Instance.HacerDañoEnemigo(choqueDeDaños[2] - choqueDeDaños[1]);  




            if (choqueDeDaños[0] > choqueDeDaños[1])
            {
    
                int dañoTotal = choqueDeDaños[0] - choqueDeDaños[1];
                Debug.Log("ganó el Enemigo, hizo: " + dañoTotal + " de daño");
                SistemaDeVida.Instance.HacerDañoPlayer(dañoTotal);
                
            }
            else if(choqueDeDaños[0] < choqueDeDaños[1])
            {
                int dañoTotal = choqueDeDaños[1] - choqueDeDaños[0];
                Debug.Log("ganó el Player, hizo: " + dañoTotal + " de daño");
                SistemaDeVida.Instance.HacerDañoEnemigo(dañoTotal);
            }
            else if(choqueDeDaños[0] == choqueDeDaños[1])
            {
                Debug.Log("Hicieron el mismo daño, se repelieron");    
            }
        }*/
        StartCoroutine(EfectoComparadores());
    }

    IEnumerator EfectoComparadores()
    {
        
        
        if (valorTurno == 0)
        {

            for (int i = 0; i < choqueDeDaños.Length; i++)
            {
                comparadores[i].text = choqueDeDaños[i].ToString();
                //comparadores[i].IsEnable(true);
            }

            yield return new WaitForSeconds(2f);

            SistemaDeVida.Instance.HacerDañoEnemigo(choqueDeDaños[0] - choqueDeDaños[3]);  
            SistemaDeVida.Instance.HacerDañoPlayer(choqueDeDaños[2] - choqueDeDaños[1]);  
        }
        else if (valorTurno == 1)
        {
            int temp4 = 0;
            for (int i = choqueDeDaños.Length - 1; i >= 0 ; i--)
            {
                //0 ataque enemigo      //0 ataque jugador
                //1 defensa enemigo     //1 defensa jugador
                //2 ataque jugador      //2 ataque enemigo
                //3 defensa jugador     //3 defensa enemigo
                //0 => 2
                //1 => 3
                //2 => 0
                //3 => 1

                comparadores[i].text = choqueDeDaños[Mathf.Abs(i-2)].ToString();
                comparadores[1].text = choqueDeDaños[3].ToString();
                temp4++;
            }

            yield return new WaitForSeconds(2f);

            SistemaDeVida.Instance.HacerDañoPlayer(choqueDeDaños[0] - choqueDeDaños[3]);  
            SistemaDeVida.Instance.HacerDañoEnemigo(choqueDeDaños[2] - choqueDeDaños[1]); 
        } 

        for (int i = 0; i < choqueDeDaños.Length; i++)
        {
            comparadores[i].text = " ";
            //comparadores[i].IsEnable(true);
        }
        
    }


    int valorTurno = 0;
    bool estadoIA;

    public void TerminarTurnoEnemigo()
    {
        if (valorTurno == 0)
        {
            StartCoroutine(AnalizarTurnoE());
        }
        else if (valorTurno == 1)
        {
            Set_IAEnemigo(false);
            turnoPlayer = true;
            puedeAgarrarCarta = true;
        }
    }
    public void TerminarTurnoPlayer()
    {
        if (valorTurno == 0)
        {
            turnoPlayer = false;
            Set_IAEnemigo(true);
        }
        else if (valorTurno == 1)
        {
            StartCoroutine(AnalizarTurnoP());
            //turnoPlayer = false;
            valorTurno = 0;
            //Set_IAEnemigo(true);
        }
    }
    //valorTurno = 0 arranca el jugador, termina el enemigo
    //valorTurno = 1 arranca el enemigo, termina el jugador

    private IEnumerator AnalizarTurnoE()
    {

            ProcesarDaño();
            yield return new WaitForSeconds(1f);
            Set_IAEnemigo(false);
            valorTurno = 1;
            yield return new WaitForSeconds(0.5f);
            Set_IAEnemigo(true);
            yield return null;
    }

    private IEnumerator AnalizarTurnoP()
    {
            ProcesarDaño();
            yield return new WaitForSeconds(2f);
            turnoPlayer = false;
            yield return new WaitForSeconds(2f);
            turnoPlayer = true;
            puedeAgarrarCarta = true;
            handUtils.GetComponent<Tools.UI.Card.UiPlayerHand>().EnableCards(); 

            yield return null;
    }


    public void Set_IAEnemigo(bool estado)
    {
        estadoIA = estado;
    }

    public bool Get_IAEnemigo()
    {
        return estadoIA;
    }

    public int Get_ValorTurno()
    {
        return valorTurno;
    }

    //hacer el sistema de ABBA, turno player enemigo, enemigo player, player enemigo...
 #endregion

 #region DineroManager
    public void AñadirDinero(int dineroNuevo)
    {
        dineroTotal =+ dineroNuevo;
    }
    public int Get_DineroTotal()
    {
        return dineroTotal;
    }
    public void RestarDinero(int dineroNuevo)
    {
        dineroTotal = dineroTotal - dineroNuevo;
    }
 #endregion

 #region SetearEstados

    public void Set_EstadoBALOBO ()
    {
        estadoB = BOSS.LOBO;
        //LOBO te baja la vida a la mitad
        sisVida.Set_vidaMaxPLOBO();
    }

    public void Set_EstadoBABAILARINA()
    {
        //agarra cartas random y las da vuelta
        //da vuelta el sistema de vida
        bailarinaON = true;
        sisVida.isBailarina = true;
    }

    public void Set_EstadoBANONE()
    {
        bailarinaON = false;
        estadoB = BOSS.NONE;

        sisVida.Set_vidaNormal();
    }

    public void Set_EstadoBABFINAL()
    {
        estadoB = BOSS.BFINAL;
    }

    public BOSS Get_EstadoBBOSS()
    {
        return estadoB;
    }

 #endregion


 #region NivelManager

    [SerializeField] float nivelXP = 0;
    [SerializeField] float puntosGuardados = 0;

    public float Get_NivelXP()
    {
        return nivelXP;
    }

    public void Set_NivelXP(float nuevoNivel)
    {
        nivelXP = nuevoNivel;
    }

    public void SubirNivel ()
    {
        nivelXP =+ 1f;
        SistemaDeVida.Instance.SubirNivel();
        SistemaDeVida.Instance.CurarTodaLaVida();
        
    }

    public void SumarPuntosXP (float puntos)
    {
        //nivel 0 toma 10 puntos subir de nivel
        //nivel 1 toma 15 puntos subir de nivel
        //nivel 2 toma 20 puntos subir de nivel
        float puntosBase = (nivelXP * 5 + 10);

        puntosGuardados =+ puntos;

        while (puntosGuardados >= puntosBase)
        {
            puntosGuardados =- puntosBase;
            SubirNivel();
        }

    }






 #endregion



}