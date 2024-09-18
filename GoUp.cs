using UnityEngine;

public class GoUp : MonoBehaviour
{
    public Transform xrRig;
    public Transform floor;
    public float targetHeight = 55f;
    public float triggerDistance = 5f;

    private bool hasBeenRaised = false;
    private Vector3 initialPosition; 
    private Vector3 newPos;

    private void Start()
    {
        initialPosition = xrRig.position;
    }

    private void Update()
    {
        if (!hasBeenRaised && Vector3.Distance(xrRig.position, floor.position) <= triggerDistance)
        {
            Vector3 newPosition = new Vector3(xrRig.position.x, floor.position.y + targetHeight, xrRig.position.z);
            xrRig.position = newPosition;
            newPos = xrRig.position;
            hasBeenRaised = true;
        }
        if (hasBeenRaised)
        {
            xrRig.position = newPos;
        }

    }
}
