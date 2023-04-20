using UnityEngine;

public class PruebaDeSonido : MonoBehaviour 
{
    [SerializeField] int sonidoDev;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("sonido On");
            AudioManager.Instance.PlaySound(sonidoDev);
        }
    }


}