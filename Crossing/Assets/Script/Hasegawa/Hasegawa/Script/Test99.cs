using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test99 : MonoBehaviour
{

    private GameObject cube;

    [SerializeField] GameObject pre = null;

    // Start is called before the first frame update
    void Start()
    {

        cube = Instantiate(pre);
        
    }

    private int mm = 0;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (--mm < 0) mm = 3;
            cube.transform.localRotation = Quaternion.Euler(0, 0, mm * 90);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (++mm > 3) mm = 0;
            cube.transform.localRotation = Quaternion.Euler(0, 0, mm * 90);
        }




    }
}
