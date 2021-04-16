using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float m_gameTime = 120f;
    [SerializeField] Text m_gameTimeUI = null;
    [SerializeField] GameObject m_gameoverUI = null;
    [SerializeField] GameObject m_resultButton = null;
    public static bool isPlayed = false;

    void Start()
    {
        m_gameoverUI.SetActive(false);
        m_resultButton.SetActive(false);
    }

    void Update()
    {
        if (isPlayed)
        {
            m_gameTime -= Time.deltaTime;
            m_gameTimeUI.text = $"残り時間：{m_gameTime:F1}";
            if (m_gameTime <= 0)
            {
                isPlayed = false;
                m_gameoverUI.SetActive(true);
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
