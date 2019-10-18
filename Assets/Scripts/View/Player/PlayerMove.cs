using strange.extensions.mediation.impl;
using UnityEngine;
using System;

public class PlayerMove : View
{
    public event Action PlayerTeleported;

    [SerializeField] float speed;
    [SerializeField] CharacterController characterController;

    private Vector3 moveDirection;

    [Inject]
    public IGameField GameField { get; set; }

    public void SetMoveDirection(Vector3 moveDirection)
    {
        this.moveDirection = transform.TransformDirection(moveDirection);
    }

    private void Update()
    {
        if (moveDirection != Vector3.zero)
        {            
            characterController.Move(moveDirection * speed * Time.deltaTime);
            CheckBorders();
        }
    }

    private void CheckBorders() {
        Vector2 player2DPosition = new Vector2(transform.position.x, transform.position.z);
        Vector2 center2DPosition = new Vector2(GameField.GameFieldInfo.center.x, GameField.GameFieldInfo.center.z);
        if ((player2DPosition - center2DPosition).magnitude > GameField.GameFieldInfo.radius) {
            Vector3 teleportPosition = GameField.FindPlayerTeleportPosition();
            transform.position = new Vector3(teleportPosition.x, transform.position.y, teleportPosition.z);
            OnPlayerTeleported();
        }
    }

    private void OnPlayerTeleported() {
        if (PlayerTeleported != null) {
            PlayerTeleported();
        }
    }
}
