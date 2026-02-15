using UnityEngine;
using System.Collections;

public class ObjectBehaviour : MonoBehaviour
{
    public static float speed = 8f;
    Rigidbody rb;

    //rigidbody!! sobbing
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    //moves the object towards the player and rotates it
    //destroys the object if the player is dead
    void Update(){
        if(OnShipDestroy.isDead){
            Destroy(gameObject);
        }
        rb.linearVelocity = Vector3.back * speed;
        gameObject.transform.Rotate(0, 0, 1);
    }

    //Destroys the game object if it collides with the boundary or the plaayer
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Destroyer")){
            Destroy(gameObject);
        }
    }
}
