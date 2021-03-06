using UnityEngine;

public class Mobius_data :MonoBehaviour
{

    /// <summary>
    /// テンポ
    /// </summary>
    public enum Tenpo
    {
        Two = 2,
        Three = 3,
        Four = 4,
    }

    /// <summary>
    /// 現在のテンポ
    /// </summary>
    public Tenpo tempo = Tenpo.Four;

    /// <summary>
    /// ステージの時間
    /// </summary>
    public float StageTime = 90;

    /// <summary>
    /// 現在の時間
    /// </summary>
    private float time = 0;

    /// <summary>
    /// 時間を変化させるか
    /// </summary>
    public bool IsTimeCount = true;

    /// <summary>
    /// 現在の時間を知る
    /// </summary>
    /// <returns></returns>
    public float Tok_time()
    {
        return time;
    }

    /// <summary>
    /// 時間を加算する
    /// </summary>
    /// <param name="n">加算する倍率</param>
    public void Timecount(float n)
    {
        time = Mathf.Clamp(time + Time.deltaTime * n, 0, StageTime);
    }
    
    /// <summary>
    /// UIの位置
    /// </summary>
    public Vector3 Position { get; set; } = Vector3.zero;

    /// <summary>
    /// 半周の移動時間
    /// </summary>
    public float Herftime = 3.0f;

    /// <summary>
    /// UI上のオブジェクトを動かすか
    /// </summary>
    public bool IsMoveWisp = true;

    /// <summary>
    /// 逆再生をしているか
    /// </summary>
    public bool Movewisp { get; set; } = true;

    /// <summary>
    /// UIを動かすか
    /// </summary>
    public bool IsMoveUI = true;

    /// <summary>
    /// UIの横の大きさ
    /// </summary>
    public float UIscalex { get; set; } = 0f;

    /// <summary>
    /// 楕円の状態
    /// </summary>
    public enum EllipseMode
    {
        Normal = 0,
        Cross = 1
    }

    /// <summary>
    /// 現在の楕円の状態
    /// </summary>
    public EllipseMode[] ellipsemodes { get; set; } = null;

    /// <summary>
    /// UIを操作した回数
    /// </summary>
    private int changecount { get; set; } = 0;

    /// <summary>
    /// UIを操作した記録
    /// </summary>
    private float[] buttonclic { get; set; } = null;

    /// <summary>
    /// UIを操作した時間を記録する
    /// </summary>
    public void ChangeCount()
    {
        buttonclic[changecount] = Tok_time();
        ++changecount;
    }

    /// <summary>
    /// 直前のUIを操作した時間を知る
    /// 直前の時間がない場合-1を返す
    /// </summary>
    public float Tok_clic()
    {
        if (changecount - 1 < 0)
        {
            return -1;
        }
        else
        {
            return buttonclic[changecount - 1];
        }
    }

    /// <summary>
    /// 直前のUI操作記録がある場合に直前の操作記録を削除する
    /// </summary>
    public void Delete_ClicRecord()
    {
        if (changecount > 0)
        {
            buttonclic[changecount - 1] = 0;
            --changecount;
        }
    }

    /// <summary>
    /// 交点を通った回数
    /// </summary>
    public int movecount { get; set; } = 0;

    /// <summary>
    /// UIが交点を通った記録
    /// </summary>
    private float[] moveaction { get; set; } = null;

    /// <summary>
    /// プレイヤーが移動できたかの記録
    /// </summary>
    private int[] playermovelist { get; set; } = null;

    /// <summary>
    /// 交点を通った時間を記録する
    /// </summary>
    public void MoveCount(int m)
    {
        moveaction[movecount] = Tok_time();
        playermovelist[movecount] = m;
        ++movecount;
    }

    /// <summary>
    /// 直前のUIが交点を通った時間を知る
    /// 直前の情報がない場合-1を返す
    /// </summary>
    /// <returns></returns>
    public float Tok_action()
    {
        if (movecount - 1 < 0)
        {
            return -1;
        }
        else
        {
            return moveaction[movecount - 1];
        }
    }

    /// <summary>
    /// 直前のUIが交点を通りアクションが起こった時にアクションが実行されたかを知る
    /// アクションが実行された場合1を返す
    /// 直前の情報がない場合-2を返す
    /// アクションが実行されなかった場合-1を返す
    /// </summary>
    public int Tok_playermove()
    {
        if (movecount - 1 < 0)
        {
            return -2;
        }
        else
        {
            return playermovelist[movecount - 1];
        }
    }

    /// <summary>
    /// 直前の情報がある場合に直前の情報を削除する
    /// </summary>
    public void Delete_ActionRecord()
    {
        if(movecount > 0)
        {
            moveaction[movecount - 1] = 0;
            playermovelist[movecount - 1] = 0;
            --movecount;
        }
    }

    /// <summary>
    /// UIの縦の大きさをUnityに合わせたもの
    /// </summary>
    public float Pixcellforunitysize_y { get; } = 1f / 50f * 39;

    /// <summary>
    /// UIの横の大きさをUnityに合わせたもの
    /// </summary>
    public float Pixcellforunitysize_x { get; } = 1f / 50f * 60;

    void Awake()
    {
        //半周にかかる時間が1秒未満だったら1秒にする
        if (Herftime < 1) Herftime = 1;

        //ステージの時間が半周にかかる時間より短い場合1周の時間にする
        if (StageTime < Herftime) StageTime = Herftime * 2;

        //UIを生成する位置を確定
        Position = transform.position;

        //UIの横の大きさを確定
        UIscalex = Pixcellforunitysize_x * (int)tempo * 2;

        //配列の確保
        ellipsemodes = new EllipseMode[(int)tempo * 2];

        //UIの状態を設定
        ellipsemodes[0] = ellipsemodes[ellipsemodes.Length - 1] = EllipseMode.Cross;
    }

}
