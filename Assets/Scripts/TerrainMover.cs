using UnityEngine;
using System.Collections;

public class TerrainMover : MonoBehaviour
{    
    Rigidbody rb;
    public float speed = 18f;   //makes it look like you're going super fast
    public GameObject parentObject;

    void Start(){
        rb = GetComponent<Rigidbody>();
        StartCoroutine(spawnTerrain());
    }

    //stops everything once the player dies
    void Update(){
        if(OnShipDestroy.isDead){
            StopAllCoroutines();
            rb.linearVelocity = Vector3.zero;
        }
    }

    //the rate in which the terrain moves towards the player
    //speeds up with the objects so it looks like you're going faster
    IEnumerator spawnTerrain(){
        while(true){
            rb.linearVelocity = Vector3.back * (speed + ObjectSpawner.j); 
            yield return new WaitForSeconds(.01f);

        }
    }

    //destroys the specific terrain & its parrent (on an empty object behind all the terrain stuff) once it hits the barrier
     void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Destroyer")){
            Destroy(gameObject);
            Destroy(parentObject);
        }
    }
}

