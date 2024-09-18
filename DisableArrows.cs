using UnityEngine;

public class DisableArrows : MonoBehaviour
{
    public Transform wall;
    public Transform sapphire;
    public Transform sapphirePlaceholder;
    public GameObject[] arrows; 
    public float positionThreshold = 0.1f;
    public float decreaseDuration = 3f;

    private bool decreasingWall = false;
    private Vector3 initialWallPosition;
    private float decreaseStartTime;

    private void Start()
    {
        initialWallPosition = wall.position;
    }

    private void Update()
    {
        if (Vector3.Distance(sapphire.position, sapphirePlaceholder.position) < positionThreshold &&
            !decreasingWall)
        {
            disableArrows();
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

    private void disableArrows()
    {
        foreach (GameObject arrow in arrows)
        {
            arrow.SetActive(false);
        }
    }
}
