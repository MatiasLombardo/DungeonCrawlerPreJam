using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescripcionItem : MonoBehaviour
{
    public TMP_Text descripcionTexto;
    public itemControllerNew itemDelInventario;

    public void EscribirDescripcion(GameObject item)
    {
        itemDelInventario=item.GetComponent<itemControllerNew>();
        descripcionTexto.SetText(itemDelInventario.item.descripcionDeEsteItem);
    }
}
