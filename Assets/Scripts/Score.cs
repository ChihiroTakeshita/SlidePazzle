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
        scoreText.text = 0.ToString();
    }

    public int AddScore(int interval, int currentScore)
    {
        float add;

        switch(interval)
        {
            case 1:
                add = defaultScore * 2;
                break;
            case 2:
                add = defaultScore * 1.7f;
                break;
            case 3:
                add = defaultScore * 1.3f;
                break;
            default:
                add = defaultScore;
                break;
        }

        return (int)add + currentScore;
    }

    public void ShowScore(int currentScore)
    {
        scoreText.text = currentScore.ToString();
    }
}
