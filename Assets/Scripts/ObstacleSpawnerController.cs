using UnityEngine;
public class ObstacleSpawnerController : MonoBehaviour
{
    [SerializeField] private AsteroideController asteroidePrefab;
    [SerializeField] private GarbageController garbagePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private PlayerController player;
    [SerializeField] private int quantityObstacles;
    [SerializeField] private int delayTimeGenerate;
    void Start()
    {
        Invoke("GenerarObstaculos", delayTimeGenerate);
    }
    private void GenerarObstaculos()
    {
        //Sistema para evitar que los obstaculos repitan su posicion al generarse
        int[] indexes = new int[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; ++i)
        {
            indexes[i] = i;
        }
        for (int i = 0; i < quantityObstacles; ++i)
        {
            float randomNumber = Random.Range(0, 10);
            int randomIndex = Random.Range(0, spawnPoints.Length - i);
            int spawnPointIndex = indexes[randomIndex];
            indexes[randomIndex] = indexes[spawnPoints.Length - i - 1];
            if (randomNumber < 5)
            {
                GameObject prefab = asteroidePrefab.gameObject;
                Transform spawnPoint = spawnPoints[spawnPointIndex];
                GameObject prefabInstantiate = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
                AsteroideController asteroide = prefabInstantiate.GetComponent<AsteroideController>();
                asteroide.Player = player;
            }
            else
            {
                GameObject prefab = garbagePrefab.gameObject;
                Transform spawnPoint = spawnPoints[spawnPointIndex];
                GameObject prefabInstantiate = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
                GarbageController garbage = prefabInstantiate.GetComponent<GarbageController>();
                garbage.Player = player;
            }
        }
        Invoke("GenerarObstaculos", delayTimeGenerate);
    }
}
