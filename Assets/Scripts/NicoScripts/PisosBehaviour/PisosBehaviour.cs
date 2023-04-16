using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisosBehaviour : MonoBehaviour
{

    [SerializeField] AudioClip ms_PrimerPiso;
    [SerializeField] AudioClip ms_SegundoPiso;
    [SerializeField] AudioClip ms_TercerPiso;
    
    [SerializeField] AudioClip ms_NoBoss;


    private void Awake() 
    {
        AudioManager.Instance.PlayMusic(ms_PrimerPiso);
    }



    public void AvanzarAlSegundoPiso()
    {
        AudioManager.Instance.PlayMusic(ms_SegundoPiso);
    }

    public void AvanzarAlTercerPiso()
    {
        AudioManager.Instance.PlayMusic(ms_TercerPiso);
    }

    public void MatarAlBoss()
    {
        AudioManager.Instance.PlayMusic(ms_NoBoss);
    }
}
