using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ManagerDelInventario : MonoBehaviour
{
    public static ManagerDelInventario Instance;

    public List<itemScriptable> Items = new List<itemScriptable>();

    public Transform contenedorDeItems;
    public GameObject itemDelInventario;
    public itemControllerNew[] ItemsInventorio;
    public GameObject brujula;
    private void Awake()
    {
        Instance = this;
    }

    public void Add(itemScriptable item)
    {
        Items.Add(item);
    }
    public void Remove(itemScriptable item)
    {
        Items.Remove(item);
    }
    public void ActivarBrujula()
    {
        brujula.SetActive(true);
    }
    public void ListarItems()
    {
        StartCoroutine(ListarItemsCoroutina());
        //Esto limpia los items viejos para evitar que se repitan los iconos.
        /* foreach(Transform item in contenedorDeItems)
        {
            Destroy(item.gameObject);
        }
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(itemDelInventario, contenedorDeItems);
            var itemName = obj.transform.Find("Nombre").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("Imagen").GetComponent<Image>();

            itemName.text=item.nombreDelObjeto;
            itemIcon.sprite=item.icono;
        } */
        //agregarItemsAInv();
    }
    IEnumerator ListarItemsCoroutina()
    {
        foreach(Transform item in contenedorDeItems)
        {
            Destroy(item.gameObject);
        }
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(itemDelInventario, contenedorDeItems);
            var itemName = obj.transform.Find("Nombre").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("Imagen").GetComponent<Image>();

            itemName.text=item.nombreDelObjeto;
            itemIcon.sprite=item.icono;
        }
        yield return new WaitForSeconds(.3f);
        agregarItemsAInv();
        yield return null;
    }
    public void agregarItemsAInv()
    {
        ItemsInventorio = contenedorDeItems.GetComponentsInChildren<itemControllerNew>();

        for(int i = 0; i< Items.Count; i++)
        {
            ItemsInventorio[i].AgregarItem(Items [i]);
        }
    }
}
