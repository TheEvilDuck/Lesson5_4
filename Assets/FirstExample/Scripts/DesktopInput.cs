using System;
using UnityEngine;
using Zenject;

public class DesktopInput : IInput, ITickable
{
    public event Action<Vector3> ClickDown;
    public event Action<Vector3> ClickUp;
    public event Action<Vector3> Drag;

    private const int LeftMouseButton = 0;

    private bool _isSwiping;
    private Vector3 _previousMousePosition;

    public void Tick()
    {
        ProcessClickUp();

        ProcessClickDown();

        ProcessSwipe();
    }

    private void ProcessSwipe()
    {
        if (_isSwiping == false)
            return;

        if(Input.mousePosition != _previousMousePosition)
            Drag?.Invoke(Input.mousePosition);

        _previousMousePosition = Input.mousePosition;
    }

    private void ProcessClickDown()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            _isSwiping = true;
            _previousMousePosition = Input.mousePosition;
            ClickDown?.Invoke(Input.mousePosition);
        }
    }

    private void ProcessClickUp()
    {
        if (Input.GetMouseButtonUp(LeftMouseButton))
        {
            _isSwiping = false;
            ClickUp?.Invoke(Input.mousePosition);
        }
    }
}
