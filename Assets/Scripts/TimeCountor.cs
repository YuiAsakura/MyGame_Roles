using UnityEngine;
using TMPro;
using UnityEditor;

public class TimeCountor : MonoBehaviour
{
    [SerializeField] public float countdown = 60.0f;
    [SerializeField] private TextMeshProUGUI timeText;
    // timeoutか関数呼び出し時の判定用
    private bool timeout = false;

    void Update()
    {
        if (timeout == false)
        {
            // 時間をカウントダウンする
            countdown -= Time.deltaTime;

            // 時間を表示する
            timeText.text = "Time : " + countdown.ToString("f0") + " s";

            // countdownが0になったとき一度だけ呼び出す
            if (countdown <= 0)
            {
                timeText.text = "Time Out";
                // もう呼び出さないようにする
                timeout = true;
            }
        }
    }
}