using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] FadeController m_fc;
    int loadType = 0;

    public void LoadScene(string name)
    {
        m_fc.isFadeOut = true;
        loadType = 0;
        StartCoroutine(LoadTimer(name));
    }

    IEnumerator LoadTimer(string name)
    {
        yield return new WaitForSeconds(1.0f);

        if (loadType == 0)
        {
            SceneManager.LoadScene(name);
        }
        else if (loadType == 1)
        {
            TimeManager.isPlayed = true;
        }
    }
}
