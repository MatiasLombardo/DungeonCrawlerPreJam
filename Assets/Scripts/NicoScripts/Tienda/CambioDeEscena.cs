using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeEscena : MonoBehaviour
{
    [SerializeField] string scene;
    [SerializeField] Color color;
    [SerializeField] float temp = 0.5f;


    private void OnEnable()
    {
        Initiate.Fade(scene, color, temp);
        this.gameObject.SetActive(false);
    }

        
}
