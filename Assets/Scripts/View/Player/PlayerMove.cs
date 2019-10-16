using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] CharacterController characterController;

    private Vector3 moveDirection;

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
            //Teleport player
        }
    }
}
