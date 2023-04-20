using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBossBehaviour : MonoBehaviour
{
/*
    int tipoEnemigo = 13;
    [SerializeField] float vidaMaxima = 30f;
    [SerializeField] PlayerInput codigoPlayer;
    [SerializeField] Transform cara;
    [SerializeField] AudioClip preludio;
    [SerializeField] AudioClip son_Titulo;
    [SerializeField] float tiempoDeInterludio = 15;
    [SerializeField] AudioClip musicaInicioFase1;
    [SerializeField] AudioClip musicaInicioFase2;
    [SerializeField] Sprite spriteEnemigoFase1;
    [SerializeField] Sprite spriteEnemigoFase2;
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
            AudioManager.Instance.StopMusic();
            codigoPlayer.GirarCamaraA(cara);
            //inicia el dialogo
            StartCoroutine(PrepararseParaCombate());
        }
        temp2++;

    }

    bool preludiob;

    private IEnumerator PrepararseParaCombate()
    {
        //que aqui haga algo raro como acercar la camara o algo que anticipe su ataque
        
        //acciona el interludio
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
        AudioManager.Instance.StopMusic();
        //activa la musica de combate y arranca el combate
        SistemaDeTurnos.Instance.Set_EstadoBABFINAL();
        SistemaDeTurnos.Instance.IniciarCombateBoss(vidaMaxima, musicaInicioFase1);
        yield return new WaitForSeconds(2f);
        MazoEnemigoManager.Instance.Set_TipoEnemigo(tipoEnemigo, spriteEnemigoFase1);
        yield return new WaitForSeconds(1f);
        segundaFase = true;
        this.gameObject.SetActive(false);
    }

    int temp4 = 0;
    bool temp5 = true;
    
    void Update()
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
    }


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
        MazoEnemigoManager.Instance.Set_TipoEnemigo(tipoEnemigo, spriteEnemigoFase2);
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
*/
}
