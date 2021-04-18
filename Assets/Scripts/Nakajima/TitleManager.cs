using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject m_FirstText = null;
    [SerializeField] GameObject m_SelectMenu = null;
    [SerializeField] AudioClip m_selectSfx = null;
    [SerializeField] AudioSource m_as;
    bool isStarted = true;

    void Start()
    {
        m_FirstText.SetActive(true);
        m_SelectMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.anyKeyDown && isStarted)
        {
            m_as.PlayOneShot(m_selectSfx);
            m_FirstText.SetActive(false);
            m_SelectMenu.SetActive(true);
            isStarted = false;
        }
    }
}
