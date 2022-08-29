using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbController : MonoBehaviour
{
    bool stay = false;
    float y = 2f;
    void Update()
    {
        if (stay == false && gameObject.name == "Climb_Up")
        {
            transform.Translate(new Vector3(0, y*Time.deltaTime, 0));
        }
        else if(stay == false && gameObject.name == "Climb_Down")
        {
            transform.Translate(new Vector3(0, -y* Time.deltaTime, 0));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            y = y * -1;
            stay = true;
            StartCoroutine(climbcourtine());
        }
    }
    IEnumerator climbcourtine()
    {
        yield return new WaitForSeconds(2.0f);
        stay = false;
    }
}
