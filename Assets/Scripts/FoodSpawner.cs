using UnityEngine;

public class FoodSpawner : MonoBehaviour 
{
    [SerializeField] private GameObject foodPelletPrefab;
    [SerializeField] private int initialQuantity = 5;
    [SerializeField] private float spawnInterval = 5;
    [SerializeField] private float xMin = -5;
    [SerializeField] private float xMax = 5;
    [SerializeField] private float zMin = -5;
    [SerializeField] private float zMax = 5;

    private float spawnTimer;

    private void Start() 
    {
        spawnTimer = 0;

        int instantiatedFood = 0;
        while(instantiatedFood < initialQuantity)
        {
            SpawnFoodPellet();
            instantiatedFood++;
        }
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnInterval <= spawnTimer)
        {
            SpawnFoodPellet();
            spawnTimer = 0;
        }
    }

    private void SpawnFoodPellet()
    {
        float x = Random.Range(xMin, xMax);
        float z = Random.Range(zMin, zMax);

        GameObject food = Instantiate(foodPelletPrefab);
        food.transform.localPosition = new Vector3(x, 0, z);
    }
}
