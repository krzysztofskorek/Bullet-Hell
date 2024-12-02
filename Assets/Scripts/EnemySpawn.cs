using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Vector3[] spawnPoints;

    int index = 0;
    
    void Start()
    {
        
        InvokeRepeating(nameof(SpawnEnemy), 0.1f, 2f);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoints[index], Quaternion.identity);
        index = (index + 1) % (spawnPoints.Length);
    }
}
