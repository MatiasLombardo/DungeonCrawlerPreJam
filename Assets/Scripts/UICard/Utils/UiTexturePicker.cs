using System.Linq;
using Extensions;
using UnityEngine;
using System.Collections.Generic;


namespace Tools.UI.Card
{
    /// <summary>
    ///     Picks a Texture randomly when it Awakes.
    /// </summary>
    public class UiTexturePicker : MonoBehaviour
    {
        //[SerializeField] Sprite[] Sprites; //de prueba
        [SerializeField] SpriteRenderer MyRenderer { get; set; }
        [SerializeField] GameObject cartaPadre;
        public bool isPlayer = true;

        [SerializeField] Sprite[] posiblesCartas;


        void OnEnable()
        {

            MyRenderer = GetComponent<SpriteRenderer>();
            if(isPlayer)
            {
                //Esto tiene que cambiar dependiendo del mazo y de que cantidad de cartas pueda llevar
                //El mazo: tenes entre todas las cartas que fuiste recolectando

                //if (Sprites.Length > 0)
                //MyRenderer.sprite = Sprites.ToList().RandomItem(); // de prueba
                //MyRenderer.sprite = agarra una carta
                //Suma un punto
                MazoManager.Instance.ContadorDeCartas();

                MyRenderer.sprite = MazoManager.Instance.Get_SpriteActual();


                PosiblesCartas();
                

                //Esto agarra un random de todo el mazo
                //Hay que cambiarlo por agarrar una lista que va cambiando
            }
            else
            {
                MazoEnemigoManager.Instance.ContadorDeCartas();
                MyRenderer.sprite = MazoEnemigoManager.Instance.Get_SpriteActual();
                PosiblesCartas();
            }
            

        }


        private void PosiblesCartas()
        {

            string nombre = MyRenderer.sprite.name;
            int daño;
            int absorber;
            switch (nombre)
            {
                
                case var value when value == posiblesCartas[0].name :
                    daño = 12;
                    absorber = 1;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[1].name :
                    daño = 7;
                    absorber = 3;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[2].name :
                    daño = 4;
                    absorber = 6;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[3].name :
                    daño = 5;
                    absorber = 5;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[4].name :
                    daño = 8;
                    absorber = 16;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[5].name :
                    daño = 3;
                    absorber = 8;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[6].name :
                    daño = 4;
                    absorber = 5;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[7].name :
                    daño = 0;
                    absorber = 12;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[8].name :
                    daño = 6;
                    absorber = 4;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[9].name :
                    daño = 2;
                    absorber = 9;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[10].name :
                    daño = 6;
                    absorber = 8;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[11].name :
                    daño = 4;
                    absorber = 11;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[12].name :
                    daño = 1;
                    absorber = 10;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[13].name :
                    daño = 15;
                    absorber = 10;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[14].name :
                    daño = 13;
                    absorber = 15;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[15].name :
                    daño = 10;
                    absorber = 18;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[16].name :
                    daño = 8;
                    absorber = 20;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[17].name :
                    daño = 5;
                    absorber = 25;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[18].name :
                    daño = 15;
                    absorber = 12;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;

                //cartas estados anormales
                case var value when value == posiblesCartas[19].name :
                    daño = 1;
                    absorber = 1;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[20].name :
                    daño = 1;
                    absorber = 1;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;


                //cartas enemigos
                case var value when value == posiblesCartas[21].name :
                    daño = 99;
                    absorber = 10;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;
                case var value when value == posiblesCartas[22].name :
                    daño = 10;
                    absorber = 99;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);
                break;


                default:
                    daño = 12;
                    absorber = 1;
                    cartaPadre.GetComponent<Tools.UI.Card.UiCardComponent>().Set_Daño(daño, absorber);

                    Debug.Log("Error UITexturePicker");
                break;

            }

            
        }


        
    }
}