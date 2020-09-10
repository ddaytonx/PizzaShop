using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PizzaShop.Game
{
    public class Customer : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Reference")]
        [SerializeField] private Outline imageOutline = null;
        [SerializeField] private Image image = null;
        [SerializeField] private Text countText = null;

        [Header("Data")]
        public uint SlicesTypeNeeded = 0;
        public uint SlicesGot = 0;

        public void SetData(Sprite randomImage, int slices)
        {
            uint slicesNew = slices < 0 ? 1 : slices > 5 ? 5 : (uint)slices;
            SlicesTypeNeeded = slicesNew;
            image.sprite = randomImage;
            SlicesGot = 0;
            UpdateSlices();
        }

        public void UpdateSlices()
        {
            countText.text = SlicesGot.ToString() + "/" + SlicesTypeNeeded.ToString();
        }

        public void OnDrop(PointerEventData eventData)
        {
            try
            {
                var pizzaObject = eventData.pointerDrag;
                if (pizzaObject != null)
                {
                    var pizzaSlice = pizzaObject.GetComponent<PizzaSlice>();
                    if (pizzaSlice != null)
                    {
                        if (pizzaSlice.SliceType == SlicesTypeNeeded)
                        {
                            AudioManager.Give();
                            SlicesGot++;
                            UpdateSlices();
                            Destroy(pizzaObject);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
        }

        public bool CheckNeeds()
        {
            return SlicesGot == SlicesTypeNeeded;
        }

        public void ResetNeeds()
        {
            SlicesGot = 0;
            UpdateSlices();
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