using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Limite di tempo
    [SerializeField] float timeLimit = 0;
    //Tempo trascorso
    [SerializeField] float elapsedTime;
    //Richiamo UIManager
    UIManager UIM;

    // Start is called before the first frame update
    void Start()
    {
        UIM = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerController();
    }

    void TimerController()
    {
        elapsedTime -= Time.deltaTime;
        UIM.UpdateTimer(elapsedTime);

        if(elapsedTime <= timeLimit)
        {
            Time.timeScale = 0;
            UIM.panelNextLevel.SetActive(true);
            UIM.timerUI.text = "0";
        }
    }
}
