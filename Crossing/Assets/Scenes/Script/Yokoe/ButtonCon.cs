using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCon : MonoBehaviour
{
    public void next()
    {
        // 現在のScene名を取得
        Scene now_Scene = SceneManager.GetActiveScene();
        // 現在のSceneをもう一度ロード
        SceneManager.LoadScene(now_Scene.name);
    }

    public void select()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void title()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
