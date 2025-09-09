using System.Collections.Generic;
using UnityEngine;
class Barrel : MonoBehaviour
{
    [SerializeField] private float _explositionRadius;
    [SerializeField] private float _explositionForce;
    [SerializeField] private ParticleSystem _effect;

    private void OnMouseUpAsButton()
    {
        Explode();
        Instantiate(_effect, transform.position,transform.rotation);
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explositionForce, transform.position, _explositionRadius);
    }
    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explositionRadius);

        List<Rigidbody> barrels = new();

        foreach (Collider hit in hits)
            if(hit.attachedRigidbody != null)
                barrels.Add(hit.attachedRigidbody);

        return barrels;
        
            
        
    }
}
