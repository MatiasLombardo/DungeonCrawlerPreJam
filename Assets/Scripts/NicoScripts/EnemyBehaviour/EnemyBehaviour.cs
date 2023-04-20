using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] int tipoEnemigo;
    [SerializeField] float vidaMaxima = 15f;
    [SerializeField] PlayerInput codigoPlayer;
    [SerializeField] Transform cara;
    [SerializeField] int musica;
    [SerializeField] Sprite spriteEnemigo;
    float oldPos, newPos;
    int temp2 = 0;

    private void OnTriggerStay(Collider other) 
    {

        newPos = Vector3.Distance(other.transform.position, transform.position);
        if (temp2 <= 5)
        {
            oldPos = Vector3.Distance(other.transform.position, transform.position);
        }
        if (newPos == oldPos)
        {
            codigoPlayer.GirarCamaraA(cara);
            StartCoroutine(PrepararseParaCombate());
        }
        temp2++;

    }

    private IEnumerator PrepararseParaCombate()
    {
        //que aqui haga algo raro como acercar la camara o algo que anticipe su ataque
        
        yield return new WaitForSeconds(1f);
        
        SistemaDeTurnos.Instance.IniciarCombate(vidaMaxima, musica);
        yield return new WaitForSeconds(2f);
        MazoEnemigoManager.Instance.Set_TipoEnemigo(tipoEnemigo, spriteEnemigo);
        yield return new WaitForSeconds(1f);
        
        Destroy(this.gameObject);
    }

}
