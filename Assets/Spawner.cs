// using UnityEngine;

// public class Spawner : MonoBehaviour
// {
//     public GameObject[] cubes;
//     public Transform[] points;
//     public float beat = (60/130)*2;
//     private float timer;

//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (timer > beat) {
//             GameObject cube = Instantiate(cubes[Random.Range(0,2)], points[Random.Range(0,4)]);
//             cube.transform.localPosition = Vector3.zero;
//             cube.transform.Rotate(transform.forward, 90 * Random.Range(0,4));
//             timer -= beat;
//         }

//         timer += Time.deltaTime; 

//     }
// }

using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;        // Prefab list
    public Transform[] points;        // Spawn points
    public float beat = (60f / 130f) * 2f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > beat)
        {
            // 1. Pick a random prefab and spawn point
            GameObject prefab = cubes[Random.Range(0, cubes.Length)];
            Transform spawnPoint = points[Random.Range(0, points.Length)];

            // 2. Instantiate at correct world position/rotation
            GameObject cube = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);

            // 3. Apply random 90-degree rotation around Z axis
            cube.transform.Rotate(transform.forward, 90f * Random.Range(0, 4));

            timer -= beat;
        }
    }
}

