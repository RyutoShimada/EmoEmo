using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Chaincontroller : MonoBehaviour
{
    /// <summary>吹き出しにチェイン数を出すために必要なスクリプト</summary>
    [SerializeField] messagecontroller messagecontroller = null;
    AudioSource m_audio;
    
    //マウス操作
    /// <summary>Rayを発射する位置</summary>
    Vector3 m_rayOrigin;
    /// <summary>Rayが当たったオブジェクトの情報が格納される</summary>
    RaycastHit2D m_hit;

    //チェイン処理
    /// <summary>消すために必要なチェイン数</summary>
    [SerializeField] int m_needChainCount = 3;
    /// <summary>チェイン判定に余裕を持たせる割合</summary>
    [SerializeField] float m_margin = 0.07f;
    /// <summary>線の太さ</summary>
    [SerializeField] float m_lineWidth;
    /// <summary>チェーン状態のボールが入る</summary>
    List<GameObject> m_ballList;
    /// <summary>チェインした時に出す線のコンポーネント</summary>
    LineRenderer m_lineRenderer;
    /// <summary>LineRenderer出だす線の位置</summary>
    List<Vector3> m_linePosList;
    /// <summary>チェイン数(読み取り専用)</summary>
    public int m_chainCount { get; private set; }

    #if UNITY_EDITOR
    /// <summary>デバッグ用のチェインテキスト</summary>
    [SerializeField] Text m_chainText = null;
    #endif

    // Start is called before the first frame update
    void Start()
    {
        m_ballList = new List<GameObject>();
        m_linePosList = new List<Vector3>();
        m_lineRenderer = GetComponent<LineRenderer>();
        m_lineRenderer.positionCount = 0;
        //チェインした時に出る線の太さ設定
        m_lineRenderer.startWidth = m_lineWidth;
        m_lineRenderer.endWidth = m_lineWidth;
        m_audio = GetComponent<AudioSource>();
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
        if (m_chainText) m_chainText.text = "CHAIN : " + m_ballList.Count.ToString();

        if (Input.GetMouseButton(0))
        {
            if (m_hit && m_hit.collider.tag == "Ball")
            {
                if (m_ballList.Count == 0)//1個目のボール
                {
                    m_ballList.Add(m_hit.collider.gameObject);
                    m_ballList[m_ballList.Count - 1].GetComponent<BallController2d>().SelectBall();
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
                        m_ballList[m_ballList.Count - 1].GetComponent<BallController2d>().SelectBall();

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
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            //チェイン数に応じて処理を変える
            if (m_ballList.Count >= 3)
            {
                foreach (var item in m_ballList)
                {
                    item.gameObject.GetComponent<BallController2d>().UnSelectBall();
                    item.SetActive(false);
                }
                if (messagecontroller)
                {
                    messagecontroller.Generate(m_ballList[0]);
                }
                m_chainCount = m_ballList.Count;
                m_audio.Play();
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
