using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIElements : MonoBehaviour
{
    public TMP_Text coinScoreText;
    public GameObject alleffect;
    public TMP_Text healthText;
   private int coinScore=0;
    private int damage=0;
    private int health=100;
    public Button RetryButton;
    [SerializeField] private List<GameObject> effects = new List<GameObject>();

    public TMP_Text gameOverText;
    public UnityEvent OnRetry ;
 //   [SerializeField]private GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        coinScoreText.text = "Coins Collected:"+coinScore;
        healthText.text = "Health:"+health;
        
        RetryButton.onClick.AddListener(OnMyRetryButtonClicked);
        
        //unityevent obje aktif mi değil mi umursamaz.eventmanager kullanmadan yapmadan hali bu;
      //  OnRetry.AddListener(OnMyRetryButtonClicked);
        
       // EventManager.OnClickRetryButton.AddListener(ClickedRetry());
     
       
    }
      


    private void OnEnable()
    {
        EventManager.CoinCollected += EventManagerOnCoinCollected;// eventmanagerdaki unityaction a kaydoldum
        EventManager.DamageTaken += EventManagerOnDamageTaken;
        EventManager.HealthBar += EventManagerOnHealthTaken;
        EventManager.Death += EventManagerOnDeath;
        EventManager.OnClickRetryButton.AddListener(OnMyRetryButtonClicked);
     
        

    }

    
    private void EventManagerOnDeath()
    {
        Debug.Log("Game Over");
        gameOverText.gameObject.SetActive(true);
        PlayEffects("Death");
    }


    private void OnDisable()
    {
        EventManager.CoinCollected -= EventManagerOnCoinCollected;
        EventManager.DamageTaken -= EventManagerOnDamageTaken;
        EventManager.HealthBar -= EventManagerOnHealthTaken;
        EventManager.Death -= EventManagerOnDeath;
        EventManager.OnClickRetryButton.RemoveListener(OnMyRetryButtonClicked);
      
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
            
           // EventManager.OnRetryButton();
           
        }
    }

    private void OnMyRetryButtonClicked()
    {
        PlayEffects("retry");
        OnRetry.Invoke();
        Debug.Log("Retry Button clicked");
     
        gameOverText.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
         
       
        
    }


    public void PlayEffects(string effecttag)
    {
        effects.Find(gameObject => gameObject.tag == effecttag).SetActive(true);
        //deathEffect.SetActive(true);
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
