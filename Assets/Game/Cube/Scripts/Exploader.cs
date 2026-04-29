using UnityEngine;
using System.Collections.Generic;

public class Exploader : MonoBehaviour
{
    [SerializeField] private ParticleSystem _exploadEffect;
    [SerializeField] private float _explodedForce = 1f;

    public void Expload(Vector3 position, List<Cube> cubes)
    {
        foreach (Cube listCube in cubes)
        {
            Vector3 explosedRadius = listCube.transform.localScale / 2;

            Rigidbody rigidbody = listCube.Rigidbody;

            if (rigidbody != null)
                rigidbody.AddExplosionForce(_explodedForce, transform.position, explosedRadius.magnitude);

            Instantiate(_exploadEffect, position, Quaternion.identity);
        }
    }
}