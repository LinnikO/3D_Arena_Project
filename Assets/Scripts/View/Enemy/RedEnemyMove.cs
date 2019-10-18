using UnityEngine;

public class RedEnemyMove : MonoBehaviour
{
    public enum RedEnemyState
    {
        MOVE_UP,
        IDLE,
        CHASE_PLAER
    }

    [SerializeField] float upSpeed;
    [SerializeField] float chaseSpeed;
    [SerializeField] float upDistance;
    [SerializeField] float idleTime;
    [SerializeField] float destroyTime;

    private RedEnemyState state;
    private float startMoveUpY;
    private float startIdleTime; 
    private Vector3 chaseDirection;

    private void OnEnable()
    {
        SetState(RedEnemyState.MOVE_UP);
    }

    private void Update()
    {
        switch (state)
        {
            case RedEnemyState.MOVE_UP:
                UpMoveUpdate();
                break;
            case RedEnemyState.IDLE:
                IdleUpdate();
                break;
            case RedEnemyState.CHASE_PLAER:
                ChaseUpdate();
                break;           
        }
    }

    private void SetState(RedEnemyState newState) {
        state = newState;
        switch (state)
        {
            case RedEnemyState.MOVE_UP:
                startMoveUpY = transform.position.y;
                break;
            case RedEnemyState.IDLE:
                startIdleTime = Time.time;
                break;
            case RedEnemyState.CHASE_PLAER:
                Transform playerTransform = FindObjectOfType<PlayerView>().transform;
                chaseDirection = (playerTransform.position - transform.position).normalized;
                Destroy(this.gameObject, destroyTime);
                break;           
        }
    }

    private void UpMoveUpdate() {
        float y = transform.position.y + upSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        if (y - startMoveUpY >= upDistance) {
            SetState(RedEnemyState.IDLE);
        }
    }

    private void IdleUpdate() {
        if (Time.time - startIdleTime >= idleTime) {
            SetState(RedEnemyState.CHASE_PLAER);
        }
    }

    private void ChaseUpdate() {
        transform.Translate(chaseDirection * chaseSpeed * Time.deltaTime);
    }  

    private void OnTriggerEnter(Collider other)
    {
        if (state == RedEnemyState.CHASE_PLAER && (other.tag == "Player" || other.tag == "Obstacle"))
        {
            Destroy(this.gameObject);
        }
    }


}
