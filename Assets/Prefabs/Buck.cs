using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            return;
        rb.velocity = new Vector2(Random.Range(-500f, 500f), Random.Range(500f, 900f));
        rb.angularVelocity = Random.Range(0f, 800f) * (Random.value > 0.5f ? 1 : -1);
    }
    void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x < -100 || screenPosition.x > Screen.width+100 || screenPosition.y < -100 || screenPosition.y > Screen.height+100)
        {
            Destroy(gameObject);
        }

    }
}
