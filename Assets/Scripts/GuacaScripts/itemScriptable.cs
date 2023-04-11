using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Nuevo objeto" , menuName = "Objeto del inventario/Crear nuevo objeto")]
public class itemScriptable : ScriptableObject
{
    public int id;
    public string nombreDelObjeto;
    public int valor;
    public Sprite icono;
    public TipoDeItem tipoDeItem;

    public enum TipoDeItem
    {
        Pocion,
        NoUsable,
        Brujula
    }
}
