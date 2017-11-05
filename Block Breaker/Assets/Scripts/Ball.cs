using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle m_paddle;
    private bool m_hasStarted = false;
    private Vector3 m_paddleToBall;

	// Use this for initialization
	void Start () {
        m_paddle = FindObjectOfType<Paddle>();
        m_paddleToBall = transform.position - m_paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!m_hasStarted)
        {
            // Lock ball relative to paddle.
            transform.position = m_paddle.transform.position + m_paddleToBall;
            if (Input.GetMouseButtonDown(0))
            {
                m_hasStarted = true;
                print("Mouse 0 Clicked! Lauch Ball!");
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(0.2f - Random.Range(0f, 0.4f), 0.2f - Random.Range(0f, 0.4f));
        if (m_hasStarted)
        {
            if (collision.gameObject.tag != "Breakable")
            {
                GetComponent<AudioSource>().Play();
            }
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
