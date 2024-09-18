using UnityEngine;

public class KeepUpright : MonoBehaviour
{
    public float rotationThreshold = 0.1f;
    public float deadZone = 1.0f;

    private Quaternion lastRotation;

    private void FixedUpdate()
    {
        Quaternion currentRotation = transform.rotation;
        float angle = Quaternion.Angle(currentRotation, Quaternion.identity);

        if (angle > rotationThreshold && angle > deadZone)
        {
            Quaternion uprightRotation = Quaternion.Euler(0f, currentRotation.eulerAngles.y, 0f);
            transform.rotation = uprightRotation;
        }
        else
        {
            transform.rotation = lastRotation;
        }

        lastRotation = transform.rotation;
    }
}
