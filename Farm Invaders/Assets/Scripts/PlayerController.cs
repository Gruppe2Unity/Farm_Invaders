using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Spillerbevegelse og skyting er håndtert her. Det nye inut systemet til Unity er brukt
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
    /// Init av input-handlinger
    /// </summary>
    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    /// <summary>
    /// skrur på input actions når et objekt er aktivt i spillet
    /// </summary>
    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Fire.performed += OnFire;
    }

    /// <summary>
    /// Skrur av input actions igjen når objekt deaktiveres
    /// </summary>
    private void OnDisable()
    {
        inputActions.Player.Fire.performed -= OnFire;
        inputActions.Player.Disable();
    }

    /// <summary>
    /// Init av spillets grenser når det starter.
    /// </summary>
    private void Start()
    {
        screenBoundary = Camera.main.orthographicSize * Camera.main.aspect;
    }

    /// <summary>
    /// Game loop, håndterer movement på alt hver frame
    /// </summary>
    private void Update()
    {
        HandleMovement();
    }

    /// <summary>
    /// sørger for bevegelse til høyre og venstre innenfor valgte boundries
    /// </summary>
    private void HandleMovement()
    {
        Vector2 moveInput = inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 newPosition = transform.position + Vector3.right * moveInput.x * moveSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, -screenBoundary, screenBoundary);
        transform.position = newPosition;
    }

    /// <summary>
    /// Skyter kuler fra "firepoint" når space trykkes inn
    /// </summary>
    /// <param name="context">Inneholder info om input hendelsen.</param>
    private void OnFire(InputAction.CallbackContext context)
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}