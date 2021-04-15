using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] m_go = null;
    int m_index;
    float m_timer;
    [SerializeField] float m_interval = 1f;

    private void Update()
    {
        if (m_go == null) return;
        m_timer += Time.deltaTime;
        if (m_timer > m_interval)
        {
            m_timer = 0f;
            m_index = Random.Range(0, m_go.Length);
            if (m_go[m_index].tag == "Image")
                Instantiate(m_go[m_index], this.transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("WorldCanvas").transform);
            else Instantiate(m_go[m_index], this.transform.position, Quaternion.identity);
        }
    }
}
