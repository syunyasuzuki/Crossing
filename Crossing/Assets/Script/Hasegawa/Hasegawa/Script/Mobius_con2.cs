using UnityEngine;

public class Mobius_con2 : MonoBehaviour
{
    /// <summary>
    /// 輪のデータを取得
    /// </summary>
    Mobius_data m_data = null;

    /// <summary>
    /// 生成するUIオブジェクト中
    /// </summary>
    [SerializeField] GameObject UIobject_middle = null;

    /// <summary>
    /// 差し替え用のスプライト
    /// </summary>
    [SerializeField] Sprite[] UIspritemiddle = new Sprite[2];

    /// <summary>
    /// 生成するUIオブジェクト端
    /// </summary>
    [SerializeField] GameObject UIobject_side = null;

    /// <summary>
    /// 生成するUI上を移動するオブジェクト
    /// </summary>
    [SerializeField] GameObject UIobject_wisp = null;

    /// <summary>
    /// 生成するUIのボタン
    /// </summary>
    [SerializeField] GameObject[] UIbutton = new GameObject[3];

    /// <summary>
    /// UIをまとめる親オブジェクト
    /// </summary>
    private GameObject ellipsemother = null;

    /// <summary>
    /// 生成したUI
    /// </summary>
    private GameObject[] m_ellipse = null;

    /// <summary>
    /// UIのSpriteRenderer
    /// </summary>
    private SpriteRenderer[] m_spren = null;

    /// <summary>
    /// 生成したUI上を移動するオブジェクト
    /// </summary>
    private GameObject m_wisp = null;

    /// <summary>
    /// 生成したUIのボタン
    /// </summary>
    private GameObject[] m_uibutton = null;

    /// <summary>
    /// プレイヤーの操作
    /// </summary>
    private Player_con player = null;

    /// <summary>
    /// 輪を作成する
    /// </summary>
    private void Create_Ellipse()
    {
        //データにアクセス
        m_data = GetComponent<Mobius_data>();

        //配列を確保
        m_ellipse = new GameObject[(int)m_data.tempo * 2];
        m_spren = new SpriteRenderer[(int)m_data.tempo * 2];
        m_uibutton = new GameObject[3];

        //UIを生成
        ellipsemother = new GameObject("Ellipsemother");
        for(int s = 1; s < (int)m_data.tempo * 2 - 1; ++s)
        {
            m_ellipse[s] = Instantiate(UIobject_middle);
            m_ellipse[s].transform.position = new Vector3(-m_data.UIscalex / 2 - m_data.Position.x + m_data.Pixcellforunitysize_x / 2 + (m_data.Pixcellforunitysize_x * s), m_data.Position.y, 0);
            if (s % 2 == 1)
            {
                m_ellipse[s].transform.localScale = new Vector3(-1, 1, 1);
            }
            m_ellipse[s].transform.parent = ellipsemother.transform;
            m_spren[s] = m_ellipse[s].GetComponent<SpriteRenderer>();
        }
        m_ellipse[0] = Instantiate(UIobject_side);
        m_ellipse[0].transform.position = new Vector3(-m_data.UIscalex / 2 - m_data.Position.x + m_data.Pixcellforunitysize_x / 2, m_data.Position.y, 0);
        m_ellipse[0].transform.parent = ellipsemother.transform;
        m_ellipse[m_ellipse.Length - 1] = Instantiate(UIobject_side);
        m_ellipse[m_ellipse.Length - 1].transform.position = new Vector3(-m_data.UIscalex / 2 - m_data.Position.x + m_data.Pixcellforunitysize_x / 2 + (m_data.Pixcellforunitysize_x * ((int)m_data.tempo * 2 - 1)), m_data.Position.y, 0);
        m_ellipse[m_ellipse.Length - 1].transform.localScale = new Vector3(-1, 1, 1);
        m_ellipse[m_ellipse.Length - 1].transform.parent = ellipsemother.transform;

        //ボタンを生成
        for(int s = 0; s < (int)m_data.tempo - 1; ++s)
        {
            m_uibutton[s] = Instantiate(UIbutton[s]);
            m_uibutton[s].transform.position = new Vector3(-m_data.UIscalex / 2 - m_data.Position.x + m_data.Pixcellforunitysize_x * 2 * (s + 1), m_data.Position.y, 0);
        }

        //UI上を移動するオブジェクトを生成
        m_wisp = Instantiate(UIobject_wisp);
        m_wisp.transform.position = new Vector3(m_data.Position.x - m_data.UIscalex / 2, m_data.Position.y, 0);

        //プレイヤーを参照する
        player = GetComponent<Player_con>();
    }

    /// <summary>
    /// UI上のオブジェクトの回り方向
    /// 1 = 時計回り
    /// </summary>
    private int wispmovevec = 1;

    /// <summary>
    /// UI上のオブジェクトの処理
    /// </summary>
    private void Wisp_task()
    {
        //動かさない場合、wispがない場合は処理をはじく
        if (!m_data.IsMoveWisp || !m_wisp) return;

        //一周のうち何秒地点にいるか
        float a = m_data.Tok_time() % (m_data.Herftime * 2);
        //現在いる地点が半周を超えている場合半周での値に変換する
        float b = a;
        if(a > m_data.Herftime)
        {
            b = m_data.Herftime + (m_data.Herftime - a);
        }
        //x軸上で現在どこにいるかを求める
        float x = m_data.UIscalex / m_data.Herftime * b;
        //UIを細かく分けた際に現在どの地点にいるかを求める
        int c=Mathf.Clamp(Mathf.FloorToInt(x/(m_data.UIscalex/((int)m_data.tempo*2))),0,(int)m_data.tempo*2-1);

        //UI上のオブジェクトが上弦にいるか下弦にいるか求める
        int n;
        if (a <= m_data.Herftime)
        {
            if(wispmovevec == 1)
            {
                n = 1;
            }
            else
            {
                n = -1;
            }
        }
        else
        {
            if (wispmovevec == 1)
            {
                n = -1;
            }
            else
            {
                n = 1;
            }
        }
        
        //現在いる地点の状態によってUI上のオブジェクトの位置を移動させる
        switch (m_data.ellipsemodes[c])
        {
            case Mobius_data.EllipseMode.Normal:
                m_wisp.transform.position = new Vector3(-m_data.UIscalex / 2 + x, m_data.Position.y + 0.8f * n, 0);
                break;
            case Mobius_data.EllipseMode.Cross:
                float y = Mathf.Clamp(Mathf.Sqrt((1 - Mathf.Pow(-m_data.Pixcellforunitysize_x + (m_data.Pixcellforunitysize_x * 2 / (m_data.Herftime / (int)m_data.tempo)) * (b - m_data.Herftime / (int)m_data.tempo * (c / 2)), 2) / Mathf.Pow(m_data.Pixcellforunitysize_x, 2)) * Mathf.Pow(m_data.Pixcellforunitysize_y, 2)),0,m_data.Pixcellforunitysize_y);
                m_wisp.transform.position = new Vector3(-m_data.UIscalex / 2 + x, m_data.Position.y + y * n, 0);
                break;
        }
    }

    /// <summary>
    /// 前回方向を変えた時間
    /// </summary>
    private float changepoint = 0;

    /// <summary>
    /// 加算する時間の倍率
    /// </summary>
    private float timescale = 1;

    /// <summary>
    /// 指定されたUIの状態を切り替える
    /// </summary>
    private void ChangeUI(int n)
    {
        if (m_data.ellipsemodes[n] == Mobius_data.EllipseMode.Normal)
        {
            m_spren[n].sprite = m_spren[n + 1].sprite = UIspritemiddle[1];
            m_data.ellipsemodes[n] = m_data.ellipsemodes[n + 1] = Mobius_data.EllipseMode.Cross;
        }
        else
        {
            m_spren[n].sprite = m_spren[n + 1].sprite = UIspritemiddle[0];
            m_data.ellipsemodes[n] = m_data.ellipsemodes[n + 1] = Mobius_data.EllipseMode.Normal;
        }
    }

    /// <summary>
    /// 輪の処理
    /// </summary>
    private void Ellipse_task()
    {
        //UIを操作しない場合は処理をはじく
        if (!m_data.IsMoveUI) return;

        //時間を加算
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            m_data.Movewisp = false;
            timescale = -1; 
        }
        if (Input.GetKey(KeyCode.Space)) 
        { 
            timescale -= 0.1f; 
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_data.Movewisp = true;
            timescale = 1;
        }
        m_data.Timecount(timescale);

        //ボタン操作
        if (m_data.Movewisp)
        {
            if (Input.GetMouseButtonDown(0)){
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider != null)
                {
                    switch (hit.collider.tag)
                    {
                        case "Move":

                            break;
                        case "Jump":

                            break;
                        case "Turn":

                            break;
                    }
                }
            }
        }
        else
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Create_Ellipse();
    }

    // Update is called once per frame
    void Update()
    {
        Ellipse_task();
        Wisp_task();
    }
}
