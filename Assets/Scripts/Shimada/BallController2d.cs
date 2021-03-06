using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController2d : MonoBehaviour
{
    [SerializeField] float m_pushPower = 1f;
    [SerializeField] GameObject m_selectBall = null;
    [SerializeField] AudioClip m_selectClip = null;
    [SerializeField] AudioClip m_unSelectClip = null;
    GameObject m_gm;
    Rigidbody2D m_rb;
    SpriteRenderer m_sr;
    AudioSource m_audio;
    public bool m_isSelect { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        m_sr = GetComponent<SpriteRenderer>();
        m_audio = GetComponent<AudioSource>();

        float random = Random.Range(-1f, 1f);
        m_rb = GetComponent<Rigidbody2D>();
        m_rb.AddForce(new Vector2(random, 0) * m_pushPower, ForceMode2D.Impulse);

        Vector2 pos = transform.position;
        Quaternion rotat = transform.rotation;
        m_gm = Instantiate(m_selectBall, pos, rotat, transform);
        m_gm.SetActive(false);
    }

    /// <summary>ボールを選択状態にする</summary>
    public void SelectBall()
    {
        m_isSelect = true;
        m_gm.SetActive(true);
        m_audio.PlayOneShot(m_selectClip);
    }

    /// <summary>ボールを選択状態から解除する</summary>
    public void UnSelectBall()
    {
        m_isSelect = false;
        m_gm.SetActive(false);
        m_audio.PlayOneShot(m_unSelectClip);
    }
}
