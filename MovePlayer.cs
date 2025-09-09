using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private readonly string Horizontal = "Horizontal";
    private readonly string Vertical = "Vertical";

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _orientation;

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical));

        Vector3 moveDirection = _orientation.TransformDirection(input).normalized;

        transform.Translate(_moveSpeed * Time.deltaTime * moveDirection, Space.World);
    }
}
