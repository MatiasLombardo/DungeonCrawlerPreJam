using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickearSobreObjetoInv : MonoBehaviour
{
    private GameObject item;
    void Start()
    {
        item =  this.gameObject;
    }
    public void ActivarUso()
    {
        GameObject.Find("ActivadorDeUso").GetComponent<BotonUsarDelInventario>().ActivarBotonDeUso(item);
    }
}
