using System;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public static TouchInput singleton;
    public List<Touch> TouchList {get; private set;}

    public event Action<Touch> OnNewTouch;

    private void Awake()
    {
        singleton = this;
    }
    void Start()
    {
        TouchList = new List<Touch>();
    }

    void Update()
    {
        TouchList.Clear();
        foreach (Touch touch in Input.touches)
        {
            if (TouchList.Count < 3)
            {
                TouchList.Add(touch);
            }
        }
    }
}
