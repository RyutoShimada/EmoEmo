using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController2d : MonoBehaviour
{
    [SerializeField] float m_pushPower = 1f;
    [SerializeField] GameObject m_selectBall = null;

    Rigidbody2D m_rb;
    public bool m_isSelect = false;

    bool m_isSelectedBall = false;//縁取り用のボールが子オブジェクトとしてあるかどうか

    // Start is called before the first frame update
    void Start()
    {
        float random = Random.Range(-1f, 1f);
        m_rb = GetComponent<Rigidbody2D>();
        m_rb.AddForce(new Vector2(random, 0) * m_pushPower, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (m_isSelect)
        {
            m_isSelectedBall = true;
            Vector2 pos = transform.position;
            Quaternion rotat = transform.rotation;
            Instantiate(m_selectBall, pos, rotat, transform);
        }
        else
        {
            if (m_isSelectedBall)
            {
                Destroy(m_selectBall);
                m_isSelectedBall = false;
            }
        }
    }

    void OnLuminous()
    {

    }

    void UnKuminous()
    {

    }
}
