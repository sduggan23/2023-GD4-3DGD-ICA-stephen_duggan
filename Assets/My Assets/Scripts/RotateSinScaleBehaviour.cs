using UnityEngine;

public class RotateSinScaleBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis;           // The axis around which the object will rotate
    [SerializeField] private float rotationAngle;           // The angle at which the object will rotate
    [SerializeField]
    [Range(-0.5f, 0.5f)]
    private float scaleFactor;                              // The scale factor for oscillation

    private void FixedUpdate()
    {
        // Rotate the GameObject around the specified axis and angle in local space
        gameObject.transform.Rotate(rotationAxis, rotationAngle, Space.Self);
    }

    private void Update()
    {
        // Calculate scale based on a sin function with time
        var scale = scaleFactor * Mathf.Sin(Time.time) + 1;
        // Set the scale of the GameObject based on the calculated scale
        gameObject.transform.localScale = scale * Vector3.one;
    }
}