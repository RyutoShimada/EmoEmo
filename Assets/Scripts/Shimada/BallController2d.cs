using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController2d : MonoBehaviour
{
    [SerializeField] float m_pushPower = 1f;
    [SerializeField] GameObject m_selectBall = null;

    Rigidbody2D m_rb;
    public bool m_isSelect { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        float random = Random.Range(-1f, 1f);
        m_rb = GetComponent<Rigidbody2D>();
        m_rb.AddForce(new Vector2(random, 0) * m_pushPower, ForceMode2D.Impulse);
    }

    /// <summary>ボールを選択状態にする</summary>
    public void SelectBall()
    {
        m_isSelect = true;
        Vector2 pos = transform.position;
        Quaternion rotat = transform.rotation;
        Instantiate(m_selectBall, pos, rotat, transform);
    }

    /// <summary>ボールを選択状態から解除する</summary>
    public void UnSelectBall()
    {
        m_isSelect = false; 
        //Destroy(m_selectBall);
    }
}
