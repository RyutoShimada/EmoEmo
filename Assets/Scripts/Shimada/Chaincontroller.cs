using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaincontroller : MonoBehaviour
{
    //[SerializeField] GameObject m_selectBall = null;

    Vector3 m_ray;
    RaycastHit2D m_hit;
    List<GameObject> m_ballList;

    // Start is called before the first frame update
    void Start()
    {
        m_ballList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        m_ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (m_hit = Physics2D.Raycast(m_ray, Vector3.forward, 100f))
            {
                if (m_hit.collider.tag == "Ball")
                {
                    m_hit.collider.GetComponent<BallController2d>().m_isSelect = true;
                    m_ballList.Add(m_hit.collider.gameObject);
                    Debug.Log(m_ballList.Count);
                    //Vector2 pos = m_hit.collider.transform.position;
                    //Quaternion rotat = m_hit.collider.gameObject.transform.rotation;
                    //Transform parent = m_hit.collider.gameObject.transform;
                    //Instantiate(m_selectBall, pos, rotat, parent);
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (m_hit = Physics2D.Raycast(m_ray, Vector3.forward, 100f))
            {
                if (m_hit.collider.tag == "Ball")
                {
                    m_hit.collider.GetComponent<BallController2d>().m_isSelect = true;
                    m_ballList.Add(m_hit.collider.gameObject);
                    Debug.Log(m_ballList.Count);
                    //Vector2 pos = m_hit.collider.transform.position;
                    //Quaternion rotat = m_hit.collider.gameObject.transform.rotation;
                    //Transform parent = m_hit.collider.gameObject.transform;
                    //Instantiate(m_selectBall, pos, rotat, parent);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            m_hit.collider.GetComponent<BallController2d>().m_isSelect = false;
            if (m_ballList.Count >= 3)
            {
                foreach (var item in m_ballList)
                {
                    Destroy(item);
                }
            }
            
            m_ballList.Clear();
        }
    }
}
