using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class UIElements : MonoBehaviour
{
    public TMP_Text coinScoreText;
   
    public TMP_Text healthText;
   private int coinScore=0;
    private int damage=0;
    private int health=100;
    public Button RetryButton;

    public TMP_Text gameOverText;
    public UnityEvent OnRetry ;
    // Start is called before the first frame update
    void Start()
    {
        coinScoreText.text = "Coins Collected:"+coinScore;
        healthText.text = "Health:"+health;
        //unityevent obje aktif mi değil mi umursamaz.eventmanager kullanmadan yapmadan hali bu;
        //OnRetry.AddListener(ClickedRetry());
        EventManager.OnClickRetryButton.AddListener(ClickedRetry());
       
    }

    private void OnEnable()
    {
        EventManager.CoinCollected += EventManagerOnCoinCollected;// eventmanagerdaki unityaction a kaydoldum
        EventManager.DamageTaken += EventManagerOnDamageTaken;
        EventManager.HealthBar += EventManagerOnHealthTaken;
        EventManager.Death += EventManagerOnDeath;
     
        

    }

    private UnityAction ClickedRetry()
    {
         Debug.Log("Clicked Retry");
         OnMyRetryButtonClicked();
         return () => { Debug.Log("Clicked Retry"); };
         

    }


    private void EventManagerOnDeath()
    {
        Debug.Log("Game Over");
        gameOverText.gameObject.SetActive(true);
    }


    private void OnDisable()
    {
        EventManager.CoinCollected -= EventManagerOnCoinCollected;
        EventManager.DamageTaken -= EventManagerOnDamageTaken;
        EventManager.HealthBar -= EventManagerOnHealthTaken;
        EventManager.Death -= EventManagerOnDeath;
      
    }

    private void EventManagerOnDamageTaken()
    {
        
        Debug.Log("Damage taken");
        GetDamageScore();
    }

    private void EventManagerOnHealthTaken()
    {
        Debug.Log("Health taken");
        GetHealthScore();

    }

    private void GetHealthScore()
    {
        health = health + damage;
        healthText.text = "Health:"+health;
        if (health == 0)
        {
            EventManager.OnPlayerDeath();
            
            EventManager.OnRetryButton();
           
        }
    }

    public void OnMyRetryButtonClicked()
    {
       
        OnRetry.Invoke();
        OnRetry.RemoveListener(ClickedRetry());
    }

    private void GetDamageScore()
    {

        damage = -20;
        Debug.Log("Damage taken");
    }

    private void EventManagerOnCoinCollected()
    {
       GetCoinScore();
    }

    private void GetCoinScore()
    {
        coinScore++;
        coinScoreText.text = "Coins Collected:"+coinScore;
    }

    // Update is called once per frame
   
}
