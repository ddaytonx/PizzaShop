using System;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaShop.Game
{
    public class PizzaHandler : MonoBehaviour
    {
        [SerializeField] private List<GameObject> pizzaSlice;

        private GameObject currentPizzas;

        public void CutIntoPeices(int number = 1)
        {
            number = number < 1 ? 1 : number > pizzaSlice.Count ? pizzaSlice.Count : number;
            var obj = pizzaSlice[number - 1];
            Destroy(currentPizzas);
            currentPizzas = Instantiate(obj, transform);
        }

        public void Init()
        {
            CutIntoPeices(1);
        }
    }
}