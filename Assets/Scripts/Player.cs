using UnityEngine;
using Fusion;
using UnityEngine.InputSystem;

public class Player : NetworkBehaviour
{
    [SerializeField] private CharacterController _controller;
    
    private InputSystem_Actions _input;
    private float PlayerSpeed = 10f;
    private Plane _plane = new Plane(Vector3.up, Vector3.zero);

    private void Awake()
    {
        _input = new();
        _input.Player.Enable();
    }

    public override void FixedUpdateNetwork()
    {
        var input = _input.Player.Move.ReadValue<Vector2>();

        Vector3 cameraForward = Camera.main.transform.up;
        Vector3 cameraRight = Camera.main.transform.right;
            
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();
            
        var moveRelativeToCamera = cameraForward * input.y + cameraRight * input.x;

        var look = _input.Player.ScreenPoint.ReadValue<Vector2>();
        Debug.LogError(look);
        var mouseRay = Camera.main.ScreenPointToRay(look);
        var hit = _plane.Raycast(mouseRay, out var distance);
        if (hit)
        {
            var point = mouseRay.GetPoint(distance);
            _controller.transform.LookAt(point);
        }
        _controller.Move(moveRelativeToCamera * Runner.DeltaTime * PlayerSpeed);
    }
}
