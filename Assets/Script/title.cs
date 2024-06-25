using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Title : MonoBehaviour
{

    public GameObject SettingWindow; // 설정창을 저장해 둘 윈도우
    public GameObject ContinueButton; // 

    // 처음 설정창을 비활성화
    void Start()
    {
        SettingWindow.SetActive(false);
    }

    // Setting 창이 켜져 있는 경우 Esc키를 누른다면 언제나 window 종료
    void Update()
    {
        if (SettingWindow.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SettingWindow.SetActive(false);
            }
        }
    }

    // StartGame 버튼을 누를 경우 특정 Scene로 Scene변경
    public void startgame()
    {
        // SceneManager.LoadScene("Merge 2");
    }

    // LoadGame 버튼을 누를 경우 특정 Scene로 로드함
    public void Loadgame()
    {
        // SceneManager.LoadScene("Merge 2");
    }

    // Setting 버튼을 누를 경우 Setting 창을 활성화시킴
    public void Setting()
    {
        SettingWindow.SetActive(true);
    }

    // 게임 종료 함수
    public void ExitGame()
    {
        Application.Quit();
    }


    // public void ExitSetting()
    // {
    //     if (SettingWindow.activeSelf == true)
    //     {
    //         SettingWindow.SetActive(false);
    //     }
    // }


}