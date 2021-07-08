using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    public static PlayerControlls singleton;

    Camera cam; 

    float dashSpeed = 100f;
    float dashRadius = 0.5f;
    float cameraWidth;
    float cameraHeight;

    Rigidbody2D rb;
    public Vector2 Position
    {
        get;
        private set;
    }
    Vector2 releasedTouchPos = Vector2.negativeInfinity;

    int frameCount = 0;
    public int maxDashFrameDelay = 3;

    private void Awake()
    {
        singleton = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        cameraHeight = Camera.main.orthographicSize * 2.0f;
        cameraWidth = cameraHeight * Camera.main.aspect;
    }
    void Update()
    {
        Position = transform.position;

        Touch[] touches = GetInput();
        

        PositionVerifier();
    }

    void FixedUpdate()
    {
        
    }

    Touch[] GetInput() //returns an array of touches on screen(2 max)
    {
        Touch[] touches = new Touch[0];
        if (Input.touchCount == 1)
        {
            touches = new Touch[1];
            touches[0] = Input.GetTouch(0);
        }
        if (Input.touchCount > 1)
        {
            touches = new Touch[2];
            for (int i = 0; i < 2; i++)
            {
                touches[i] = Input.GetTouch(i);
            }
        }
        return touches;
    }

    void Dash(Vector2 endPoint)
    {
        transform.position = endPoint;
    }

    private void PositionVerifier()
    {
        Vector2 minMaxX = CalcMaxMinPosition(Axis.X, cameraWidth);
        Vector2 minMaxY = CalcMaxMinPosition(Axis.Y, cameraHeight);
        float Xpos = Mathf.Clamp(transform.position.x, minMaxX.x, minMaxX.y);
        float Ypos = Mathf.Clamp(transform.position.y, minMaxY.x, minMaxY.y);
        transform.position = new Vector2(Xpos, Ypos);
    }

    //*************************CALCULATION*******************************
    Vector2 CalcMaxMinPosition(Axis axis, float lengthOnAxis) //lengthOnAxis represents a width or a heigh of the screen
    {
        if (axis == Axis.X)
        {
            return new Vector2(-(lengthOnAxis - transform.lossyScale.x) / 2, (lengthOnAxis - transform.lossyScale.x) / 2);
        }
        else
        {
            return new Vector2(-(lengthOnAxis - transform.lossyScale.y) / 2, (lengthOnAxis - transform.lossyScale.y) / 2);
        }
    }

    Vector2 CalcDashEnd(Vector2 position, Vector2 vector1dir, Vector2 vector2dir)
    {
        return position + CombineVectors(vector1dir - position, vector2dir - position);
    }
    Vector2 CombineVectors(Vector2 vectorA, Vector2 vectorB)
    {
        return (vectorA + vectorB);
    }

    Vector2 CalcTouchPos(Vector2 pixelPos)
    {
        return cam.ScreenToWorldPoint(pixelPos);
    }

}

