using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScManager : MonoBehaviour
{
    public GameObject clear;
    public Image fadeinObj;
    public GameObject setting;
    public GameObject best_record;
    public GameObject developer_message;
    float FadeCount = 0;
    float BGM_Volume = 1;
    float SFX_Volume = 1;
    public Slider BGM_soundSlider;
    public Slider SFX_soundSlider;

    private void Start()
    {
        BGM_Volume = PlayerPrefs.GetFloat("BGM", 0.5f);
        SFX_Volume = PlayerPrefs.GetFloat("SFX", 0.5f);
        fadeinObj.gameObject.SetActive(false);
    }

    public void startgame()
    {
        StartCoroutine(FadeInCoroutine("Map_Select"));
    }
    public void menu_rank()
    {
        best_record.SetActive(true);
    }
    public void rank_close()
    {
        best_record.SetActive(false);
    }
    public void go_menu()
    {
        StartCoroutine(FadeInCoroutine("Menu"));
        Time.timeScale = 1;
    }
    public void menu_message()
    {
        developer_message.SetActive(true);
    }
    public void message_close()
    {
        developer_message.SetActive(false);
    }
    //세팅
    public void go_setting()
    {
        setting.SetActive(true);
        Time.timeScale = 0;
    }
    public void resume()
    {
        setting.SetActive(false);
        Time.timeScale = 1;
    }
    public void apply ()
    {
        BGM_Volume = BGM_soundSlider.value;
        SFX_Volume = SFX_soundSlider.value;
        PlayerPrefs.SetFloat("BGM", BGM_Volume);
        PlayerPrefs.SetFloat("SFX", SFX_Volume);
    }
    //맵 선택
    public void map1Button()
    {
        StartCoroutine(FadeInCoroutine("Map1"));
        Time.timeScale = 1;
    }
    public void map2Button()
    {
        StartCoroutine(FadeInCoroutine("Map2"));
        Time.timeScale = 1;
    }
    public void map3Button()
    {
        StartCoroutine(FadeInCoroutine("Map3"));
        Time.timeScale = 1;
    }

    //FadeIn 및 SceneLoad
    IEnumerator FadeInCoroutine(string select)
    {
        fadeinObj.gameObject.SetActive(true);
        while (FadeCount < 1.0f)
        {
            FadeCount += 0.01f;
            fadeinObj.color = new Color(0, 0, 0, FadeCount);
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene(select);
    }
}
