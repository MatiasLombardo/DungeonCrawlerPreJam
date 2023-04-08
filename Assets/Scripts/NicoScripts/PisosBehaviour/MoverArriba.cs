using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverArriba : MonoBehaviour
{

    [SerializeField] private float velocidad;
    public GameObject textoFinal;
    Vector3 pos;

    private void Start() 
    {
        pos = new Vector3(0f, 5045f, 0f);
    }

    void FixedUpdate()
    {
    
            //Debug.Log(transform.position.y);

        if(transform.position.y < 46.86f)
        {
        transform.position += new Vector3 (0f, velocidad, 0f);
        }
        else 
        {
            textoFinal.SetActive(true);
        }

    }


}
