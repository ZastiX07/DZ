using UnityEngine;
using System.Collections.Generic;

public class Exploader : MonoBehaviour
{
    [SerializeField] private ParticleSystem _exploadEffect;
    [SerializeField] private float _explodedForce = 1f;

    public void Expload(List<Cube> cubes)
    {
        foreach (Cube listCube in cubes)
        {
            Vector3 explosedRadius = listCube.Size / 2;

            Rigidbody rigidbody = listCube.GetComponent<Rigidbody>();

            if (rigidbody != null)
                rigidbody.AddExplosionForce(_explodedForce, transform.position, explosedRadius.magnitude);

            Instantiate(_exploadEffect, transform.position, Quaternion.identity);
        }
    }
}