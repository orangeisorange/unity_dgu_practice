using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiedUIManager : MonoBehaviour
{
    public GameObject resultScreen;
    public Text resultText;
    public Button restartButton;
    public Button exitButton;
    public GameObject resultBackgroundScreen;

    // Start is called before the first frame update
    void Start()
    {
        // 죽었을 경우, 씬 전환 후, 아래의 명령들을 실행함. 
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(GameExit);
        resultBackgroundScreen.SetActive(true);
        resultScreen.SetActive(true);
        resultText.text = "Game Over!\n Your Score is " + GameGUI.meter;


    }

    // Update is called once per frame
    void Update()
    {

    }
    // 리스타트 버튼을 누르는 경우, 다시 인게임으로 씬 전환
    public void RestartGame()
    {
        SceneManager.LoadScene("tmp");
        Time.timeScale = 1;
        GameGUI.meter = 0;
    }
    // Exit 버튼을 누르는 경우, 게임 종료
    public void GameExit()
    {
        Application.Quit();
    }

}
