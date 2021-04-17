using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// これはお遊びなのでゲームにはアタッチしないこと
/// </summary>
public class ClickAddForce : MonoBehaviour
{
    [SerializeField] float m_pushPower = 5f;
    [SerializeField] float m_radius = 3f;
    RaycastHit2D[] m_hits;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) PushPower();
    }

    void PushPower()
    {
        Vector3 rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float dirX, dirY;
        dirX = Random.Range(-1, 1);
        dirY = Random.Range(-1, 1);
        m_hits = Physics2D.CircleCastAll(rayOrigin, m_radius, Vector3.forward);
        m_hits.ToList().ForEach(ball => ball.rigidbody.AddForce(new Vector2(dirX, dirY) * m_pushPower, ForceMode2D.Impulse));
    }
}
