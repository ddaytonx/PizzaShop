using System;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaShop.Game
{
    public class CustomerHandler : MonoBehaviour
    {
        public List<Sprite> CustomersImage;
        public GameObject CustomerObject;

        public List<Customer> Customers;

        public void Init(int customerCount)
        {
            customerCount = customerCount < 1 ? 1 : customerCount > 10 ? 10 : customerCount;
            Customers = new List<Customer>();
            for (int i = 0; i < customerCount; i++)
            {
                try
                {
                    var randomImage = CustomersImage[UnityEngine.Random.Range(0, CustomersImage.Count)];
                    if (randomImage == null) throw new Exception("Index out of range");
                    var customer = Instantiate(CustomerObject, transform).GetComponentInChildren<Customer>(true);
                    customer.SetData(randomImage, UnityEngine.Random.Range(1, 6));
                    Customers.Add(customer);
                }
                catch (Exception ex)
                {
                    i--;
                    if (i < 0) i = 0;
                    Debug.LogError(ex);
                }
            }
        }

        public void ResetCustomerNeeds()
        {
            foreach (var customer in Customers)
            {
                if (customer != null) customer.ResetNeeds();
            }
        }

        public bool FinishCustomer()
        {
            try
            {
                bool anySucess = false;
                if (Customers.Count == 0) return true;
                else
                {
                    var removeIndex = new List<int>();
                    var index = 0;

                    foreach (var customer in Customers)
                    {
                        if (customer != null)
                        {
                            var delete = customer.CheckNeeds();
                            if (delete)
                            {
                                anySucess = true;
                                Destroy(customer.gameObject);
                                removeIndex.Add(index);
                            }
                        }
                        else removeIndex.Add(index);
                        index++;
                    }

                    foreach (var customerIndex in removeIndex)
                    {
                        Customers.RemoveAt(customerIndex);
                    }

                   

                    if (Customers.Count == 0) return true;
                    else
                    {
                        if (anySucess == true)
                        {
                            AudioManager.Success();
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
                return false;
            }
        }
    }
}
