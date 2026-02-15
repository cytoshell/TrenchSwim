using UnityEngine;
using System.Collections;

public class TerrainSpawner : MonoBehaviour
{
    public GameObject terrainPrefab;

    void Start()
    {
        StartCoroutine(SpawnTerrainRoutine());
    }

    //when the player isn't dead, spawns the terrain every 6 seconds
    IEnumerator SpawnTerrainRoutine()
    {
        while (!OnShipDestroy.isDead)
        {
            Vector3 spawnPosition = transform.position;
            Instantiate(terrainPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(6f);
        }
    }
}
