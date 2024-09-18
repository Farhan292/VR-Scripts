using UnityEngine;

public class GemManager : MonoBehaviour
{
    public Transform wall;
    public Transform emerald;
    public Transform ruby;
    public Transform emeraldPlaceholder;
    public Transform rubyPlaceholder;

    private bool decreasingWall = false;
    private Vector3 initialWallPosition;
    private float decreaseDuration = 3f;
    private float decreaseStartTime;
    private float positionThreshold = 0.1f;

    private void Start()
    {
        initialWallPosition = wall.position;
    }

    private void Update()
    {
        if (Vector3.Distance(emerald.position, emeraldPlaceholder.position) < positionThreshold &&
            Vector3.Distance(ruby.position, rubyPlaceholder.position) < positionThreshold &&
            !decreasingWall)
        {
            StartDecreaseWall();
        }
        if (decreasingWall)
        {
            float elapsedTime = Time.time - decreaseStartTime;
            float t = Mathf.Clamp01(elapsedTime / decreaseDuration);
            float newY = Mathf.Lerp(initialWallPosition.y, initialWallPosition.y - 3f, t);
            wall.position = new Vector3(wall.position.x, newY, wall.position.z);

            if (t >= 1f)
            {
                Destroy(wall.gameObject);
                decreasingWall = false;
            }
        }
    }

    private void StartDecreaseWall()
    {
        decreasingWall = true;
        decreaseStartTime = Time.time;
    }
}
