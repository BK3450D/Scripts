using UnityEngine;

public class Granate : MonoBehaviour
{
    [SerializeField] private float _exposionRadius;
    [SerializeField] private float _exposionDelay;
    [SerializeField] Rigidbody _rigiBody;
    [SerializeField] ParticleSystem _effect;

    private void Update()
    {
        if (_exposionDelay <= 0f)
            ExpLode();

        _exposionDelay -= Time.deltaTime;
    }

    public void Throw(Vector3 force)
    {
        _rigiBody.AddForce(force);
    }

    private void ExpLode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _exposionRadius);
    
        foreach (Collider hit in hits )
        {
            if (hit.transform.TryGetComponent(out Block block))
                block.Destroy();
        }

        Instantiate(_effect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
