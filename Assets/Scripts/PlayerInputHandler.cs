using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputHandler : MonoBehaviour
{
    private ShipController shipController;
    private PlayerInput playerInput;

    private void Awake()
    {
        shipController = GetComponent<ShipController>();
        playerInput = GetComponent<PlayerInput>();
    }

    public void OnMove(InputValue value)
    {
        if (shipController != null)
            shipController.OnMove(value);
    }
}
