using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonUsarDelInventario : MonoBehaviour
{
    public ManagerDelInventario managerInv;
    public GameObject boton;
    public itemControllerNew itemDelInventario;
    public void ActivarBotonDeUso(GameObject item)
    {
        boton.gameObject.SetActive(true);
        itemDelInventario=item.GetComponent<itemControllerNew>();
    }
    public void usarDesdeBoton()
    {
        itemDelInventario.UsarItem();
    }
}
