using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public static int s_breakableCount = 0;
    public Sprite[] m_hitSprites;
    public AudioClip m_crack;
    public GameObject m_smoke;

    private int m_timesHit;
    private LevelManager m_levelManager;
    private bool m_isBreakable;

    // Use this for initialization
    void Start () {
        m_timesHit = 0;
        m_isBreakable = (tag == "Breakable");
        // Keep track of breakable bricks.
        if (m_isBreakable)
        {
            ++s_breakableCount;
        }
        m_levelManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
        AudioSource.PlayClipAtPoint(m_crack, transform.position);
        if (m_isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        int maxHits = m_hitSprites.Length + 1;
        if (++m_timesHit >= maxHits)
        {
            --s_breakableCount;
            m_levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void PuffSmoke()
    {
        Color brickColor = GetComponent<SpriteRenderer>().color;
        GameObject puff = Instantiate(m_smoke, transform.position, Quaternion.identity);
        ParticleSystem.MainModule puffMain = puff.GetComponent<ParticleSystem>().main;
        puffMain.startColor = new Color(brickColor.r, brickColor.g, brickColor.b);
        puff.GetComponent<ParticleSystem>().Play();
    }

    void LoadSprites()
    {
        int spriteIndex = m_timesHit - 1;
        // make sure that there's a sprite to load so we don't get an invisible brick.
        if (m_hitSprites[spriteIndex])
        {
            GetComponent<SpriteRenderer>().sprite = m_hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("No sprite at m_hitSprites[" + spriteIndex + "]");
        }
    }

    // TODO Remove this method once we can actually win.
    void SimulateWin()
    {
        m_levelManager.LoadNextLevel();
    }
}
