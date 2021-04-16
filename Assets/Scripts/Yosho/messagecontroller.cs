using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class messagecontroller : MonoBehaviour
{
    Vector3 m_initialPosition;
    [SerializeField] Transform m_target = null;

    [SerializeField] float m_speed = 0.5f;

    Rigidbody2D m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_initialPosition = this.transform.position;
        Scrolling();
    }

    private void Update()
    {
        
        Destroy(this.gameObject, 6f);
    }

    void Scrolling() 
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(this.transform.DOMove(m_target.position, 1f))
            .AppendInterval(2)
            .Append(this.transform.DOMove(m_initialPosition, 3f))
            .AppendInterval(3);
        //.OnComplete(() => { };
        seq.Play();



    }

}
