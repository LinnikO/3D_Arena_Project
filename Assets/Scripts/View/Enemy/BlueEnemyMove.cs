using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyMove : View
{
    [SerializeField] float speed;
    [SerializeField] float moveTimeMin;
    [SerializeField] float moveTimeMax;
    [SerializeField] CharacterController characterController;

    private Vector3 moveDirection;
    private float startMoveTime;
    private float moveTime;

    [Inject]
    public IGameField GameField { get; set; }

    private void Update()
    {
        if (Time.time - startMoveTime >= moveTime) {
            SetNewMoveDirection();
        }

        if (moveDirection != Vector3.zero)
        {
            characterController.Move(moveDirection * speed * Time.deltaTime);
        }
    }

    private void SetNewMoveDirection()
    {
        startMoveTime = Time.time;
        moveTime = Random.Range(moveTimeMin, moveTimeMax);
        float x = GameField.GameFieldInfo.center.x + Random.Range(-GameField.GameFieldInfo.radius, GameField.GameFieldInfo.radius);
        float z = GameField.GameFieldInfo.center.z + Random.Range(-GameField.GameFieldInfo.radius, GameField.GameFieldInfo.radius);
        Vector3 targetPoint = new Vector3(x, transform.position.y, z);
        moveDirection = (targetPoint - transform.position).normalized;
    }
}
