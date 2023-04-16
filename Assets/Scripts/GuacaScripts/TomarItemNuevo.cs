using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TomarItemNuevo : MonoBehaviour
{
    public itemScriptable item;

    public void Pickup()
    {
        ManagerDelInventario.Instance.Add(item);
        Destroy(gameObject);
    }
}
