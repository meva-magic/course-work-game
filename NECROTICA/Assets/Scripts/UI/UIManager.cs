using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject winGameScreen;  
    public GameObject menuScreen;       

    private bool inMenu;            
    
    public GameObject sword;           

    public static UIManager instance;   

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        Menu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }

        if (inMenu && Input.GetKeyDown(KeyCode.Space))
        {
            CloseMenu();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerHealth.instance.TakeDamage(25);
        }
    }
    
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
    }

    public void GetSword()
    {
        if (sword == null)
        {
            Debug.LogError("Sword is not assigned in UIManager.");
            return;
        }
        sword.SetActive(true);
    }

    public void DisableUI()
    {
        GameObject[] uiElements = GameObject.FindGameObjectsWithTag("UI");

        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(false);
        }
    }

    public void GameOver()
    {
        DisableUI(); 
        gameOverScreen.SetActive(true); 
        AudioManager.instance.Play("PlayerDeath"); 
        AudioManager.instance.Stop("LevelMusic"); 
        Time.timeScale = 0f; 
        UnlockCursor(); 
    }

    public void WinGame()
    {
        DisableUI(); 
        winGameScreen.SetActive(true);
        AudioManager.instance.Play("PlayerWin");
        AudioManager.instance.Stop("LevelMusic"); 
        Time.timeScale = 0f; 
        UnlockCursor(); 
    }

    public void Menu()
    {
        menuScreen.SetActive(true); 
        AudioManager.instance.Play("LevelMusic"); 
        Time.timeScale = 0f; 
        inMenu = true; 
        UnlockCursor(); 
    }

    private void CloseMenu()
    {
        Time.timeScale = 1f;
        menuScreen.SetActive(false); 
        inMenu = false; 
        LockCursor();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
