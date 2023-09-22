using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject startfireScreen;
    public Button startButton;
    public GameObject startBackgroundScreen;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        startButton.onClick.AddListener(StartGame);
        startScreen.SetActive(true);
        startfireScreen.SetActive(true);
        startBackgroundScreen.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("tmp");
        Time.timeScale = 1;

    }
}
