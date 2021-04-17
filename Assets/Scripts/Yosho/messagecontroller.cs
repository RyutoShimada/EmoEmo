using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class messagecontroller : MonoBehaviour
{
    Vector3 m_initialPosition;
    [SerializeField] Transform m_target = null;

    [SerializeField] Transform m_EndPosition = null;

    [SerializeField] float m_speed = 0.5f;

    void Start()
    {
       
        //m_initialPosition = this.transform.position;
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
            .Append(this.transform.DOMove(m_EndPosition.position, 3f))
            .AppendInterval(3);
        //.OnComplete(() => { };
        seq.Play();



    }

}
