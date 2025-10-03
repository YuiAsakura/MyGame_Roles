using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private Image fadePanel;           // フェードパネル
    [SerializeField] private float fadeSpeed = 1.0f;    // フェードの速さ

    public IEnumerator EventWaitFade()
    {
        // 画面が半分隠れるまでフェードアウト
        yield return StartCoroutine(Fade(0.5f));

        float waitStartTime = Time.time;
        // 何かしらのキーが押されるまで待機
        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        float waitTime = Time.time - waitStartTime;
        Debug.Log($"キーが押されるまでの時間: {waitTime} 秒");

        // フェードイン開始
        yield return StartCoroutine(Fade(0f));

        // 待機時間を返す
        yield return waitTime;
    }

    private IEnumerator Fade(float targetAlpha)
    {
        // フェードする透過度を設定
        float currentAlpha = fadePanel.color.a;

        while (!Mathf.Approximately(currentAlpha, targetAlpha))
        {
            currentAlpha = Mathf.MoveTowards(currentAlpha, targetAlpha, fadeSpeed * Time.deltaTime);
            fadePanel.color = new Color(0, 0, 0, currentAlpha);
            yield return null;
        }

        fadePanel.color = new Color(0, 0, 0, targetAlpha);
    }
}
