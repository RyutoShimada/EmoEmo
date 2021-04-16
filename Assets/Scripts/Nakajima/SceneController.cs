using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] FadeController m_fc;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadScene()
    {
        m_fc.isFadeOut = true;
        StartCoroutine(LoadTimer());
    }

    IEnumerator LoadTimer()
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("NakajimaScene");
    }
}
