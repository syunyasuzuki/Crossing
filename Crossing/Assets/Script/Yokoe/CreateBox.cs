using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBox : MonoBehaviour
{
    /// <summary>
    /// ワールド番号
    /// </summary>
    private int world = 0;
    /// <summary>
    /// ステージ番号
    /// </summary>
    private int stage = 0;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void deletegameobj()
    {
        Destroy(gameObject);
    }

    public void Set_num(int w,int s)
    {
        world = w;
        stage = s;
    }

    public void Get_num(ref int w, ref int s)
    {
        w = world;
        s = stage;
    }
}
