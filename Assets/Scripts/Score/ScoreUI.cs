using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        
    }

    public void UpdateScore(ScoreController scoreController)
    {
        
        scoreText.text = $"Score:{ScoreController.Instance.Score}";

    }
}
