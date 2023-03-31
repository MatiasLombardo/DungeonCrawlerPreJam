using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeEscena : MonoBehaviour
{
    [SerializeField] string scene;
    [SerializeField] Color color;


    private void OnEnable()
    {
        Initiate.Fade(scene, color, 0.5f);
        this.gameObject.SetActive(false);
    }

        
}
