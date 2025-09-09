using UnityEngine;

public class Looking : MonoBehaviour
{
    private readonly string MouseX = "Mouse X";
    private readonly string MouseY = "Mouse Y";

    [SerializeField] private float _speed;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _body;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        _camera.Rotate(_speed * -Input.GetAxis(MouseY) * Time.deltaTime * Vector3.right);
        _body.Rotate(_speed * Input.GetAxis(MouseX) * Time.deltaTime * Vector3.up);

        // Example: unlock cursor on Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
