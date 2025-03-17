using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Destructable player");
            
            //Evente haber et  coin toplandı diye
          EventManager.OnCoinCollected();
          Destroy(gameObject);
          
            
         
            
        }
    }
}
