using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapcon : MonoBehaviour
{

    /// <summary>
    /// ワールドの数
    /// </summary>
    const int World_num = 1;

    /// <summary>
    /// １つのワールドのステージ数
    /// </summary>
    const int Stage_num = 10;


    /// <summary>
    /// ファイルのパス
    /// </summary>
    string[] FilePath = null;

    /// <summary>
    /// ファイルのパスを指定
    /// </summary>
    void Set_path()
    {
        FilePath = new string[World_num] { "mapdata" };
    }


    /// <summary>
    /// マップサイズ x
    /// </summary>
    const int Mapsize_x = 20;

    /// <summary>
    /// マップサイズ y
    /// </summary>
    const int Mapsize_y = 10;

    /// <summary>
    /// マップの大きさを返す
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void Read_mapsize(ref int x,ref int y)
    {
        x = Mapsize_x;
        y = Mapsize_y;
    }

    /// <summary>
    /// 全てのマップデータ
    /// </summary>
    int[,,,] map = new int[World_num, Stage_num, Mapsize_y, Mapsize_x];

    /// <summary>
    /// 一括で全ステージを読み込む
    /// </summary>
    void Read_all_maps()
    {
        for (int w = 0; w < World_num; ++w)
        {
            string text_data = (Resources.Load(FilePath[w], typeof(TextAsset)) as TextAsset).text;
            string[] text_line = text_data.Split('\n');
            for (int s = 0; s < Stage_num; ++s)
            {
                for (int y = 0; y < Mapsize_y; ++y)
                {
                    string[] strsplr = text_line[Mapsize_y * s + y + 1].Split(',');
                    for (int x = 0; x < Mapsize_x; ++x)
                    {
                        map[w, s, y, x] = int.Parse(strsplr[x]);
                    }
                }
            }
        }
    }

    //GameMaster取得
    GameObject GM;

    //素材
    /// <summary>
    /// ノーマルブロック
    /// </summary>
    [SerializeField] Sprite[] Normal_block = new Sprite[2];
    /// <summary>
    /// 各マップチップの素材
    /// </summary>
    [SerializeField] Sprite[] RGB_Blocks = new Sprite[3];
    /// <summary>
    /// 各プレハブ
    /// </summary>
    [SerializeField] GameObject[] Map_pre = new GameObject[2];
    /// <summary>
    /// マップチップを入れる親オブジェクト
    /// </summary>
    GameObject Map_mother = null;
    /// <summary>
    /// 1回でもマップを生成したか
    /// </summary>
    bool create_map = false;
    ///// <summary>
    ///// 現在使っているワールド番号
    ///// </summary>
    //int now_world = 0;
    ///// <summary>
    ///// 現在使っているステージ番号
    ///// </summary>
    //int now_stage = 0;
    /// <summary>
    /// 現在使っているマップ
    /// </summary>
    int[,] now_map = new int[Mapsize_y, Mapsize_x];
    /// <summary>
    /// 現在使っているマップの指定されたマップ情報を返す
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public int Read_mapchip(int x,int y)
    {
        if (x < 0 || x > Mapsize_x || y < 0 || y > Mapsize_y)
        {
            return 1;
        }
        return now_map[y, x];
    }

    List<GameObject> red_blocks = new List<GameObject>();
    List<GameObject> green_blocks = new List<GameObject>();
    List<GameObject> blue_blocks = new List<GameObject>();



    /// <summary>
    /// 指定されたチップを生成
    /// </summary>
    /// <param name="x"> マップサイズ x</param>
    /// <param name="y"> マップサイズ y</param>
    /// <param name="n">生成するオブジェクトの番号</param>
    public void Create_chip(int x, int y, int n)
    {
        switch (n)
        {
            case 0:
                break;
            case 1:
                GameObject wh_bl = new GameObject("wh_bl" + x + "-" + y);
                wh_bl.AddComponent<SpriteRenderer>().sprite = Normal_block[0];
                wh_bl.AddComponent<BoxCollider2D>();
                wh_bl.transform.position = new Vector3(x, -y, 0.0f);
                wh_bl.transform.parent = Map_mother.transform;
                break;
            case 2:
                GameObject bk_bl = new GameObject("bk_bl" + x + "_" + y);
                bk_bl.AddComponent<SpriteRenderer>().sprite = Normal_block[1];
                bk_bl.AddComponent<BoxCollider2D>();
                bk_bl.transform.position = new Vector3(x, -y, 0.0f);
                bk_bl.transform.parent = Map_mother.transform;
                break;
            case 3:
                GameObject red_bl = new GameObject("red_bl" + x + "-" + y);
                red_bl.AddComponent<SpriteRenderer>().sprite = RGB_Blocks[0];
                red_bl.AddComponent<BoxCollider2D>();
                red_bl.transform.position = new Vector3(x, -y, 0.0f);
                red_bl.transform.parent = Map_mother.transform;
                red_blocks.Add(red_bl);

                break;
            case 4:
                GameObject gre_bl = new GameObject("gre_bl" + x + "_" + y);
                gre_bl.AddComponent<SpriteRenderer>().sprite = RGB_Blocks[1];
                gre_bl.AddComponent<BoxCollider2D>();
                gre_bl.transform.position = new Vector3(x, -y, 0.0f);
                gre_bl.transform.parent = Map_mother.transform;
                green_blocks.Add(gre_bl);
                break;
            case 5:
                GameObject blue_bl = new GameObject("blue_bl" + x + "_" + y);
                blue_bl.AddComponent<SpriteRenderer>().sprite = RGB_Blocks[2];
                blue_bl.AddComponent<BoxCollider2D>();
                blue_bl.transform.position = new Vector3(x, -y, 0.0f);
                blue_bl.transform.parent = Map_mother.transform;
                blue_blocks.Add(blue_bl);
                break;
            case 6:
                GameObject goal = Instantiate(Map_pre[0]);
                goal.transform.position = new Vector3(x, -y, 0.0f);
                goal.transform.parent = Map_mother.transform;
                break;
            case 7:
                GameObject player = Instantiate(Map_pre[1]);
                player.transform.position = new Vector3(x, -y, 0.0f);
                player.transform.parent = Map_mother.transform;
                break;

        }

    }

    /// <summary>
    /// 指定されたマップを生成
    /// </summary>
    /// <param name="w">生成されるワールド</param>
    /// <param name="s">生成されるステージ</param>
    public void Create_map(int w,int s)
    {
        Map_mother = new GameObject("map_mother");
        for (int lu = 0; lu < Mapsize_y; ++lu)
        {
            for (int na = 0; na < Mapsize_x; ++na)
            {
                Create_chip(na, lu, now_map[lu, na] = map[w, s, lu, na]);
                
            }
        }
        create_map = true;
    }

    /// <summary>
    /// 現在使っているマップを消す
    /// </summary>
    public void Delete_map()
    {
        GameObject map_mother = GameObject.Find("map_mother");
        Destroy(map_mother.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Set_path();
        Read_all_maps();
        Create_map(0,0);
        GameObject.Find("GameMaster").GetComponent<Mobius_con3>().SetColorBlockData(red_blocks, green_blocks, blue_blocks);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
