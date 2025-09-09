using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private Granate _grenadePrefab;
    [SerializeField] private float _throwForce;
    [SerializeField] Transform _throwPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            Instantiate(_grenadePrefab, _throwPoint.position, _throwPoint.rotation).Throw(_throwPoint.forward * _throwForce);

    }
}
