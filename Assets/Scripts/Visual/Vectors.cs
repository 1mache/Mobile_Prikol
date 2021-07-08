using System.Collections.Generic;
using UnityEngine;

public class Vectors : MonoBehaviour
{

    public GameObject gameObject1;
    public GameObject gameObject2;

    private Arrow arrow1;
    private Arrow arrow2;
    private Arrow[] arrows;

    private Color redColor;
    private Color blueColor;

    private TouchInput touchInput;

    void Start()
    {
        redColor = new Color(255, 126, 126);
        blueColor = new Color(126, 126, 255);

        arrow1 = new Arrow(gameObject1);
        arrow2 = new Arrow(gameObject2);

        arrows = new Arrow[] { arrow1, arrow2 };

        touchInput = TouchInput.singleton;
    }

    void Update()
    {
        int touchCount = Input.touchCount;
        for (int i = 0; i < 2; i++)
        {
            if (arrows[i].Active)
            {
                if (arrows[i].LookingAtTouch.phase == TouchPhase.Ended)
                {
                    arrows[i].Disable();
                }
            }
        }


    }

    void PointArrow(Arrow arrow,Vector2 arrowPosition,Touch touch, Color color)
    {
        arrow.SetPosition(arrowPosition);
        arrow.Show(touch);
        arrow.Color = color;
        
    }
}
