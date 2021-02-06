using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    [SerializeField] TMP_Text scoreText;

    public int score;
    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
