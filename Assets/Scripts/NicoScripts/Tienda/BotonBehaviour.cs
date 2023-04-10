using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BotonBehaviour : MonoBehaviour
{

    [SerializeField] Button boton;
    [SerializeField] TiendaBehaviour script;
    [SerializeField] Image sprite;
    [SerializeField] GameObject carta;
    [SerializeField] int coste;
    [SerializeField] int cantidad;
    [SerializeField] TMP_Text texto_coste;
    [SerializeField] TMP_Text texto_cantidad;

    [SerializeField] Sprite[] sprites;

    private void Awake() 
    {
        BuscadorDeSprites(this.gameObject);
    }


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


    private void BuscadorDeSprites(GameObject objeto)
    {
        string nombre = objeto.GetComponent<Image>().sprite.name;
        Debug.Log(nombre);
        switch (nombre)
        {
            case var value when value == sprites[0].name :
                cantidad = 12;
                coste = 12;
            break;

            case var value when value == sprites[1].name :
                cantidad = 4;
                coste = 12;
            break;

            case var value when value == sprites[2].name :
                cantidad = 5;
                coste = 12;
            break;

            case var value when value == sprites[3].name :
                cantidad = 8;
                coste = 12;
            break;
            case var value when value == sprites[4].name :
                cantidad = 3;
                coste = 12;
            break;
            case var value when value == sprites[5].name :
                cantidad = 5;
                coste = 12;
            break;
            case var value when value == sprites[6].name :
                cantidad = 10;
                coste = 12;
            break;
            case var value when value == sprites[7].name :
                cantidad = 3;
                coste = 12;
            break;
            case var value when value == sprites[8].name :
                cantidad = 4;
                coste = 12;
            break;
            case var value when value == sprites[9].name :
                cantidad = 3;
                coste = 12;
            break;
            case var value when value == sprites[10].name :
                cantidad = 3;
                coste = 12;
            break;
            case var value when value == sprites[11].name :
                cantidad = 2;
                coste = 12;
            break;
            case var value when value == sprites[12].name :
                cantidad = 2;
                coste = 12;
            break;
            case var value when value == sprites[13].name :
                cantidad = 1;
                coste = 12;
            break;
            case var value when value == sprites[14].name :
                cantidad = 1;
                coste = 12;
            break;
            case var value when value == sprites[15].name :
                cantidad = 1;
                coste = 12;
            break;
            case var value when value == sprites[16].name :
                cantidad = 1;
                coste = 12;
            break;
            case var value when value == sprites[17].name :
                cantidad = 1;
                coste = 12;
            break;
            case var value when value == sprites[18].name :
                cantidad = 1;
                coste = 12;
            break;



            default:
            Debug.Log("Error Boton de scripts: " + this.gameObject.name);
            break;
        }

    }


}