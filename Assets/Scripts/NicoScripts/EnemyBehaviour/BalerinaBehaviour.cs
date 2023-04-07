using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalerinaBehaviour : MonoBehaviour
{

    int tipoEnemigo = 11;
    [SerializeField] float vidaMaxima = 30f;
    [SerializeField] PlayerInput codigoPlayer;
    [SerializeField] Transform cara;
    [SerializeField] AudioClip preludio;
    [SerializeField] AudioClip son_Titulo;
    [SerializeField] float tiempoDeInterludio = 15;
    [SerializeField] AudioClip musicaInicioFase1;
    [SerializeField] AudioClip musicaInicioFase2;
    [SerializeField] Sprite spriteEnemigo;
    [SerializeField] GameObject ventanaDialogo;
    [SerializeField] GameObject tituloPelea;
    float oldPos, newPos;
    int temp2 = 0;
    [SerializeField] bool terminoInterludio;




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

    private IEnumerator PrepararseParaCombate()
    {
        //que aqui haga algo raro como acercar la camara o algo que anticipe su ataque
        //acciona el interludio
        yield return new WaitForSeconds(1f);
        AudioManager.Instance.PlayMusic(preludio);
        yield return new WaitForSeconds(2f);
        //Acciona el titulo de la pelea "THE WOLF MIEDO A NO SE ALGO SE ME OCURRIRA"
        AudioManager.Instance.Play(son_Titulo);
        tituloPelea.SetActive(true);
        yield return new WaitForSeconds(2);
        //se desactiva el titulo
        tituloPelea.SetActive(false);
        //acciona el dialogo
        ventanaDialogo.SetActive(true);
        //espera a que el dialogo termine, y la musica tambien
        yield return new WaitUntil(() => AudioManager.Instance.Get_IsPlaying() && !ventanaDialogo.activeSelf);
        //activa la musica de combate y arranca el combate
        SistemaDeTurnos.Instance.Set_EstadoBABAILARINA();
        SistemaDeTurnos.Instance.IniciarCombateBoss(vidaMaxima, musicaInicioFase1);
        yield return new WaitForSeconds(2f);
        MazoEnemigoManager.Instance.Set_TipoEnemigo(tipoEnemigo, spriteEnemigo);
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }

}
