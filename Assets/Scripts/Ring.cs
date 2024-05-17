using System;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public Transform ball;
    [SerializeField] private int killScore;

    private void Update()
    {
        if (transform.position.y + 12.5f >= ball.position.y)
        {
            Destroy(gameObject);
            ScoreController.Instance.AddScore(killScore);
            
           
        }
    }
}

