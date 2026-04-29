using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosedEffect;
    [SerializeField] private float _explodedForce = 1f;

    public Rigidbody Rigidbody { get; private set; }
    public Renderer Renderer { get; private set; }

    public float PercentageSeparation { get; private set; } = 100f;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
    }


    public void Initialize(float chance)
    {
        PercentageSeparation = chance;
    }
}