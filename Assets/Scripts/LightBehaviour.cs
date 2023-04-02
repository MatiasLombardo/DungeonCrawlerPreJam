using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    [SerializeField] Light lightup;
    [SerializeField] float minIntensity=5f;
    [SerializeField] float maxIntensity=8f;
    [SerializeField] float t=0f;

    // Start is called before the first frame update
    void Awake()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        lightup.intensity = Mathf.Lerp(minIntensity,maxIntensity,t);
        t += 0.5f * Time.deltaTime;

        if (t > 1.0f)
        {
            float aux = maxIntensity;
            maxIntensity = minIntensity;
            minIntensity = aux;
            t = 0.0f;
        }
    }
}
