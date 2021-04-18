using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] FadeController m_fc = null;
    [SerializeField] AudioSource m_as = null;
    [SerializeField] AudioClip m_selectSfx = null;
    int loadType = 0;

    public void LoadScene(string name)
    {
        m_as.PlayOneShot(m_selectSfx);
        m_fc.isFadeOut = true;
        loadType = 0;
        StartCoroutine(LoadTimer(name));
    }

    public void ExitGame()
    {
        m_as.PlayOneShot(m_selectSfx);
        m_fc.isFadeOut = true;
        loadType = 2;
        StartCoroutine(LoadTimer());
    }

    IEnumerator LoadTimer(string name)
    {
        yield return new WaitForSeconds(1.0f);

        if (loadType == 0)
        {
            SceneManager.LoadScene(name);
        }
    }

    IEnumerator LoadTimer()
    {
        yield return new WaitForSeconds(1.0f);

        if (loadType == 1)
        {
            TimeManager.isPlayed = true;
        }
        else if (loadType == 2)
        {
            Application.Quit();
        }
    }
}
