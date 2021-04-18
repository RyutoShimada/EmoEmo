using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{   
    [SerializeField] Text m_totalChainText = null;
    [SerializeField] Text m_totalScoreText = null;

    void Start()
    {
        m_totalChainText.text = $"合計チェイン数：{ScoreManager.totalChains}回";
        m_totalScoreText.text = $"合計スコア：{ScoreManager.totalScore}";


    }
}
