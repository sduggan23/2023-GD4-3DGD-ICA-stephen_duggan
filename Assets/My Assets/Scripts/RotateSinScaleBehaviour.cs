using UnityEngine;

public class RotateSinScaleBehaviour : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationAxis;

    [SerializeField]
    private float rotationAngle;

    [SerializeField]
    [Range(-0.5f, 0.5f)]
    private float scaleFactor;

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(rotationAxis, rotationAngle, Space.Self);
    }

    private void Update()
    {
        var scale = scaleFactor * Mathf.Sin(Time.time) + 1;
        gameObject.transform.localScale = scale * Vector3.one;
    }
}