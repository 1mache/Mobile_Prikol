using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    bool[] boolArr;
    bool a = false;
    bool b = false; 

    void Start()
    {
        boolArr = new bool[] {a, b };
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            a = true;
        }
        if (Input.GetKey(KeyCode.B))
        {
            b = true;
        }

    }
}
