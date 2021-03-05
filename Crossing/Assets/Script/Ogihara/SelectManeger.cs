using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManeger : MonoBehaviour
{
    // Start is called before the first frame update
    public void OncClickStartSelsect()
    {
        SceneManager.LoadScene("SelectScene");
    }
    public void OnClickStart1()
    {
        SceneManager.LoadScene("1-1");               
    }
    public void OnClickStart2()
    {
        SceneManager.LoadScene("1-2");
    }
    public void OnClickStart3()
    {
        SceneManager.LoadScene("1-3");
    }
    public void OnClickStart4()
    {
        SceneManager.LoadScene("1-4");
    }
}
