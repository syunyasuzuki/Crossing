using UnityEngine;

public class Player_con : MonoBehaviour
{
    /// <summary>
    /// 参照するマップ情報
    /// </summary>
    private Test_map map = null;

    /// <summary>
    /// 生成するプレイヤー
    /// </summary>
    [SerializeField] GameObject Player_prefab = null;

    private GameObject Player = null;

    /// <summary>
    /// 位置をint型で保存
    /// </summary>
    struct Position
    {
        public int x;
        public int y;
    }

    /// <summary>
    /// プレイヤーの現在の位置
    /// </summary>
    private Position playerposition = new Position { x = 0, y = 0 };

    /// <summary>
    /// マップから情報をもらってプレイヤーを生成する
    /// </summary>
    void CreatePlayer()
    {
        map = GetComponent<Test_map>();
        map.Tok_first(ref playerposition.x, ref playerposition.y);
        Player = Instantiate(Player_prefab);
        Player.GetComponent<SpriteRenderer>().color = Color.yellow;
        Player.transform.position = map.Tok_pos();
    }

    /// <summary>
    /// 各方向に動く
    /// </summary>
    public void Move(int x,int y)
    {
        if (map.Tok_map(playerposition.x + x, playerposition.y + y) != -1)
        {
            playerposition.x += x;
            playerposition.y += y;
            Player.transform.position = map.Tok_pos(playerposition.x, playerposition.y);
        }
    }

    /// <summary>
    /// 各方向に一つ飛ばしで動く
    /// </summary>
    public void JumpMove(int x,int y)
    {
        if (map.Tok_map(playerposition.x + x, playerposition.y + y) != -1)
        {
            playerposition.x += x;
            playerposition.y += y;
            Player.transform.position = map.Tok_pos(playerposition.x, playerposition.y);
        }
    }

    /// <summary>
    /// 方向転換する
    /// </summary>
    public void Turn(int x)
    {
        Player.transform.localRotation = Quaternion.Euler(0, 0, 90 * x);
    }

    /// <summary>
    /// ある位置に移動する
    /// </summary>
    public void Warmhole()
    {

    }

    /// <summary>
    /// 攻撃？
    /// </summary>
    public void Attack()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }
}
