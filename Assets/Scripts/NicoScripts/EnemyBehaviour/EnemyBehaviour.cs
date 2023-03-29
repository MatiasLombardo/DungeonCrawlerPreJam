using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] int tipoEnemigo;
    [SerializeField] float vidaMaxima = 15f;
    [SerializeField] PlayerInput codigoPlayer;
    [SerializeField] Transform cara;

    private void OnTriggerEnter(Collider other) 
    {
        
        if (other.tag == "Player")
        {
            codigoPlayer.GirarCamaraA(cara);
            StartCoroutine(PrepararseParaCombate());

        }

    }

    private IEnumerator PrepararseParaCombate()
    {
        //que aqui haga algo raro como acercar la camara o algo que anticipe su ataque
        yield return new WaitForSeconds(4f);
        SistemaDeTurnos.Instance.IniciarCombate(tipoEnemigo, vidaMaxima);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

}
