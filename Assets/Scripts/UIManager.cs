using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject panelPause;
    [SerializeField] public GameObject panelNextLevel;
    [SerializeField] public TextMeshProUGUI timerUI;

    //Per caricare la scena successiva
    //private int prevSceneToLoad;

    private void Start()
    {
        Time.timeScale = 1;
        timerUI.text = 0.ToString();
        //Per caricare la scena successiva
        //prevSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

    }

    private void Update()
    {
        PauseGame();
    }

    public void UpdateTimer(float time)
    {
        timerUI.text = Mathf.FloorToInt(time).ToString();
    }

    //Carica il menu
    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    //Inizia il gioco
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    //Chiude il gioco
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        //Se premo esc stoppa il gioco
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelPause.SetActive(true);
            Time.timeScale = 0;
            GameObject.Find("Player").GetComponent<Shoot_Controller>().enabled = false;
        }
    }

    //Riattiva il gioco
    public void ResumeGame()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1;
        GameObject.Find("Player").GetComponent<Shoot_Controller>().enabled = true;
    }

    public void NextLevel1()
    {
        SceneManager.LoadScene("Game 1");
        timerUI.text = 0.ToString();
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
