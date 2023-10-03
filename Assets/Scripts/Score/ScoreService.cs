using UnityEngine;

public class ScoreService : MonoBehaviour, IScoreService
{
    int _score;
    public int Score 
    {
        get => _score;
        set
        {
            if (value >= 0) _score = value;
        }
    }
}