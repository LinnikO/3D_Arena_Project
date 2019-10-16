using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float moveTimeMin;
    [SerializeField] float moveTimeMax;
    [SerializeField] CharacterController characterController;

    private Vector3 moveDirection;
    private float startMoveTime;
    private float moveTime;

    private void Update()
    {
        if (Time.time - startMoveTime >= moveTime) {
            startMoveTime = Time.time;
            moveTime = Random.Range(moveTimeMin, moveTimeMax);
            float x = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);
            moveDirection = new Vector3(x, 0, z).normalized;
        }

        if (moveDirection != Vector3.zero)
        {
            characterController.Move(moveDirection * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border")
        {
            moveDirection = -moveDirection;
        }
    }
}
