
using System.Collections.Generic;
using UnityEngine;

public class Arrow 
{
    GameObject GameObject { get; }
    public Color Color { get; set; }

    LineRenderer Line { get;}
    public Vector2 Position
    {
        get
        {
            return GameObject.transform.position;
        }
    }

    public bool Active
    {
        get
        {
            return GameObject.activeInHierarchy;
        }
    }

    public Touch LookingAtTouch
    {
        get;
        private set;
    }
    public Arrow(GameObject gameObject)
    {
        this.GameObject = gameObject;
        this.Color = Color.white;
        this.Line = this.GameObject.GetComponent<LineRenderer>();

        activeArrows++;
    }

    public void Disable()
    {
        GameObject.SetActive(false);
        activeArrows--;
    }

    public void SetPosition(Vector2 position) {
        GameObject.transform.position = position;
    }

    public void Show(Touch touch)
    {
        LookingAtTouch = touch; 
        Vector2 vector = Camera.main.ScreenToWorldPoint(touch.position);
        vector -= PlayerControlls.singleton.Position;

        float vectorAngle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        GameObject.transform.rotation = Quaternion.Euler(0,0,vectorAngle);

        GameObject.SetActive(true);
        activeArrows++;
    }

    //***************************STATIC************************************

    public static int activeArrows;
}
