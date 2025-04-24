using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class UIManager : MonoBehaviour
{
    public GameObject startButton;     
    public GameObject replayButton;    
    public GameObject finishGoal;     
    public GameObject player;          

    private PlayerHealth playerHealth;  

    void Start()
    {
     
        startButton.SetActive(true);
        replayButton.SetActive(false);

     
        playerHealth = FindObjectOfType<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    void Update()
    {
       
        if (playerHealth.currentHealth <= 0 || HasReachedFinishGoal())
        {
            ShowReplayButton(); 
            HidePlayer();      
        }
    }

   
    bool HasReachedFinishGoal()
    {
        return finishGoal != null && Vector3.Distance(transform.position, finishGoal.transform.position) < 1f;
    }

    
    void ShowReplayButton()
    {
        replayButton.SetActive(true); 
        startButton.SetActive(false);  
    }


    void HidePlayer()
    {
        if (player != null)
        {
            player.SetActive(false);  
        }
    }

 
    public void ShowStartButton()
    {
        startButton.SetActive(true);
    }


    public void StartGame()
    {
        startButton.SetActive(false);  
        playerHealth.ResetHealth();   
        player.SetActive(true);        
    }

    
    public void RestartGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  

       
        playerHealth.ResetHealth();  
        startButton.SetActive(false); 
        replayButton.SetActive(false); 
        player.SetActive(true);        
    }
}
