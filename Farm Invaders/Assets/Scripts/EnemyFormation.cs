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
    /// Moves the formation horizontally and checks screen edges.
    /// </summary>
    private void MoveFormation()
    {
        transform.position += Vector3.right * moveDirection * moveSpeed * Time.deltaTime;

        if (transform.position.x >= edgeLimit || transform.position.x <= -edgeLimit)
        {
            moveDirection *= -1f;
            shouldStepDown = true;
        }
    }

    /// <summary>
    /// Moves the formation downward one step.
    /// </summary>
    private void StepDown()
    {
        transform.position += Vector3.down * stepDown;
        shouldStepDown = false;
    }
}