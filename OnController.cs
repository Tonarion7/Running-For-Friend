using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnController : MonoBehaviour
{
    float speed = -5.5f;
    void Update()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            speed = speed * -1;
        }
    }
}
