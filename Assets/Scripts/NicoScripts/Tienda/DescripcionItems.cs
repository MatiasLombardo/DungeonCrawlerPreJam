using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescripcionItems : MonoBehaviour
{
    
    private SpriteRenderer sprite;
    private Color colorDefault;
    private GameObject _descripcion;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string textoEs;
    [SerializeField] private string textoEn;
    [SerializeField] private bool hasSprite = true;
    private bool textoEnProgreso = false;
    private float typingTime = 0.05f;
    void Awake()
    {
        _descripcion = transform.GetChild(0).gameObject;
        _descripcion.SetActive(false);
        if(hasSprite)
        {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        colorDefault = Color.white;
        }        
    }
    void OnMouseOver()
    {
        _descripcion.SetActive(true);
        if(hasSprite)
        {
        sprite.color = Color.gray;
        }
        if(!textoEnProgreso)
        {
            textoEnProgreso = true;
            StartCoroutine(ShowLine(textoEs));
        }
    }
    void OnMouseExit()
    {
        StopAllCoroutines();
        textoEnProgreso = false;
        _descripcion.SetActive(false);
        if(hasSprite)
        {
        sprite.color = colorDefault;
        }
    }
    private IEnumerator ShowLine(string textoLanguage)
    {
        dialogueText.text = string.Empty;

        foreach(char ch in textoLanguage)
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
}
