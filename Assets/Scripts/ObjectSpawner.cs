using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] obstacleObjects;
    public float spawnMinX = -3f;
    public float spawnMaxX = 3f;
    public float i = 1f;
    public static float j = 1f;
    
    //starts coroutines
    void Start(){
        StartCoroutine(SpawnObjects());
        StartCoroutine(SpeedUp());
    }

    //stops everything from spawning and speeding up if the player is dead
    void update(){
        if(OnShipDestroy.isDead){
            StopAllCoroutines();
        }
    }

    //spawns the objects randomly between x = (-3,3) and at a random time interval that gets faster as the game goes
    IEnumerator SpawnObjects(){
        while(true){
            yield return new WaitForSeconds(Random.Range(3/i, 7/i));

            //random values
            int randomIndex = Random.Range(0, obstacleObjects.Length);
            float randomX = Random.Range(spawnMinX, spawnMaxX);

            //spawns the objects
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
            Instantiate(obstacleObjects[randomIndex], spawnPosition, Quaternion.identity);

            //increases the spawn rate 
            if(i <= 1.06){
                i += 0.01f;
            }else if(i <= 1.1f){
                i += 0.05f;
            }else{
                i += 0.1f;
            }
        }
    }

    //speeds up the onjects and terrain every 7 seconds
    IEnumerator SpeedUp(){
        while(true){
            yield return new WaitForSeconds(7f);
            if(j <= 1.06){
                j += 0.01f;
            }else if(j <= 1.3f){
                j += 0.05f;
            }else{
                j += 0.1f;
            }
            ObjectBehaviour.speed += j;
        }
    }
    

}
