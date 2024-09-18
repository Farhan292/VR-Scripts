using UnityEngine;

public class ChangeBarrier : MonoBehaviour
{
    public Texture[] textures;
    private Renderer wallRenderer;
    private int currentIndex = 0;
    private bool canChangeTexture = true;
    private float textureChangeDelay = 1.0f;

    private void Start()
    {
        wallRenderer = GetComponent<Renderer>();

        if (wallRenderer != null && textures.Length > 0)
        {
            wallRenderer.material.mainTexture = textures[currentIndex];
        }
    }

    private void Update()
    {
        CheckForAxeCollision();
    }

    private void CheckForAxeCollision()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Axe"))
            {
                if (canChangeTexture)
                {
                    ChangeTexture();
                    StartCoroutine(TextureChangeDelay());
                }
                break;
            }
        }
    }

    private void ChangeTexture()
    {
        currentIndex = (currentIndex + 1) % textures.Length;
        if (wallRenderer != null && textures.Length > 0)
        {
            wallRenderer.material.mainTexture = textures[currentIndex];

            if (currentIndex == 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private System.Collections.IEnumerator TextureChangeDelay()
    {
        canChangeTexture = false;
        yield return new WaitForSeconds(textureChangeDelay);
        canChangeTexture = true;
    }
}
