
using UnityEngine;

public class RotateMove : MonoBehaviour
{
    public float rotateSpeed;
    private float moveX;
    public Ball ball;
 
   
    private  void Update()
    {
        if (ball.isDead)
        {
            return;
        }
        
        moveX = Input.GetAxis("Mouse X");
        if (Input.GetMouseButton(0))
        {

            transform.Rotate(0f, moveX * rotateSpeed * Time.deltaTime, 0f);
            
        }
    }
}
