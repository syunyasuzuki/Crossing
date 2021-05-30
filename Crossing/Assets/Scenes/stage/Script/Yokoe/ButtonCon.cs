using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCon : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;

    void Start()
    {
        MenuPanel.SetActive(false);
    }

    void Update()
    {
        //// 現在のScene名を取得する
        //Scene loadScene = SceneManager.GetActiveScene();
        //// Sceneの読み直し
        //SceneManager.LoadScene(loadScene.name);

        if(Input.GetKey(KeyCode.Escape))
        {
            MenuPanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void select()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void title()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void Back()
    {
        MenuPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
