using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagDirector : MonoBehaviour
{
    Animator animator;
    public GameObject PinkMan;
    public AudioClip[] audioClip;
    public GameObject MainCamera;
    AudioSource audioSource;
    int box_opened = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, PinkMan.gameObject.transform.position) < 1)
        {
            //Map1
            if (gameObject.name == "Flag1")
            {
                PinkMan.transform.position = new Vector2(-6, -8);
                MainCamera.transform.position = new Vector3(1f, -5.3f, -10f);
            }
            else if (gameObject.name == "Flag2")
            {
                PinkMan.transform.position = new Vector2(-7.5f, -23.5f);
                MainCamera.transform.position = new Vector3(1f, -20f, -10f);
            }
            else if (gameObject.name == "Flag3")
            {
                PinkMan.transform.position = new Vector2(-7f, -40.85f);
                MainCamera.transform.position = new Vector3(1f, -37.83f, -10f);
            }
            else if (gameObject.name == "Flag4")
            {
                PinkMan.transform.position = new Vector2(-7.2f, -56.97f);
                MainCamera.transform.position = new Vector3(1f, -53.78f, -10f);
            }
            //Map2
            else if (gameObject.name == "Flag5")
            {
                PinkMan.transform.position = new Vector2(107.87f, -9.46f);
                MainCamera.transform.position = new Vector3(1f, -6.77f, -10f);
            }
            else if (gameObject.name == "Flag6")
            {
                PinkMan.transform.position = new Vector2(107.78f, -18.35f);
                MainCamera.transform.position = new Vector3(1f, -20.73f, -10f);
            }
            else if (gameObject.name == "Flag7")
            {
                PinkMan.transform.position = new Vector2(107.97f, -41.52f);
                MainCamera.transform.position = new Vector3(1f, -38.87f, -10f);
            }
            else if (gameObject.name == "Flag8")
            {
                PinkMan.transform.position = new Vector2(107.42f, -57.15f);
                MainCamera.transform.position = new Vector3(1f, -54.27f, -10f);
            }
            //Map3
            else if(gameObject.name == "Flag9")
            {
                PinkMan.transform.position = new Vector2(-22.21f, -14.15f);
                MainCamera.transform.position = new Vector3(1f, -17.6f, -10f); 
            }
            else if (gameObject.name == "Flag10")
            {
                PinkMan.transform.position = new Vector2(29.88f, -31.67f);
                MainCamera.transform.position = new Vector3(1f, -35.12f, -10f);
            }
            else if (gameObject.name == "Flag11")
            {
                PinkMan.transform.position = new Vector2(-23.7f, -53.5f);
                MainCamera.transform.position = new Vector3(1f, -53.6f, -10f);
            }
            else if (gameObject.name == "Flag12")
            {
                PinkMan.transform.position = new Vector2(-24.75f, -76.83f);
                MainCamera.transform.position = new Vector3(1f, -73.3f, -10f);
            }
            audioSource.clip = audioClip[0];
            audioSource.Play();
        }
        
    }
}