using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Spillerbevegelse og skyting er håndtert her. Det nye inut systemet til Unity er brukt
/// Playermovemenbt and shooting is handled here
/// The new input system from Unity is used
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private PlayerInputActions inputActions;
    private float horizontalInput;
    private float screenBoundary;

    /// <summary>
    /// Init of input-actions
    /// </summary>
    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    /// <summary>
    /// Turns on input actions when an object is active in the game
    /// </summary>
    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Fire.performed += OnFire;
    }

    /// <summary>
    /// Turns off input actions when an object is disabled
    /// </summary>
    private void OnDisable()
    {
        inputActions.Player.Fire.performed -= OnFire;
        inputActions.Player.Disable();
    }

    /// <summary>
    /// Init of the screen boundaries when the game starts.
    /// </summary>
    private void Start()
    {
        screenBoundary = Camera.main.orthographicSize * Camera.main.aspect;
    }

    /// <summary>
    /// Game loop, handles movement of everything each frame
    /// </summary>
    private void Update()
    {
        HandleMovement();
    }

    /// <summary>
    /// Handles movement to the right and left within the chosen boundaries
    /// </summary>
    private void HandleMovement()
    {
        Vector2 moveInput = inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 newPosition = transform.position + Vector3.right * moveInput.x * moveSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, -screenBoundary, screenBoundary);
        transform.position = newPosition;
    }

    /// <summary>
    /// Shoots bullets from the "firepoint" when space is pressed
    /// </summary>
    /// <param name="context">Contains info about the input event.</param>
    private void OnFire(InputAction.CallbackContext context)
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}