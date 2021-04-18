using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float m_gameTime = 120f;
    [SerializeField] Text m_gameTimeUI = null;
    [SerializeField] GameObject m_timeupUI = null;
    [SerializeField] GameObject m_resultButton = null;
    [SerializeField] Animator m_anim;
    public static bool isPlayed = true;
    

    void Start()
    {
        m_timeupUI.SetActive(false);
        m_resultButton.SetActive(false);
    }

    void Update()
    {
        if (m_anim == null) return;

        if (isPlayed)
        {
            m_gameTime -= Time.deltaTime;
            m_gameTimeUI.text = $"{m_gameTime:F0}";

            if (m_gameTime >= 10.5f)
            {
                m_anim.Play("GameTime");
            }
            else if (m_gameTime < 10.5f && m_gameTime > 0)
            {
                m_anim.Play("BeforeTheEnd");
            }
            else if (m_gameTime <= 0)
            {
                m_anim.Play("GameTime");
            }

            if (m_gameTime <= 0)
            {
                isPlayed = false;
                m_timeupUI.SetActive(true);
                StartCoroutine(DisplayButton());
            }
        }
    }

    IEnumerator DisplayButton()
    {
        yield return new WaitForSeconds(2.0f);

        m_resultButton.SetActive(true);
    }
}
