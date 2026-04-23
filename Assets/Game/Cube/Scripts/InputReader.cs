using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<Cube> OnClick;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Physics.Raycast(ray, out RaycastHit hitInfo);

            if (hitInfo.collider.TryGetComponent(out Cube cube))
            {
               OnClick?.Invoke(cube);
            }
        }
    }
}
