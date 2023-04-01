using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BotonBehaviour : MonoBehaviour
{

    [SerializeField] Button boton;
    [SerializeField] TiendaBehaviour script;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject carta;
    [SerializeField] int coste;
    [SerializeField] int cantidad;
    [SerializeField] TMP_Text texto_coste;
    [SerializeField] TMP_Text texto_cantidad;

    private void Start() {
        texto_coste.text = coste.ToString();
        texto_cantidad.text = cantidad.ToString();
        boton.onClick.AddListener(TaskOnClick);
    }

        
    void TaskOnClick()
    {
        script.SeleccionarCarta(sprite, carta, coste);
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }
}