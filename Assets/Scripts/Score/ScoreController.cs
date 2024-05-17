using UnityEngine;
using UnityEngine.Events;



public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    
    
    public UnityEvent onScoreChanged;
    public int Score { get;  private set; }

    public  void AddScore(int ringScore)
    {
        Score += ringScore;
      
        onScoreChanged.Invoke(); //çağırıyor
    }
    private void Awake()
    {
        Instance = this; //varolan kendi sınıfı tanımladık//
    }
}
