using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test99 : MonoBehaviour
{

    private GameObject cube = null;

    Mobius_data m_data = null;

    [SerializeField] GameObject pre = null;

    // Start is called before the first frame update
    void Start()
    {
        m_data = GetComponent<Mobius_data>();
        cube = Instantiate(pre);
    }

    // Update is called once per frame
    void Update()
    {

        m_data.Timecount(1);

        //一周のうち何秒地点にいるか
        float a = m_data.Tok_time() % (m_data.Herftime * 2);
        //現在いる地点が半周を超えている場合半周での値に変換する
        float b = a;
        if (a > m_data.Herftime)
        {
            b = m_data.Herftime + (m_data.Herftime - a);
        }

        float x = m_data.UIscalex / m_data.Herftime * b;

        int c = Mathf.Clamp(Mathf.FloorToInt(x / (m_data.UIscalex / ((int)m_data.tempo * 2))), 0, (int)m_data.tempo * 2 - 1);

        float y = Mathf.Clamp(Mathf.Sqrt((1 - Mathf.Pow(-m_data.Pixcellforunitysize_x + m_data.Pixcellforunitysize_x * 2 / (m_data.Herftime / (int)m_data.tempo) * (b - m_data.Herftime/(int)m_data.tempo * (c / 2)), 2) / Mathf.Pow(m_data.Pixcellforunitysize_x, 2)) * Mathf.Pow(m_data.Pixcellforunitysize_y, 2)), 0, m_data.Pixcellforunitysize_y) + m_data.Position.y;

        Debug.Log(b % m_data.Herftime / (int)m_data.tempo);

        cube.transform.position = new Vector3(- m_data.UIscalex / 2 + x, y, 0);
    }
}
