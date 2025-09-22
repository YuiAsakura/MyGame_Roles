using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;
using System;   // Actionデリゲートを使うために必要

public class TimeCounter : MonoBehaviour
{
    // 時間切れを通知するためのイベントを定義
    // このイベントに、時間切れになったときに実行したいメソッドを登録する
    public event Action OnTimeUp;

    [SerializeField] public float timeLimit = 60f;
    private float currentTime;
    private bool isTimeUp = false;

    [SerializeField] private TextMeshProUGUI timeText;
    string ResultSceneName = "ResultScene";

    private void Start()
    {
        currentTime = timeLimit;
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            // 時間をカウントダウンする
            currentTime -= Time.deltaTime;

            // 時間を表示する
            timeText.text = "Time : " + currentTime.ToString("f0") + " s";

            if (currentTime <= 0)
            {
                currentTime = 0;
                //timeText.text = "Time Out";
                // 時間が0になったら一度だけ処理を実行
                if (!isTimeUp)
                {
                    isTimeUp = true;
                    LoadResult();
                    //イベントに登録された外部のメソッドを呼び出す
                    OnTimeUp?.Invoke();
                }
            }
        }
    }

    private void LoadResult()
    {
        // リザルトシーン呼び出し
        SceneManager.LoadScene(ResultSceneName);
        gameObject.SetActive(false);
    }
}