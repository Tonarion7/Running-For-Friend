using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_BlockController : MonoBehaviour
{
    float moving_speed = 3f;
    GameObject playerPos;
    // Start is called before the first frame update

    // Update is called once per frame  

    private void Start()
    {
        playerPos = GameObject.Find("Player");
    }
    void Update()
    {
        transform.Translate(new Vector3(moving_speed * Time.deltaTime, 0, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("moving_block_wall"))
        {
            moving_speed *= -1;
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponentInParent<PlayerController>().gameObject.transform.SetParent(gameObject.transform);  
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Destroy(gameObject.transform.FindChild("PinkMan"));
            collision.transform.GetComponentInParent<PlayerController>().gameObject.transform.SetParent(playerPos.transform);
        }
    }
}
