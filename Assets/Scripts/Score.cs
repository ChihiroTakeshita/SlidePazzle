using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] float defaultScore;

    Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public float AddScore(int interval)
    {
        float score;

        switch(interval)
        {
            case 0:
                score = defaultScore * 2;
                break;
            case 1:
                score = defaultScore * 1.7f;
                break;
            case 2:
                score = defaultScore * 1.3f;
                break;
            default:
                score = defaultScore;
                break;
        }

        return score;
    }

    void ShowScore(float currentScore)
    {
        scoreText.text = currentScore.ToString();
    }
}
