using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action OnClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClicked?.Invoke();
        }
    }
}
