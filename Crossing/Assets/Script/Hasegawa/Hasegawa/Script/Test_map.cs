using UnityEngine;

public class Test_map : MonoBehaviour
{
    [SerializeField] int Mapsizex = 10;
    [SerializeField] int Mapsizey = 10;

    [SerializeField] Vector2 Ratio = new Vector2(1, 0.8f);

    [SerializeField] Vector3 BasisPoint = new Vector3(-7.2f, 4.5f, 0);

    [SerializeField] GameObject mapchip = null;

    [SerializeField] GameObject Goal = null;

    private GameObject mapmother = null;

    private int[,] map;

    private int[] player = new int[2];

    const float movemapy = 0;

    public int Tok_map(int x,int y)
    {
        if (x < 0 || x >= Mapsizex || y < 0 || y >= Mapsizey)
        {
            return -1;
        }

        return map[y, x];
    }

    public Vector3 Tok_pos(int x, int y)
    {
        return new Vector3(BasisPoint.x + x * Ratio.x, BasisPoint.y - y * Ratio.y + movemapy, 0);
    }

    public Vector3 Tok_pos()
    {
        return new Vector3(BasisPoint.x + Ratio.x * player[0], BasisPoint.y - Ratio.y * player[1] + movemapy, 0);
    }

    public void Tok_first(ref int x,ref int y)
    {
        x = player[0];
        y = player[1];
    }

    private void Awake()
    {
        map = new int[Mapsizey, Mapsizex];

        if (Ratio.x <= 0) Ratio = new Vector2(1, Ratio.y);
        if (Ratio.y <= 0) Ratio = new Vector2(Ratio.x, 1);

        mapmother = new GameObject("mapmother");
        for(int y = 0; y < Mapsizey; ++y)
        {
            for(int x = 0; x < Mapsizex; ++x)
            {
                if (map[y, x] == 1)
                {
                    player[0] = x;
                    player[1] = y;
                }

                GameObject chip = Instantiate(mapchip);
                chip.transform.position = new Vector3(BasisPoint.x + Ratio.x * x, BasisPoint.y - Ratio.y * y, 0);
                chip.transform.localScale = new Vector3(Ratio.x, Ratio.y, 1);
                chip.transform.parent = mapmother.transform;
            }
        }

        GameObject goal = Instantiate(Goal);
        goal.transform.position = new Vector3(BasisPoint.x + Ratio.x * 6, BasisPoint.y - Ratio.y * 6, 0);
        goal.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

}
