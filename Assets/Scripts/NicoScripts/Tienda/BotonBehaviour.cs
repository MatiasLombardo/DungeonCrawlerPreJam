using UnityEngine;
using UnityEngine.UI;

public class BotonBehaviour : MonoBehaviour
{

    [SerializeField] Button boton;
    [SerializeField] TiendaBehaviour script;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject carta;
    [SerializeField] int coste;

    private void Start() {
        boton.onClick.AddListener(TaskOnClick);
    }

        
    void TaskOnClick()
    {
        script.SeleccionarCarta(sprite, carta, coste);
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }
}