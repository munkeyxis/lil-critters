using UnityEngine;

public class InitialCritterSpawner : MonoBehaviour 
{
    [SerializeField] private GameObject critterPrefab;
    [SerializeField] private int initialQuantity = 5;
    [SerializeField] private float xMin = -7;
    [SerializeField] private float xMax = 7;
    [SerializeField] private float zMin = -7;
    [SerializeField] private float zMax = 7;

    private float y = -0.45f;

    private void Start() 
    {
        int instantiatedCritters = 0;
        while (instantiatedCritters < initialQuantity)
        {
            float x = Random.Range(xMin, xMax);
            float z = Random.Range(zMin, zMax);

            GameObject food = Instantiate(critterPrefab);
            food.transform.localPosition = new Vector3(x, y, z);
            instantiatedCritters++;
        }
    }
}
