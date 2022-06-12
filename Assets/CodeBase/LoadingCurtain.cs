using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCurtain : MonoBehaviour
{
    public CanvasGroup Curtain;
    private float _step = 0.03f;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        Curtain.alpha = 1;
    }

    public void Hide()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        while (Curtain.alpha > 0f)
        {
            Curtain.alpha -= _step;
            yield return new WaitForSeconds(_step);
        }

        gameObject.SetActive(false);
    }
}
