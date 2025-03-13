using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public TMP_Text loadingScreenText;
    public GameObject loadingScreenBar;
    private string[] loadingTexts = { "Loading", "Loading.", "Loading..", "Loading..." };
    public TMP_Text loadingScreenTip;
    private string[] loadingTips = { "Tip: You can open your inventory by pressing I",
    "Tip: You can interact with NPCs by pressing F" };
    private int randomValueTip;
    private float randomValueTime;
    private float randomValueTipTime;
    int ltext = 0;
    void Start()
    {
        loadingScreenBar.transform.localScale = new Vector3(0, loadingScreenBar.transform.localScale.y, loadingScreenBar.transform.localScale.z);
        loadingScreenText.text = loadingTexts[0];
        loadingScreenTip.text = "";
        randomValueTime = Random.Range(60, 120);
        RandomTip();
        loadingScreenTip.text = loadingTips[randomValueTip];
        StartCoroutine(AnimationLoadingBar());
    }

    void Update()
    {
        if (randomValueTipTime <= Time.time)
        {
            RandomTip();
            loadingScreenTip.text = loadingTips[randomValueTip];
        }
    }

    void RandomTip()
    {
        randomValueTip = Random.Range(0, loadingTips.Length);
        randomValueTipTime = Time.time + Random.Range(5, 10);
    }

    IEnumerator AnimationLoadingBar()
    {
        float initialScaleX = loadingScreenBar.transform.localScale.x;
        float targetScaleX = 1f;
        float scaleIncrement = (targetScaleX - initialScaleX) / randomValueTime;
        float textUpdateInterval = 0.5f;
        float nextTextUpdateTime = Time.time + textUpdateInterval;

        while (randomValueTime > 0)
        {
            randomValueTime--;
            yield return new WaitForSecondsRealtime(Random.Range(0.1f, 1f));
            if (Time.time >= nextTextUpdateTime)
            {
                loadingScreenText.text = loadingTexts[ltext];
                ltext = (ltext + 1) % loadingTexts.Length;
                nextTextUpdateTime = Time.time + textUpdateInterval;
            }

            loadingScreenBar.transform.localScale = new Vector3(loadingScreenBar.transform.localScale.x + scaleIncrement, loadingScreenBar.transform.localScale.y, loadingScreenBar.transform.localScale.z);
        }
        SceneManager.LoadScene("StartGame-0");
    }
}
