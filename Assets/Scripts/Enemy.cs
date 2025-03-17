using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   private void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.tag == "Player")
      {
         Debug.Log("Player damaged");
         EventManager.OnDamageTaken();
         EventManager.OnHealthBar();
         Destroy(gameObject);
      }
   }
}
