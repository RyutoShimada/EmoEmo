using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] string m_gameScene = "main";
    [SerializeField] string m_resultScene = "result";
    [SerializeField] string m_TitleScene = "Title";
    [SerializeField] FadeController m_fc;
    int loadType = 0;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == m_gameScene || SceneManager.GetActiveScene().name == m_TitleScene)
        {
            m_fc.isFadeIn = true;
            loadType = 1;
            StartCoroutine(LoadTimer());
        }
    }

    void Update()
    {
        
    }

    public void LoadGameScene()
    {
        m_fc.isFadeOut = true;
        loadType = 0;
        StartCoroutine(LoadTimer());
    }

    public void LoadResultScene()
    {
        SceneManager.LoadScene(m_resultScene);
    }
    public void LoadTitleScene()
    {
        SceneManager.LoadScene(m_TitleScene);
    }
    IEnumerator LoadTimer()
    {
        yield return new WaitForSeconds(1.0f);

        if (loadType == 0)
        {
            SceneManager.LoadScene(m_gameScene);
        }
        else if (loadType == 1)
        {
            TimeManager.isPlayed = true;
        }
    }
}
