using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonCon : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;

    void Start()
    {
        MenuPanel.SetActive(false);
        Button button = GameObject.Find("Canvas/Panel/menu/SELECT").GetComponent<Button>();
        button.Select();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            MenuPanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void select()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SelectScene");
    }

    public void title()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("TitleScene");
    }

    public void Back()
    {
        MenuPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
