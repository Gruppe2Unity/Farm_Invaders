using UnityEngine;

/// <summary>
/// Controls the movement of the enemy formation.
/// Moves enemies side to side and downward when reaching screen edges.
/// </summary>
public class EnemyFormation : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float stepDown = 0.5f;
    [SerializeField] private float edgeLimit = 4f;

    private float moveDirection = 1f;
    private bool shouldStepDown = false;


    /// <summary>
    /// creates automatic edgelimit based on orthograhic camera size
    /// </summary>
    private void Start()
    {
        edgeLimit = Camera.main.orthographicSize * Camera.main.aspect - 1f;
    }

    /// <summary>
    /// Game loop - moves the formation every frame.
    /// </summary>
    private void Update()
    {
        MoveFormation();

        if (shouldStepDown)
        {
            StepDown();
        }
    }

    /// <summary>
    /// Moves the formation horizontally and checks screen edges based on remaining enemies
    /// </summary>
    private void MoveFormation()
    {
        transform.position += Vector3.right * moveDirection * moveSpeed * Time.deltaTime;

        float rightMost = float.MinValue;
        float leftMost = float.MaxValue;

        foreach (Transform enemy in transform)
        {
            if (enemy.position.x > rightMost)
                rightMost = enemy.position.x;
            if (enemy.position.x < leftMost)
                leftMost = enemy.position.x;
        }

        if (rightMost >= edgeLimit && moveDirection > 0)
        {
            moveDirection = -1f;
            shouldStepDown = true;
        }
        else if (leftMost <= -edgeLimit && moveDirection < 0)
        {
            moveDirection = 1f;
            shouldStepDown = true;
        }
    }

    /// <summary>
    /// Moves the formation downward one step.
    /// </summary>
    /// <summary>
    /// Moves the formation downward one fixed step.
    /// </summary>
    private void StepDown()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y - stepDown,
            transform.position.z
        );
        shouldStepDown = false;
    }
    /// <summary>
    /// Sets the movement speed of the formation.
    /// </summary>
    /// <param name="speed">New movement speed.</param>
    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }

    /// <summary>
    /// Checks if all enemies in the formation are dead.
    /// </summary>
    public bool IsEmpty()
    {
        return transform.childCount == 0;
    }
}