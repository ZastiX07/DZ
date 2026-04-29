using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public event Action<Cube> ClickedToCube;

    private void OnEnable()
    {
        _inputReader.OnClicked += OnClickedCube;
    }

    private void OnDisable()
    {
        _inputReader.OnClicked -= OnClickedCube;
    }

    private void OnClickedCube()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.TryGetComponent(out Cube cube))
                ClickedToCube?.Invoke(cube);
        }
    }
}