using UnityEngine;

public class ObjectScal: MonoBehaviour
{
    [SerializeField] private float _scale;

    private void Update()
    {
        transform.localScale += Vector3.one * _scale * Time.deltaTime;
    }
}
