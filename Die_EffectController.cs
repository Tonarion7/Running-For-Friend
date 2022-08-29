using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die_EffectController : MonoBehaviour
{
    public GameObject Player;
    public AudioClip audioClip;
    public GameObject MainCamera;
    public GameObject Box1, Box2, Box3;
    AudioSource audioSource;
    float SFX_Volume;
    public GameObject playerPos;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;
        SFX_Volume = PlayerPrefs.GetFloat("SFX");
        audioSource.volume = SFX_Volume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("die"))
        {
            StartCoroutine(dieEffectcoroutine());
        }
    }

    IEnumerator dieEffectcoroutine()
    {
        audioSource.Play();
        yield return new WaitForSeconds(0.43f);
        //리스폰 위치 설정
        if(SceneManager.GetActiveScene().name == "Map1")
        {
            Player.transform.position = new Vector2(-5, 5);
            MainCamera.transform.position = new Vector3(Player.transform.position.x, 7, -10);
        }
        else if (SceneManager.GetActiveScene().name == "Map2")
        {
            Player.transform.position = new Vector2(108.5f, 3.6f);
            MainCamera.transform.position = new Vector3(Player.transform.position.x, 6.73f, -10);
        }
        else if (SceneManager.GetActiveScene().name == "Map3")
        {
            Player.transform.position = new Vector2(-20.86f, -1.64f);
            MainCamera.transform.position = new Vector3(Player.transform.position.x, 0.64f, -10);
        }
        Player.gameObject.SetActive(true);
        if(SceneManager.GetActiveScene().name == "Map3")
        {
            Player.transform.GetComponentInParent<PlayerController>().gameObject.transform.SetParent(playerPos.transform);
        }
        gameObject.SetActive(false);
    }
}
