using UnityEngine;
using TMPro;
 
public class TextoDañoTablero : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;
    [SerializeField] GameObject textoCompleto;
    [SerializeField] bool isPlayer;
    string texto;
    void Start()
    {
          texto = m_Object.GetComponent<TMPro.TextMeshProUGUI>().text;
          texto = "Inició sin problemas";

    }

    private void Update() 
    {
        if (isPlayer)
        {
            texto = SistemaDeTurnos.Instance.Get_DañoCarta().ToString();
            textoCompleto.SetActive(!SistemaDeTurnos.Instance.Get_TurnoPlayer());
        }
        else
        {
            texto = SistemaDeTurnos.Instance.Get_DañoCarta().ToString();
            textoCompleto.SetActive(SistemaDeTurnos.Instance.Get_TurnoPlayer());
        }
    }
}