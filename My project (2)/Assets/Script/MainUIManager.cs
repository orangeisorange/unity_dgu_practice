using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIManager : MonoBehaviour
{
    public GameObject startfireScreen;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        // 게임 최초 시작시, 보게될 화면 세팅
        Time.timeScale = 1;
        startButton.onClick.AddListener(StartGame);
        startfireScreen.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 게임 시작 버튼을 누른 경우. 인게임 씬으로 변경.
    public void StartGame()
    {
        SceneManager.LoadScene("tmp");
        Time.timeScale = 1;
    }
}
