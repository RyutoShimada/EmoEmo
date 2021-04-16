using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
/// <summary>
/// ランダムなボールをこのスクリプトがアタッチされたオブジェクトの場所から生成する
/// </summary>
public class BallCounter : MonoBehaviour
{
    /// <summary>生成するプレハブ</summary>
    [SerializeField] GameObject[] m_ballPrefabs = null;
    /// <summary>生成する範囲</summary>
    [SerializeField] GameObject m_clonePosA = null, m_clonePosB = null;
    /// <summary>設定されたプレハブからランダムなもの一つを生成する</summary>
    int m_index;
    /// <summary>タイマー</summary>
    float m_timer;
    /// <summary>ボールを生成する間隔</summary>
    [SerializeField] float m_interval = 1f;
    /// <summary>ボールを生成する上限</summary>
    [SerializeField] int m_maxBallCount = 3;
    /// <summary>最初に出すボールの数</summary>
    [SerializeField] int m_firstBallCount = 10;
    /// <summary>ボールのリスト</summary>
    List<BallController2d> m_childBalls = new List<BallController2d>();

    private void Start()
    {
        for (int i = 0; i <= m_firstBallCount; i++)
        {
            InstantiateBall();
        }
        m_childBalls = GetComponentsInChildren<BallController2d>().ToList();
        if (m_childBalls != null) { Debug.Log("get childBalls"); }
        m_childBalls.ForEach(ball => ball.gameObject.SetActive(false));
    }

    private void Update()
    {
        if (m_childBalls.Where(ball => ball.gameObject.activeSelf == true).Count() < m_maxBallCount)
        {
            m_timer += Time.deltaTime;
            if (m_timer > m_interval)
            {
                m_timer = 0;
                ActivateBall();
            }
        }
    }
#if UNITY_EDITOR
    public void NonActiveBall()
    {
        int skipIndex = Random.Range(0, m_childBalls.Where(ball => ball.gameObject.activeSelf == true).Count());
        BallController2d activeBall = m_childBalls.Where(ball => ball.gameObject.activeSelf == true).Skip(skipIndex).FirstOrDefault();
        activeBall.gameObject.SetActive(false);
    }
    public void NonActiveBallAll()
    {
        m_childBalls.Where(ball => ball.gameObject.activeSelf == true).ToList().ForEach(ball => ball.gameObject.SetActive(false));
    }
#endif

    /// <summary>
    /// ボールをクローンする
    /// </summary>
    public void InstantiateBall()
    {
        if (m_ballPrefabs == null) return;
        m_index = Random.Range(0, m_ballPrefabs.Length);
        Instantiate(m_ballPrefabs[m_index], this.transform.position, Quaternion.identity, this.transform);
    }

    /// <summary>
    /// アクティブになっていないボールの中からランダムなボールをアクティブにする
    /// </summary>
    void ActivateBall()
    {
        int skipIndex = Random.Range(0, m_childBalls.Where(ball => ball.gameObject.activeSelf == false).Count());
        BallController2d activeBall = m_childBalls.Where(ball => ball.gameObject.activeSelf == false).Skip(skipIndex).FirstOrDefault();
        if (m_clonePosA && m_clonePosB)
        {
            float clonePosX = Random.Range(m_clonePosA.transform.position.x, m_clonePosB.transform.position.x);
            Debug.Log(clonePosX);
            activeBall.gameObject.transform.position = new Vector2(clonePosX, this.transform.position.y);
        }
        else activeBall.gameObject.transform.position = this.transform.position;
        activeBall.gameObject.SetActive(true);
    }
}
