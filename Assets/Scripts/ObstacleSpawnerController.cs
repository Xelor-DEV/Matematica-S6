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
            float randomNumber = Random.value;

            // Si el número aleatorio es menor que 0.5...
            if (randomNumber < 0.5f)
            {
                // ...entonces elige el objeto de juego del prefab del asteroide
                GameObject prefab = asteroidePrefab.gameObject;
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject prefabInstantiate = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
                AsteroideController asteroide = prefabInstantiate.GetComponent<AsteroideController>();
                asteroide.Player = player;
            }
            // Si el número aleatorio es mayor o igual a 0.5...
            else
            {
                // ...entonces elige el objeto de juego del prefab de la basura
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
