using UnityEngine;
using System.Collections.Generic;

public class Multiplayer : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Exploader _exploader;

    private int _minValueRandom = 2;
    private int _maxValueRandom = 6;

    private void OnEnable()
    {
        _raycaster.ClickedToCube += Multiple;
    }

    private void OnDisable()
    {
        _raycaster.ClickedToCube -= Multiple;
    }

    private void Multiple(Cube cube)
    {
        int countSpawn = Random.Range(_minValueRandom, _maxValueRandom + 1);
        Vector3 cubePosition = cube.transform.position;

        List<Cube> spawnCubes = _spawner.Spawn(cube, countSpawn);

        _exploader.Expload(cubePosition, spawnCubes);
    }
}