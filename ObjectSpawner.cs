using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Spawner Setting")]
    public GameObject gravelPrefab;
    public ConveyorBelt targetBelt;

    private float spawnRate = 1.5f;
    private float timer = 0f;
    void Update()
    {
        if(targetBelt != null && targetBelt.isRunning)
        {
            timer += Time.deltaTime;
            if (timer >= spawnRate)
            {
                GameObject newBox = Instantiate(gravelPrefab, transform.position, transform.rotation);
                // CRITICAL: Destroy the box after 15 seconds. 
                // If you don't do this, your computer will eventually crash from having 10,000 boxes!
                Destroy(newBox, 15f);
                timer = 0f;
            }
        }
    }
}
