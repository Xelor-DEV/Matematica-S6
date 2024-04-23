using UnityEngine;

public class ObstacleSpawnerController : MonoBehaviour
{
    [SerializeField] private AsteroideController asteroidePrefab;
    [SerializeField] private GarbageController garbagePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private PlayerController player;
    [SerializeField] private int quantityObstacles;
    void Start()
    {
        asteroidePrefab.Player = player;
        asteroidePrefab.Player = player;
        Invoke("GenerarObstaculos", 5);
    }

    private void GenerarObstaculos()
    {
        for (int i = 0; i < quantityObstacles; ++i)
        {
            float randomNumber = Random.Range(0,10);
            if (randomNumber < 5)
            {
                GameObject prefab = asteroidePrefab.gameObject;
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject prefabInstantiate = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
                AsteroideController asteroide = prefabInstantiate.GetComponent<AsteroideController>();
                asteroide.Player = player;
            }
            else
            {
                GameObject prefab = garbagePrefab.gameObject;
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject prefabInstantiate = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
                GarbageController garbage = prefabInstantiate.GetComponent<GarbageController>();
                garbage.Player = player;
            }
        }
        Invoke("GenerarObstaculos", 5);
    }
}
