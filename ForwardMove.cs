using UnityEngine;

public class ForwardMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Start() { }

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
}
