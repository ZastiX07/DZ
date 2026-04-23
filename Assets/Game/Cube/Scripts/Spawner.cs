using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Cube> Spawn(Cube cube, int count)
    {
        List<Cube> createdCubes = new List<Cube>();

        float newChance = cube.PercentageSeparation / 2;

        for (int i = 0; i < count; i++)
        {
            Vector3 randomOffset = Random.insideUnitCircle * 1.5f;
            Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0);

            Cube newCube = Instantiate(cube, spawnPosition, Quaternion.identity);

            newCube.Initialize(newChance);

            newCube.transform.localScale = cube.Size / 2;

            Renderer renderer = newCube.GetComponent<Renderer>();
            renderer.material.color = Random.ColorHSV();

            createdCubes.Add(newCube);
        }

        Destroy(cube.gameObject);

        return createdCubes;
    }
}
