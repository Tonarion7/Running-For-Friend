using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_BlockController : MonoBehaviour
{
    Animator animator;
    public GameObject break_block;
     
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PinkMan")
        {
            StartCoroutine(breakcourtine());
        }
    }
    IEnumerator breakcourtine()
    {
        break_block.GetComponent<Animator>().SetTrigger("break");
        yield return new WaitForSeconds(1.0f);
        break_block.gameObject.SetActive(false);
    }
}
