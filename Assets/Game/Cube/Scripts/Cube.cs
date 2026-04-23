using UnityEngine;
using System.Collections.Generic;

public class Cube : MonoBehaviour
{
    [SerializeField] private Vector3 _size = new Vector3(2, 2, 2);
    [SerializeField] private ParticleSystem _explosedEffect;
    [SerializeField] private float _explodedForce = 1f;

    public float PercentageSeparation { get; private set; } = 100f;
    public Vector3 Size => _size;

    private void Start()
    {
        transform.localScale = _size;

        if (GetComponent<BoxCollider>() == null)
            gameObject.AddComponent<BoxCollider>();

        if (GetComponent<Rigidbody>() == null)
            gameObject.AddComponent<Rigidbody>();
    }

    public void Initialize(float chance) 
    {
        PercentageSeparation = chance;
    } 
}