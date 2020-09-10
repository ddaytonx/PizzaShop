using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaShop.Game
{
    public class LevelManager : MonoBehaviour
    {
        public uint CustomerCount;

        public CustomerHandler CustomerHandler;
        public PizzaHandler PizzaHandler;

        public void Start()
        {
            CustomerHandler.Init((int)CustomerCount);
            PizzaHandler.Init();
        }
    }
}