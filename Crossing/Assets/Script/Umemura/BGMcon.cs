using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMcon : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            audio.pitch = -3.0f;
        }
        else
        {
            audio.pitch = 1.0f;
        }
        
    }
}
