using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgroundController : MonoBehaviour
{
    float speed = 3;
    float star_speed1 = 0.01f;
    float star_speed2 = 0.01f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Menu_Background")
        {
            if (gameObject.transform.position.y < -7 || gameObject.transform.position.y > 7)
            {
                speed = speed * -1;
            }
            transform.Translate(new Vector2(0, speed * Time.deltaTime));
        }
        if(gameObject.name == "Star")
        {
            transform.Translate(new Vector2(star_speed2, star_speed1));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            if (star_speed1 == star_speed2)
            {
                star_speed1 = star_speed1 * -1;
            }
            else
            {
                star_speed2 = star_speed2 * -1;
            }
        }
    }
}
