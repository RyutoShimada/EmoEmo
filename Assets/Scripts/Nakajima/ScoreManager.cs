using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int totalChains = 0;
    public static int totalScore = 0;


    public void AddChains(int Chains)
    {
        totalChains += Chains;

        AddScore(Chains * 100);
    }

    void AddScore(int score)
    {
        totalScore += score;
    }

}
