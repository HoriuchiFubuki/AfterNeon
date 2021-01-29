using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreClass
{
    private static ScoreClass scoreClass;
    public static ScoreClass GetInstance()
    {
        //singleton
        if (scoreClass == null)
        {
            scoreClass = new ScoreClass();
        }
        return scoreClass;
    }

    private float
        totalScore;

    private int
        hitCount;

    private const float
        baseScore = 1000,
        deduction = 50;

    public ScoreClass()
    {
        InitParam();
    }
    public void InitParam()
    {
        totalScore = 0;
        hitCount = 0;
    }

    public void SetScore(float Time, float bonus)
    {
        totalScore = baseScore - (Time + deduction * hitCount) + bonus;

        PlayerPrefs.SetFloat("NewScore", totalScore);
        PlayerPrefs.Save();
    }
    public void HitCount()
    {
        hitCount++;
    }
}
