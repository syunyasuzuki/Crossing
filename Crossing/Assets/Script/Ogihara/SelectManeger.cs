using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectManeger : MonoBehaviour
{
    Button button;
     public static int stage = 0;
    public static int worldMap = 0;
     GameObject GameDI;

    void Start()
    {
        button = GameObject.Find("Canvas/ButtonMain/Button").GetComponent<Button>();
        button.Select();
        GameDI = GameObject.Find("GameDirecter");
        
    }

        // Start is called before the first frame update
        public void NextSelsect()
        {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadSelect), 1.0f);        
        }
    void LoadSelect()
    {
        SceneManager.LoadScene("SelectScene");
    }
    public  void OnClickStart1_1()
    {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadStage1_1), 1.0f);       
    }
   public static void LoadStage1_1()
    {
        //SceneManager.LoadScene("1-1");   
        worldMap = 1;
        stage = 0;        
    }
    public void OnClickStart1_2()
    {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadStage1_2), 1.0f);
    }
    void LoadStage1_2()
    {
        //SceneManager.LoadScene("1-2");
        worldMap = 1;
        stage = 1;
       
    }
    public void OnClickStart1_3()
    {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadStage1_3), 1.0f);
    }
    void LoadStage1_3()
    {
        //SceneManager.LoadScene("1-3");
        worldMap= 1;
        stage = 2;
    }

    public void OnClickStart1_4()
    {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadStage1_4), 1.0f);
    }
    void LoadStage1_4()
    {
        //SceneManager.LoadScene("1-4");
        worldMap = 1;
        stage = 3;
    }
    public void OnClickStart2_1()
    {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadStage2_1), 1.0f);
    }
    void LoadStage2_1()
    {
        //SceneManager.LoadScene("2-1");
        worldMap = 2;
        stage = 4;
    }
    public void OnClickStart2_2()
    {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadStage2_2), 1.0f);
    }
    void LoadStage2_2()
    {
        //SceneManager.LoadScene("2-2");
        worldMap = 2;
        stage = 5;
    }
    public void OnClickStart2_3()
    {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadStage2_3), 1.0f);
    }
    void LoadStage2_3()
    {
        //SceneManager.LoadScene("2-3");
        worldMap = 2;
        stage = 6;
    }
    public void OnClickStart2_4()
    {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadStage2_4), 1.0f);
    }
    void LoadStage2_4()
    {
        //SceneManager.LoadScene("2-4");
        worldMap = 2;
        stage = 7;
    }
     public void OnClickStart3_1()
    {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadStage3_1), 1.0f);
    }
    void LoadStage3_1()
    {
        //SceneManager.LoadScene("3-1");
        worldMap = 3;
        stage = 8;
    }
     public void OnClickStart3_2()
    {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadStage3_2), 1.0f);
    }
    void LoadStage3_2()
    {
        //SceneManager.LoadScene("3-2");
        worldMap = 3;
        stage = 9;
    }
    public void OnClickStart3_3()
    {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadStage3_3), 1.0f);
    }
    void LoadStage3_3()
    {
        //SceneManager.LoadScene("3-3");
        worldMap = 3;
        stage = 10;
    }
    public void OnClickStart3_4()
    {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadStage3_4), 1.0f);
    }
    void LoadStage3_4()
    {
        //SceneManager.LoadScene("3-4");
        worldMap = 3;
        stage = 11;
    }
    public void NextSelect2()
    {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadSelect2), 1.0f);
    }
    void LoadSelect2()
    {
        SceneManager.LoadScene("SelectScene2");
    }
    public void NextSelect3()
    {
        FadeManeger.Fade_flag_in = true;
        Invoke(nameof(LoadSelect3), 1.0f);
    }
    void LoadSelect3()
    {
        SceneManager.LoadScene("SelectScene3");
    }

    void Update()
    {

    }
}

