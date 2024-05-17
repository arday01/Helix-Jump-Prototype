using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class Ball : MonoBehaviour
{
    
    public Rigidbody rb;
    public float jumpForce;
    public GameObject splashPrefab;
    public bool isDead;
    
    public float shakeDuration;
    public float shakePower;
    //private Ring collisionRing;
    //private Ring collisionRing;
    private void OnCollisionEnter(Collision other) //çarpıştığı an oldu için bunu kullandım.
    {
        if (isDead)
        {
            return;
           
        }
        rb.AddForce(Vector3.up*jumpForce);

        var transform1 = transform;
        var calculatePost = transform1.position + new Vector3(0f, -0.2f, 0f);
        var splash = Instantiate(splashPrefab, calculatePost, transform1.rotation);
        
        splash.transform.SetParent(other.gameObject.transform);
        
        if (other.transform.TryGetComponent<Piece>(out var piece))
        {
            if (piece.isTrue)
            {
                
            }
            else
            {
                StartCoroutine(WaitAndRestart());
            }
        }
        // if (other.transform.TryGetComponent<Ring>(out var ring))
        // {
        //     if (ring!=collisionRing)
        //     {
        //         GameManager.Instance.GameScore(25);
        //         collisionRing = ring;
        //     }
        // }
        
        
        if (other.transform.TryGetComponent<LastRing>(out var lastRing))
        {
            Debug.Log("Win game");
        }
        
    }

    private IEnumerator WaitAndRestart()
    {
        Dead();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        
    }

    public void Dead()
    {
        isDead = true;
        rb.isKinematic = true;
        Camera.main.DOShakeRotation(shakeDuration, shakePower);
    }
}
