using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRespawn : MonoBehaviour
{
    public List<GameObject> cubes;
    public Vector3[] startPos;
    public bool[] cubeDestroyed;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            startPos[i] = cubes[i].transform.position;
            cubeDestroyed[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            if (cubes[i].transform.position.y < -3)
            {
                cubeDestroyed[i] = true;
                Destroy(cubes[i]);
            }
            if (cubeDestroyed[i] == true)
            {
                cubeDestroyed[i] = false;
                cubes[i] = Instantiate(cube, startPos[i], Quaternion.identity);
            }
        }
    }
}
