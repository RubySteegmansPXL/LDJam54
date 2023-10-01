using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    private void OnEnable()
    {
        EventManager.OnWaveCompleted += AddScore;
        score = 0;
    }

    private void OnDisable()
    {
        EventManager.OnWaveCompleted -= AddScore;
    }

    private void AddScore(int Score)
    {
        score += Score;
    }
}