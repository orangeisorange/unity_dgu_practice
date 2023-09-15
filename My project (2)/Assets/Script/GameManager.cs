using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject resultScreen;
    public Text resultText;
    public Button restartButton;
    public GameObject resultBackgroundScreen;
    private bool isGameOver = false;

    public bool isGameStart = false;
    public GameObject startScreen;
    public GameObject startfireScreen;
    public Button startButton;
    public GameObject startBackgroundScreen;

    // Start is called before the first frame update
    void Start()
    {
        resultScreen.SetActive(false);
        resultBackgroundScreen.SetActive(false);


        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerDied()
    {
        if(!isGameOver)
        {
            isGameOver = true;
            Time.timeScale = 0;
            resultBackgroundScreen.SetActive(true);
            resultScreen.SetActive(true);
            resultText.text = "Game Over!\n Your Score is " + GameGUI.meter;
        }
    }

    public void MainScreen()
    {
        if (!isGameStart)
        {
            isGameStart = true;
            Time.timeScale = 0;
            startScreen.SetActive(true);
            startfireScreen.SetActive(true);
            startBackgroundScreen.SetActive(true);
        }

    }
    private void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // 게임 로직 계속 실행
    }

    public void StartGame()
    {

        isGameStart = true;
        Time.timeScale = 1;
        startScreen.SetActive(false);
        startfireScreen.SetActive(false);
        startBackgroundScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
