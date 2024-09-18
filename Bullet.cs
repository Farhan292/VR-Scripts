using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Sword"))
            {
                Destroy(gameObject);

                break;
            }
        }
    }
}