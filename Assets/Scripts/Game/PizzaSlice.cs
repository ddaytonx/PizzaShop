using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PizzaShop.Game
{
    public class PizzaSlice : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private Vector3 originalPosition = Vector3.zero;
        private Outline imageOutline = null;
        private Image image = null;

        public uint SliceType = 1;

        private void Start()
        {
            originalPosition = transform.localPosition;
            imageOutline = GetComponentInChildren<Outline>(true);
            image = GetComponentInChildren<Image>(true);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            image.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            image.raycastTarget = true;
            transform.localPosition = originalPosition;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            imageOutline.effectDistance = new Vector2(4, -4);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            imageOutline.effectDistance = new Vector2(2, -2);
        }
    }
}
