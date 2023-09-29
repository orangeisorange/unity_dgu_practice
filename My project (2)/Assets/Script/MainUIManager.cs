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
        // ���� ���� ���۽�, ���Ե� ȭ�� ����
        Time.timeScale = 1;
        startButton.onClick.AddListener(StartGame);
        startfireScreen.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // ���� ���� ��ư�� ���� ���. �ΰ��� ������ ����.
    public void StartGame()
    {
        SceneManager.LoadScene("tmp");
        Time.timeScale = 1;
    }
}
