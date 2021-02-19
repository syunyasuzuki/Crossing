using UnityEngine;

public class Mobius_con : MonoBehaviour
{
    /// <summary>
    /// ねじれる位置の最高数
    /// </summary>
    const int MAX_CROSSPOINT = 12;

    /// <summary>
    /// テンポ
    /// </summary>
    enum Tenpo
    {
        Two = 2,
        Three = 3,
        Four = 4,
    }

    /// <summary>
    /// 現在のテンポ
    /// </summary>
    [SerializeField] Tenpo m_tempo = Tenpo.Four;

    /// <summary>
    /// 現在の輪のねじれの数
    /// </summary>
    private int cross_num;

    /// <summary>
    /// 輪の状態
    /// </summary>
    enum Strip_mode
    {
        Normal = 0,
        Move = 1,
        JumpMove = 2,
        Turn = 3,
        Wormhole,
        Attack,
    }

    /// <summary>
    /// 現在の輪の状態
    /// </summary>
    private Strip_mode[] m_strip_mode;

    /// <summary>
    /// 輪の作成する
    /// </summary>
    private void Create_Strip()
    {
        cross_num = MAX_CROSSPOINT / (int)m_tempo;
        m_strip_mode = new Strip_mode[cross_num];
        for(int ms = 0; ms < m_strip_mode.Length; ++ms)
        {
            m_strip_mode[ms] = Strip_mode.Normal;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
