using System.Collections;
using Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tools.UI.Card
{
    public class UiPlayerHandUtils : MonoBehaviour
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Fields

        int Count { get; set; }

        [SerializeField] int au_AgarrarCarta, au_JugarCarta;

        [SerializeField] [Tooltip("Prefab of the Card C#")]
        GameObject cardPrefabCs;

        [SerializeField] [Tooltip("World point where the deck is positioned")]
        Transform deckPosition;

        [SerializeField] [Tooltip("Game view transform")]
        Transform gameView;

        IUiPlayerHand PlayerHand { get; set; }

        bool inicial = true;

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Unitycallbacks

        void OnEnable() => PlayerHand = transform.parent.GetComponentInChildren<IUiPlayerHand>();

        IEnumerator Start()
        {
            //starting cards
            //Esto hay que cambiarlo dependiendo del nivel del player
            for (var i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(0.2f);
                DrawCard();
            }
            inicial = false;
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations


        [Button]
        public void DrawCard()
        {
            if ((SistemaDeTurnos.Instance.Get_TurnoPlayer() && SistemaDeTurnos.Instance.Get_AgarrarCarta()) || inicial)
            {
                //TODO: Consider replace Instantiate by an Object Pool Pattern
                AudioManager.Instance.PlaySound(au_AgarrarCarta);
                var cardGo = Instantiate(cardPrefabCs, gameView);
                cardGo.name = "Card_" + Count;
                var card = cardGo.GetComponent<IUiCard>();
                card.transform.position = deckPosition.position;
                Count++;
                //StartCoroutine(AgarrarCartaTiempo(card));
                PlayerHand.AddCard(card);
                SistemaDeTurnos.Instance.Set_AgarrarCartaFalse();
            }

            
        }

        IEnumerator AgarrarCartaTiempo()
        {
            yield return new WaitForSeconds(1);
            
        }

        public void DrawCardEnemigo()
        {
                //TODO: Consider replace Instantiate by an Object Pool Pattern
                AudioManager.Instance.PlaySound(au_AgarrarCarta);
                var cardGo = Instantiate(cardPrefabCs, gameView);
                cardGo.name = "Card_" + Count;
                var card = cardGo.GetComponent<IUiCard>();
                card.transform.position = deckPosition.position;
                Count++;
                PlayerHand.AddCard(card);
            
        }
        //Esta funcion seguramente desaparezca porque agarra cartas randoms
        [SerializeField] bool isPlayer;
        [Button]
        public void PlayCard()
        {
            if (PlayerHand.Cards.Count > 0 && !isPlayer)
            {
                AudioManager.Instance.PlaySound(au_JugarCarta);
                var randomCard = PlayerHand.Cards.RandomItem();
                PlayerHand.PlayCard(randomCard);
            }
            
        }

        /*void Update()
        {
            //Esto hay que cambiarlo
            if (Input.GetKeyDown(KeyCode.Tab)) DrawCard();
            if (Input.GetKeyDown(KeyCode.Space)) PlayCard();
            if (Input.GetKeyDown(KeyCode.Escape)) Restart();
        }*/

        public void Restart() => SceneManager.LoadScene(0);

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}