using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float movingSpeed = 5f;
    float jumpForce = 270.0f;
    int jump = 0;
    public AudioClip[] audioClip;
    AudioSource audioSource;
    public GameObject box;
    public GameObject die_effect;
    public GameObject item_effect;
    public GameObject clearObj;
    float SFX_Volume;
    bool is_Leftbutton = false;
    bool is_Rightbutton = false;
    bool is_Jumpbutton = false;
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    //왼쪽
    public void Left_ButtonUp()
    {
        is_Leftbutton = false;
    }
    public void Left_ButtonDown()
    {
        is_Leftbutton = true;
    }
    //오른쪽
    public void Right_ButtonUp()
    {
        is_Rightbutton = false;
    }
    public void Right_ButtonDown()
    {
        is_Rightbutton = true;
    }
    //점프
    
    public void Jump_ButtonDown()
    {
        is_Jumpbutton = true;
    }
    public void Jump_Button()
    {
        if (is_Jumpbutton == false)
        {
            is_Jumpbutton = true;
            audioSource.clip = audioClip[0];
            audioSource.Play();
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            animator.SetTrigger("Jump");
        }
    }
    //조작키
    void Update()
    {
        //왼쪽
        if (Input.GetKey(KeyCode.LeftArrow) || is_Leftbutton == true)
        {
            transform.Translate(new Vector3(movingSpeed * Time.deltaTime, 0, 0));
            transform.localEulerAngles = new Vector3(0, -180, 0);
            animator.SetBool("Run", true);
        }
        //오른쪽
        else if (Input.GetKey(KeyCode.RightArrow) || is_Rightbutton == true)
        {
            transform.Translate(new Vector3(movingSpeed * Time.deltaTime, 0, 0));
            transform.localEulerAngles = new Vector3(0, 0, 0);
            animator.SetBool("Run", true);
        }
        else 
        {
            animator.SetBool("Run", false);
        }


        //점프
        if (Input.GetKeyDown(KeyCode.Space) && jump == 0)
        {
            jump = 1;
            audioSource.clip = audioClip[0];
            audioSource.Play();
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            animator.SetTrigger("Jump");
            
        }
        SFX_Volume = PlayerPrefs.GetFloat("SFX");
        audioSource.volume = SFX_Volume;
    }

    //Trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        //죽었을 때
        if (collision.gameObject.CompareTag("die"))
        {
            audioSource.clip = audioClip[2];
            audioSource.Play();

            die_effect.SetActive(true);
            gameObject.SetActive(false);

        }
        //아이템
        else if (collision.gameObject.CompareTag("apple"))
        {
            collision.gameObject.SetActive(false);
            audioSource.clip = audioClip[3];
            audioSource.Play();
            item_effect.gameObject.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("launcher") && collision.gameObject.name == "R_Launcher")
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            this.rigid2D.AddForce(transform.right * 1500f);
        }
        else if(collision.gameObject.CompareTag("launcher") && collision.gameObject.name == "L_Launcher")
        {
            transform.Translate(new Vector3(-7f * Time.deltaTime, 0, 0));
        }
        //땅에 닿았을 때
        if (collision.gameObject.CompareTag("ground"))
        {
            jump = 0;
            jumpForce = 270;
            is_Jumpbutton = false;
        }
        if(collision.gameObject.CompareTag("high jump"))
        {
            jump = 0;
            jumpForce = 340f;
            is_Jumpbutton = false;
        }
        //벽에 닿았을 때
        if(collision.gameObject.CompareTag("side block"))
        {
            movingSpeed = 3.5f;
        }
        else
        {
            movingSpeed = 5f;
        }
        //클리어 창 띄우기
        if (collision.gameObject.CompareTag("clear") && SceneManager.GetActiveScene().name == "Map1")
        {
            if (GameManager.instance.time < GameManager.instance.minTime1)
            {
                GameManager.instance.minTime1 = GameManager.instance.time;
                PlayerPrefs.SetFloat("minTime1", GameManager.instance.minTime1);
            }
            clearObj.SetActive(true);
            Time.timeScale = 0;
        }
        //최고기록 저장
        //닿인 매개변수의 태그가 clear라면이고 현재 씬의 이름이 Map2라면
        //겜 매니저에서 흘러가는 시간이 데이터 메모리에 있는 기록보다 작다면
        //데이터 메모리 기록안에 겜 매니저의 시간을 넣는다.
        //데이터 메모리에 저장(이름: minTime2, minTime2에 있는 값을 저장)
        if (collision.gameObject.CompareTag("clear") && SceneManager.GetActiveScene().name == "Map2")
        {
            if (GameManager.instance.time < GameManager.instance.minTime2)
            {
                GameManager.instance.minTime2 = GameManager.instance.time;
                PlayerPrefs.SetFloat("minTime2", GameManager.instance.minTime2);
            }
            clearObj.SetActive(true);
            Time.timeScale = 0;
        }
        if (collision.gameObject.CompareTag("clear") && SceneManager.GetActiveScene().name == "Map3")
        {
            if (GameManager.instance.time < GameManager.instance.minTime3)
            {
                GameManager.instance.minTime3 = GameManager.instance.time;
                PlayerPrefs.SetFloat("minTime3", GameManager.instance.minTime3);
            }
            clearObj.SetActive(true);
            Time.timeScale = 0;
        }
    }
}