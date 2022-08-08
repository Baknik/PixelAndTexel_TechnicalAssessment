using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I've enabled GPU instancing for the sphere material, which required me to turn off Unity's SRP batcher. The custom shader graph can be found in Assets/Shaders.

public class SphereSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform _spherePrefab;
    [SerializeField]
    private int _numSpheresToSpawn = 1000;

    /*
     * Using a sphere collider here to allow easy editing of the spawn area in-editor.
     * Given more time, it would be better to use a custom gizmo with handles for editing these values.
     */ 
    [SerializeField]
    private SphereCollider _spawnBounds;

    private void SpawnSpheres()
    {
        for (int i=0; i<_numSpheresToSpawn; i++)
        {
            /*
             * Instantiate prefab within a sphere of the same size as the sphere collider's bounds
             * This loop could be placed within a coroutine, limiting spawning to a maximum number of objects per frame, and freeing up some per-frame processing time.
             */
            Instantiate(_spherePrefab, (Random.insideUnitSphere * _spawnBounds.radius) + _spawnBounds.center + _spawnBounds.transform.position, Quaternion.identity);
        }
    }

    public void OnSpawnButtonPressed()
    {
        SpawnSpheres();
    }
}
