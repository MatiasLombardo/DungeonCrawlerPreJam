using UnityEngine;
using UnityEngine.UI;

public class BotonHover : MonoBehaviour
{

    [SerializeField] int au_PasarElMouse;
    [SerializeField] int au_Presionar;


    public void Presionar()
    {
        AudioManager.Instance.PlaySound(au_Presionar);
    }


    void OnMouseEnter()
    {
        AudioManager.Instance.PlaySound(au_PasarElMouse);
    }
    

}