using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float xMin = -5f;
    public float xMax = 5f;
    public float speed = 5f;    //could be faster but seems fine at 5. 
                                //if I did more with this, I would've probably increased it depending on difficulty or level

    //if you press any key that makes you go right, you go right, same with left
    //clamps the x pos so that you don't intersect with that wall
    void Update(){
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * horizontal * speed * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
