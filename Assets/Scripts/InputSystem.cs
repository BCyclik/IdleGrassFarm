using UnityEngine.InputSystem;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    private InputAction moveAction;
    private InputAction lookAction;
    private void Awake()
    {
        var playerMap = inputActions.FindActionMap("Player");
        moveAction = playerMap.FindAction("Move");
        
        moveAction.Enable();
    }
    private Player player => Player.local;
    private void Update()
    {
        Vector2 movementInput = moveAction.ReadValue<Vector2>();
        MovePlayer(movementInput);
    }
    private void MovePlayer(Vector2 input)
    {
        Vector3 direct = new(input.x, 0, input.y);
        player.Move(direct);
    }
}
