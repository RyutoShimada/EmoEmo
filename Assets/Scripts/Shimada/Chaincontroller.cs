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

    LineRenderer m_lineRenderer;
    List<Vector3> m_linePosList;

    // Start is called before the first frame update
    void Start()
    {
        m_ballList = new List<GameObject>();
        m_linePosList = new List<Vector3>();
        m_lineRenderer = GetComponent<LineRenderer>();
        m_lineRenderer.startWidth = 0.2f;
        m_lineRenderer.endWidth = 0.2f;
        m_lineRenderer.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m_hit = Physics2D.Raycast(m_rayOrigin, Vector3.forward, 100f);
        GetMouseButton();
    }

    void GetMouseButton()
    {
        m_chainText.text = "CHAIN : " + m_ballList.Count.ToString();

        if (Input.GetMouseButton(0))
        {
            if (m_hit && m_hit.collider.tag == "Ball")
            {
                if (m_ballList.Count == 0)//1個目のボール
                {
                    m_ballList.Add(m_hit.collider.gameObject);
                    m_linePosList.Add(m_hit.collider.gameObject.transform.position);
                    m_lineRenderer.positionCount++;
                }
                else//2個目以上のボール
                {
                    GameObject hitObj = m_hit.collider.gameObject;
                    GameObject listLastObj = m_ballList.Last().gameObject;
                    float distance = Vector2.Distance(hitObj.transform.position, listLastObj.transform.position);
                    float diameter = hitObj.GetComponent<Renderer>().bounds.size.x + (hitObj.GetComponent<Renderer>().bounds.size.x * m_margin);

                    //①既に選択されていない
                    //②それらのオブジェクトが隣接している
                    //③そのオブジェクト同士の名前が同じ
                    //ならリストに追加する

                    if (!hitObj.GetComponent<BallController2d>().m_isSelect &&//①
                        distance <= diameter &&//②
                        hitObj.name == listLastObj.name)//③
                    {
                        m_ballList.Add(m_hit.collider.gameObject);

                        //チェインの線を描く
                        m_linePosList.Add(m_hit.collider.gameObject.transform.position);
                        m_lineRenderer.positionCount++;
                        m_lineRenderer.SetPositions(m_linePosList.ToArray());
                    }

                    if (m_ballList.Count >= 2)
                    {
                        //チェーン最中に戻した時に選択を解除する
                        if (hitObj == m_ballList[m_ballList.Count - 2])
                        {
                            listLastObj.gameObject.GetComponent<BallController2d>().UnSelectBall();
                            m_ballList.RemoveAt(m_ballList.Count - 1);

                            //チェインの線を消す
                            m_linePosList.RemoveAt(m_lineRenderer.positionCount - 1);
                            m_lineRenderer.positionCount--;
                        }
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

            //チェインの線を消す
            m_linePosList.Clear();
            m_lineRenderer.positionCount = 0;
        }
    }
}
