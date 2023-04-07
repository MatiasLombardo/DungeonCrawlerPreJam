using UnityEngine;
using UnityEngine.EventSystems;

namespace Tools.UI.Card
{
    [RequireComponent(typeof(IMouseInput))]
    public class UiCardDrawerClick : MonoBehaviour
    {
        UiPlayerHandUtils CardDrawer { get; set; }
        IMouseInput Input { get; set; }

        void OnEnable()
        {
            CardDrawer = transform.parent.GetComponentInChildren<UiPlayerHandUtils>();
            Input = GetComponent<IMouseInput>();
            Input.OnPointerClick += DrawCard;
        }
        [SerializeField] bool isPlayer;
        void DrawCard(PointerEventData obj) 
        {
            if (isPlayer)
            {
                //AudioManager.Instance.Play(SistemaDeTurnos.Instance.au_AgarrarCarta);
                CardDrawer.DrawCard();
            }
        }
    }

    
}