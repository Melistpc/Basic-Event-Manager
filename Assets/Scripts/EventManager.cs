using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


    public static class EventManager 
    {
        public static event UnityAction CoinCollected;
        public static event UnityAction HealthBar;
        public static event UnityAction DamageTaken;
        public static event UnityAction Death;
   
        public static UnityEvent OnClickRetryButton = new UnityEvent();
   
        public static void OnCoinCollected() => CoinCollected?.Invoke();
        public static void OnHealthBar() => HealthBar?.Invoke();
        public static void OnDamageTaken() => DamageTaken?.Invoke();
        public static void OnPlayerDeath() => Death?.Invoke();
        public static void OnRetryButton() => OnClickRetryButton?.Invoke();
    }
   
   
   //UnityAction Action gibi kullanılırken,UnityEvent event Action gibi kullanılmaz.
   //Daha çok “Button”larda yaptığımız gibi AddListener() ve RemoveListener() kullanılır.
   


   

