using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighScoreData
{
    public string HighScorePlayerName;
    public int HighScore;

    public HighScoreData(string HighScorePlayerName, int HighScore)
    {
        this.HighScorePlayerName = HighScorePlayerName;
        this.HighScore = HighScore;
    }
    
    public virtual string ToString()
    {
        return $"Data : Name {HighScorePlayerName}, Score {HighScore} ";
    }
}
