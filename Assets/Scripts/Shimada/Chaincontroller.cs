using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Chaincontroller : MonoBehaviour
{
    [SerializeField] float m_margin = 1f;
    [SerializeField] Text m_chainText = null;
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
        m_chainText.text = "CHAIN : " + m_ballList.Count.ToString();
    }

    void GetMouseButton()
    {
        if (Input.GetMouseButton(0))
        {
            if (m_hit && m_hit.collider.tag == "Ball")
            {
                if (m_ballList.Count == 0)//1個目のボール
                {
                    m_ballList.Add(m_hit.collider.gameObject);
                }
                else//2個目以上のボール
                {
                    GameObject hitObj = m_hit.collider.gameObject;
                    GameObject listFirstObj = m_ballList.First().gameObject;
                    GameObject listLastObj = m_ballList.Last().gameObject;
                    float distance = Vector2.Distance(hitObj.transform.position, listLastObj.transform.position);
                    float diameter = hitObj.GetComponent<Renderer>().bounds.size.x + m_margin;

                    //①最初のオブジェクトと選択しているオブジェクトが異なる
                    //②最後に追加したオブジェクトと選択しているオブジェクトが異なる
                    //③それらのオブジェクトが隣接している
                    //④そのオブジェクト同士の名前が同じ
                    //(⑤選択しているオブジェクトと最後から2番目のオブジェクトが異なる)
                    //ならリストに追加する

                    if (m_ballList.Count == 1)
                    {
                        if (hitObj != listFirstObj &&//①
                            hitObj != listLastObj &&//②
                            distance <= diameter &&//③
                            hitObj.name == listLastObj.name)//④
                        {
                            m_ballList.Add(m_hit.collider.gameObject);
                        }
                    }
                    else
                    {
                        if (hitObj != listFirstObj &&//①
                            hitObj != listLastObj &&//②
                            hitObj != m_ballList[m_ballList.Count - 2] &&//⑤
                            distance <= diameter &&//③
                            hitObj.name == listLastObj.name)//④
                        {
                            m_ballList.Add(m_hit.collider.gameObject);
                        }
                    }
                    

                    if (m_ballList.Count > 1 && hitObj == m_ballList[m_ballList.Count - 2])
                    {
                        listLastObj.gameObject.GetComponent<BallController2d>().UnSelectBall();
                        m_ballList.RemoveAt(m_ballList.Count - 1);
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
                    item.SetActive(false);
                }
            }
            else if (m_ballList.Count < 3)
            {
                foreach (var item in m_ballList)
                {
                    item.gameObject.GetComponent<BallController2d>().UnSelectBall();
                }
            }

            m_ballList.Clear();
        }
    }

    /// <summary>
    /// 既に選択されているボールに戻ったときに、最後に選択したボールをListから消す
    /// </summary>
    void SelectBuck(GameObject hitObj, List<GameObject> list)
    {
        if (hitObj == list[list.Count - 1])
        {
            
        }
    }
}
