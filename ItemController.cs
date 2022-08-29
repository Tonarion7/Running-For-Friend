using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public GameObject item_effect;
    public GameObject apple;
    public GameObject dead_line;
    public GameObject Player;
    int item_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        //item_effect.transform.position = apple.transform.position;
        //if(apple.gameObject.activeSelf == false)
        //{
        //    if (item_count == 0)
        //    {
        //        StartCoroutine(ItemEffectcoroutine());
        //        item_count++;
        //    }
        //    Item_Appear();
        //}
    }
    void Item_Appear()
    {
        if (Player.gameObject.activeSelf == false)
        {
            apple.gameObject.SetActive(true);
        }
    }
    IEnumerator ItemEffectcoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        item_effect.gameObject.SetActive(false);
        item_count--;
    }
}
