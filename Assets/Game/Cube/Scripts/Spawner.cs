using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Cube> Spawn(Cube cube, int count)
    {
        List<Cube> createdCubes = new List<Cube>();
   
        if (CanSplit(cube.PercentageSeparation))
        {

            float newChance = cube.PercentageSeparation / 2;

            for (int i = 0; i < count; i++)
            {
                Vector3 randomOffset = Random.insideUnitCircle * 1.5f;
                Vector3 spawnPosition = cube.transform.position + new Vector3(randomOffset.x, randomOffset.y, 0);

                Cube newCube = Instantiate(cube, spawnPosition, Quaternion.identity);

                newCube.Initialize(newChance);

                Vector3 localScaleNewCube = cube.transform.localScale / 2;

                newCube.transform.localScale = localScaleNewCube;

                Renderer renderer = newCube.Renderer;
                renderer.material.color = Random.ColorHSV();

                createdCubes.Add(newCube);
            }
            
            Destroy(cube.gameObject);
        }
        else
        {
            Destroy(cube.gameObject);
        }

        return createdCubes;
    }

    private bool CanSplit(float chance)
    {
        return chance >= Random.value * 100;
    }
}