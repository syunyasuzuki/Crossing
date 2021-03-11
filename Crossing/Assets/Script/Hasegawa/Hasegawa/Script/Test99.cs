using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test99 : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    bool ready = false;

    bool clic = false;

    int count = 0;
    int []clicnum = new int[10];

    float time = 0;

    // Update is called once per frame
    void Update()
    {
        if (!clic)
        {
            if (!ready)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ready = true;
                    time = 3;
                }
            }
            else
            {
                time = Mathf.Clamp(time - Time.deltaTime, 0, 3);
                if (time <= 0)
                {
                    clic = true;
                    ready = false;
                }
            }
        }
        else
        {
            time = Mathf.Clamp(time + Time.deltaTime, 0, 10);
            if (time < 10 && Input.GetMouseButtonDown(0))
            {
                ++clicnum[count];
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            clic = ready = false;
            if (++count >= 10)
            {
                count = 0;
            }
            clicnum[count] = 0;
        }
    }

    private void OnGUI()
    {
        float x = Screen.width / 1280;
        float y = Screen.height / 720;
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(x, y, 1));

        GUI.skin.label.normal.textColor = !ready ? Color.red : Color.blue;
        GUI.skin.label.fontSize = 40;

        GUI.Label(new Rect(600, 300, 200, 100), time.ToString());

        GUI.skin.label.fontSize = 20;
        for(int i = 0; i < 10; ++i)
        {
            GUI.Label(new Rect(400, 400 + 20*i, 50, 30), clicnum[i].ToString());
        }
    }
}
