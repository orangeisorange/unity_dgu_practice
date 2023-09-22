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
    public GameObject resultBackgroundScreen;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        resultBackgroundScreen.SetActive(true);
        resultScreen.SetActive(true);
        resultText.text = "Game Over!\n Your Score is " + GameGUI.meter;


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("tmp");
        Time.timeScale = 1;
        GameGUI.meter = 0;
    }

}
