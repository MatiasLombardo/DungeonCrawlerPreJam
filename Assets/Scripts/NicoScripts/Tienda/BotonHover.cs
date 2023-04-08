using UnityEngine;
using UnityEngine.UI;

public class BotonHover : MonoBehaviour
{

    [SerializeField] AudioClip au_PasarElMouse;
    [SerializeField] AudioClip au_Presionar;


    public void Presionar()
    {
        AudioManager.Instance.Play(au_Presionar);
    }


    void OnMouseEnter()
    {
        AudioManager.Instance.Play(au_PasarElMouse);
    }
    

}