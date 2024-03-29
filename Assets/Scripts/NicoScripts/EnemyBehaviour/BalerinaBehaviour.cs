using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalerinaBehaviour : MonoBehaviour
{

    int tipoEnemigo = 12;
    [SerializeField] float vidaMaxima = 30f;
    [SerializeField] PlayerInput codigoPlayer;
    [SerializeField] Transform cara;
    [SerializeField] int preludio = 9;
    [SerializeField] int son_Titulo = 0;
    [SerializeField] float tiempoDeInterludio = 15;
    [SerializeField] int musicaInicioFase1 = 10;
    [SerializeField] int musicaInicioFase2 = 8;
    [SerializeField] Sprite spriteEnemigofase1;
    [SerializeField] Sprite spriteEnemigofase2;
    [SerializeField] GameObject ventanaDialogo;
    [SerializeField] GameObject tituloPelea;
    float oldPos, newPos;
    int temp2 = 0;
    [SerializeField] bool terminoInterludio;
    bool segundaFase;



    private void OnTriggerStay(Collider other) 
    {

        newPos = Vector3.Distance(other.transform.position, transform.position);
        if (temp2 <= 5)
        {
            oldPos = Vector3.Distance(other.transform.position, transform.position);
        }
        if (newPos == oldPos)
        {
            AudioManager.Instance.StopAll();
            codigoPlayer.GirarCamaraA(cara);
            //inicia el dialogo
            StartCoroutine(PrepararseParaCombate());
        }
        temp2++;

    }

    bool preludiob;

    bool val1 = true;
    private IEnumerator PrepararseParaCombate()
    {
        //que aqui haga algo raro como acercar la camara o algo que anticipe su ataque
        
        //acciona el interludio
        //Debug.Log("back up del mazo");
        if (val1)
        {
            MazoManager.Instance.BackUpDeMazo2();
            val1 = false;
        }
        yield return new WaitForSeconds(1f);
        AudioManager.Instance.PlayMusic(preludio);
        preludiob = true;
        yield return new WaitForSeconds(2f);
        //Acciona el titulo de la pelea "THE WOLF MIEDO A NO SE ALGO SE ME OCURRIRA"
        AudioManager.Instance.PlaySound(son_Titulo);
        tituloPelea.SetActive(true);
        yield return new WaitForSeconds(2);
        //se desactiva el titulo
        tituloPelea.SetActive(false);
        //acciona el dialogo
        ventanaDialogo.SetActive(true);
        //espera a que el dialogo termine, y la musica tambien
        yield return new WaitUntil(() => AudioManager.Instance.Get_IsPlaying() && !ventanaDialogo.activeSelf);
        AudioManager.Instance.StopAll();
        //activa la musica de combate y arranca el combate
        SistemaDeTurnos.Instance.Set_EstadoBABAILARINA();
        SistemaDeTurnos.Instance.IniciarCombateBoss(vidaMaxima, musicaInicioFase1);
        yield return new WaitForSeconds(2f);
        MazoEnemigoManager.Instance.Set_TipoEnemigo(tipoEnemigo, spriteEnemigofase1);
        yield return new WaitForSeconds(1f);
        segundaFase = true;
        this.gameObject.SetActive(false);
    }
int temp4 = 0;
bool temp5 = true;
    /*void Update()
    {
        
        if (preludiob)
        {
            //Debug.Log(AudioManager.Instance.MusicSource.time);
            if (AudioManager.Instance.Get_IsPlaying() && temp4 > 500)
            {
                AudioManager.Instance.StopMusic();
                preludiob = false;
            }
            temp4++;
            
        }
    }*/


    private void OnEnable() 
    {
        if (segundaFase)
        {
            StartCoroutine(PrepararseParaSegundaFase());
        }
    }

    private IEnumerator PrepararseParaSegundaFase()
    {

        ventanaDialogo.SetActive(true);
        //espera a que el dialogo termine, y la musica tambien
        yield return new WaitUntil(() => !ventanaDialogo.activeSelf);
        //activa la musica de combate y arranca el combate
        SistemaDeTurnos.Instance.IniciarCombateBoss(vidaMaxima, musicaInicioFase2);
        yield return new WaitForSeconds(2f);
        MazoEnemigoManager.Instance.Set_TipoEnemigo(tipoEnemigo, spriteEnemigofase2);
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }

}
