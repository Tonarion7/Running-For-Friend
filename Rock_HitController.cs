using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_HitController : MonoBehaviour
{
    bool reach = false;
    float speed = -15f;
    Animator animator;
    Rigidbody2D rigid2D;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reach == false)
        {
            transform.Translate(new Vector2(0, speed * Time.deltaTime));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground") && reach == false)
        {
            animator.SetTrigger("Falled");
            reach = true;
            StartCoroutine(rockcourtine());
            Debug.Log("ground");
        }
        else if (collision.gameObject.CompareTag("high wall") && reach == false)
        {
            reach = true;
            StartCoroutine(rockcourtine());
            Debug.Log("high wall");
        }
    }
    IEnumerator rockcourtine()
    {
        if(speed < 0)
            speed = 5;
        else if (speed > 0)
            speed = -15;
        yield return new WaitForSeconds(1.5f);
        reach = false;
        Debug.Log("false");
    } 
}
