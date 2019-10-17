using strange.extensions.mediation.impl;
using UnityEngine;

public class PlayerMove : View
{
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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border")
        {
            transform.position = GameField.FindPlayerTeleportPosition();
        }
    }
}
