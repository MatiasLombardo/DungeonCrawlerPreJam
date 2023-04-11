using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContadorDeVida : MonoBehaviour
{
    public static ContadorDeVida Instance;
    public int salud;

    public void Awake()
    {
        Instance = this;
    }

    public TextMeshProUGUI textoSalud;

    public void curar(int valor)
    {
        Debug.Log("Me cure!");
        salud += valor;
        textoSalud.text= $"Health: {salud}";
    }
}
