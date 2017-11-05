using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool m_autoPlay = false;
    public float m_centerMinX;
    public float m_centerMaxX;

    private Ball m_ball;

    void Start()
    {
        m_ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
	void Update ()
    {
        if (m_autoPlay)
        {
            AutoPlay();
        }
        else
        {
            MoveWithMouse();
        }    
	}

    void MoveWithMouse()
    {
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePosInBlocks, m_centerMinX, m_centerMaxX)
                                        , transform.position.y
                                        , transform.position.z);
        transform.position = paddlePos;
    }

    void AutoPlay()
    {
        Vector3 ballPos = m_ball.transform.position;
        Vector3 paddlePos = new Vector3(Mathf.Clamp(ballPos.x, m_centerMinX, m_centerMaxX)
                                        , transform.position.y
                                        , transform.position.z);
        transform.position = paddlePos;
    }
}
