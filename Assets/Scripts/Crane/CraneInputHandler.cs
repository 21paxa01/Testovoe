using System;
using UnityEngine;

public class CraneInputHandler : MonoBehaviour
{
    public static event Action<Vector3> OnMoveCraneCommand;
    public static event Action<Vector3> OnMoveHookCommand;
    public static event Action<Vector3> OnMoveBeamCommand;

    [SerializeField] private float upSpeed = 2f;
    [SerializeField] private float downSpeed = 2f;
    [SerializeField] private float horizontalSpeed = 2f;
    [SerializeField] private float forwardSpeed = 2f;

    private Direction direction;
    private Vector3 currentDirection;

    private void OnEnable()
    {
        CraneControlerButton.OnButtonClicked += SetDirection;
    }
    
    private void OnDisable()
    {
        CraneControlerButton.OnButtonClicked -= SetDirection;
    }
    
    void SetDirection(Direction _direction)
    {
        direction = _direction;
    }

    void Update()
    {
        if (direction==Direction.Up)
            OnMoveHookCommand?.Invoke(Vector3.up * upSpeed);

        if (direction==Direction.Down)
            OnMoveHookCommand?.Invoke(Vector3.down * downSpeed);

        if (direction==Direction.Left)
            OnMoveCraneCommand?.Invoke(Vector3.left * horizontalSpeed);

        if (direction==Direction.Right)
            OnMoveCraneCommand?.Invoke(Vector3.right * horizontalSpeed);

        if (direction==Direction.Forward)
            OnMoveBeamCommand?.Invoke(Vector3.forward * forwardSpeed);

        if (direction==Direction.Backward)
            OnMoveBeamCommand?.Invoke(Vector3.back * forwardSpeed);
    }
}