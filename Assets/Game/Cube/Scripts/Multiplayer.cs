using UnityEngine;
using System.Collections.Generic;

public class Multiplayer : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Exploader _exploader;

    private int _minValueRandom = 2;
    private int _maxValueRandom = 6;

    private void OnEnable()
    {
        _inputReader.OnClick += Multiple;
    }

    private void Multiple(Cube cube)
    {
        int countSpawn = Random.Range(_minValueRandom, _maxValueRandom + 1);

        List<Cube> spawnCubes = _spawner.Spawn(cube, countSpawn);

        _exploader.Expload(spawnCubes);

        Destroy(cube.gameObject);
    }
}
