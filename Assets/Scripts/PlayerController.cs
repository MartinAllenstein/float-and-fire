using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xRange = 10;

    public GameObject projectilePrefab;

    private float horizontalInput;

    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;

        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);
        
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (shootAction.triggered)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            AudioManager.Instance.PlayShoot();
        }
    }
}
