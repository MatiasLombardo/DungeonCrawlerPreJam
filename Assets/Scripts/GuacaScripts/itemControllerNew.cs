using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemControllerNew : MonoBehaviour
{
    public itemScriptable item;
    public void RemoverItem()
    {
        ManagerDelInventario.Instance.Remove(item);
        Destroy(gameObject);
    }
    public void AgregarItem(itemScriptable nuevoItem)
    {
        item = nuevoItem;
    }
    public void UsarItem()
    {
        switch(item.tipoDeItem)
        {
            case itemScriptable.TipoDeItem.Pocion:
            ContadorDeVida.Instance.curar(item.valor);
            RemoverItem();
            break;
            case itemScriptable.TipoDeItem.NoUsable:
            Debug.Log("Este item no se puede usar");
            break;
            case itemScriptable.TipoDeItem.Brujula:
            Debug.Log("Activaste la brujula!");
            ManagerDelInventario.Instance.ActivarBrujula();
            RemoverItem();
            break;
        }

    }
}
