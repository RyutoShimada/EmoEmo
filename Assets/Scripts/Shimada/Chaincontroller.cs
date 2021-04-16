using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Chaincontroller : MonoBehaviour
{
    /// <summary>Rayを発射する位置</summary>
    Vector3 m_rayOrigin;
    /// <summary>Rayが当たったオブジェクトの情報が格納される</summary>
    RaycastHit2D m_hit;
    /// <summary>チェーン状態のボールが入る</summary>
    List<GameObject> m_ballList;

    // Start is called before the first frame update
    void Start()
    {
        m_ballList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m_hit = Physics2D.Raycast(m_rayOrigin, Vector3.forward, 100f);
        GetMouseButton();
        Debug.Log(m_ballList.Count);
    }

    void GetMouseButton()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (m_hit && m_hit.collider.tag == "Ball")
        //    {
        //        if (m_ballList.Count == 0)
        //        {
        //            m_ballList.Add(m_hit.collider.gameObject);
        //        }
        //        else
        //        {
        //            //最後に追加したボールと現在選択しているボールが異なるオブジェクトならリストに追加する
        //            if (m_hit.collider.gameObject != m_ballList.Last().gameObject)
        //            {
        //                m_ballList.Add(m_hit.collider.gameObject);
        //            }
        //        }

        //        foreach (var item in m_ballList)
        //        {
        //            item.gameObject.GetComponent<BallController2d>().SelectBall();
        //        }
        //    }
        //}

        if (Input.GetMouseButton(0))
        {
            if (m_hit && m_hit.collider.tag == "Ball")
            {
                if (m_ballList.Count == 0)
                {
                    m_ballList.Add(m_hit.collider.gameObject);
                }
                else
                {
                    //最後に追加したボールと現在選択しているボールが異なるオブジェクトならリストに追加する
                    if (m_hit.collider.gameObject != m_ballList.Last().gameObject)
                    {
                        m_ballList.Add(m_hit.collider.gameObject);
                    }
                }

                foreach (var item in m_ballList)
                {
                    item.gameObject.GetComponent<BallController2d>().SelectBall();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (m_ballList.Count >= 3)
            {
                foreach (var item in m_ballList)
                {
                    item.gameObject.GetComponent<BallController2d>().UnSelectBall();
                    Destroy(item, 0.1f);
                }
            }

            m_ballList.Clear();
        }
    }
}
