using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MessageSystem : MonoBehaviour
{
    // メッセージを表示するテキスト
    [SerializeField] private TextMeshProUGUI messageText;
    // メッセージ表示全体を制御するCanvas
    [SerializeField] private GameObject messageCanvas;

    private string[] messages;      // 表示するメッセージの配列
    private int currentIndex = 0;   // 現在表示中のメッセージのインデックス

    // 選択肢用
    [SerializeField] private GameObject optionWindow;
    [SerializeField] private GameObject selectArrow;
    private bool nowSelect; // ture = yes, false = no

    /* 処理をコルーチンに変えたため使用せず
    private void Update()
    {
        // Canvasが非アクティブなら処理しない
        if (!messageCanvas.activeInHierarchy) return;

        // スペースキーが押されたかチェック
        // かつメッセージウィンドウ操作可能か
        if (Input.GetKeyDown(KeyCode.Space) && GameRoot.I.isActive_MWindow == true)
        {
            // 選択肢が表示されているなら回答を記録しオフに
            if (optionWindow.activeInHierarchy)
            {
                GameRoot.I.selected = nowSelect;
                optionWindow.SetActive(false);
            }
            // 次のメッセージへ進む
            NextMessage();
        }

        // 選択肢処理
        // optionWindowがアクティブなら
        if (optionWindow.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SelectMoveUp();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SelectMoveDown();
            }
        }
    }
    */

    // メッセージを表示する関数
    public IEnumerator ShowMessages(string[] messageArray)
    {
        // メッセージ表示の初期化処理
        GameRoot.I.isMessage = true;
        messageCanvas.SetActive(true);
        messages = messageArray;
        currentIndex = 0;

        // 最初のメッセージを表示
        if (messages.Length > 0)
        {
            //ShowText();
            messageText.text = messages[currentIndex];
        }
        else
        {
            // 配列が空の場合はここで終了
            messageCanvas.SetActive(false);
            GameRoot.I.isMessage = false;
            yield break;
        }

        // メッセージと選択肢の表示・入力を制限するメインループ
        while (currentIndex < messages.Length)
        {
            // 選択肢表示用の特殊なメッセージ
            if (messages[currentIndex] == "SHOW_YESNO_OPTIONS")
            {
                SelectOption();
                //currentIndex++;

                while (optionWindow.activeInHierarchy)
                {
                    // 上下キーで選択を変える
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        SelectMoveUp();
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        SelectMoveDown();
                    }

                    // スペースキーが押されたら選択を確定
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        GameRoot.I.selected = nowSelect;
                        optionWindow.SetActive(false);
                        // ループを抜けて次の処理へ
                    }

                    yield return null;
                }
            }
            else
            {
                // 通常のメッセージではスペースキーが押されるまで待機
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            }

            currentIndex++;

            // 次のメッセージがあれば表示
            if (currentIndex < messages.Length)
            {
                messageText.text = messages[currentIndex];
            }
        }

        // すべてのメッセージ表示が完了
        messageCanvas.SetActive(false);
        messages = null;
        GameRoot.I.isMessage = false;

        yield break;
    }

    /* 処理をコルーチンに変えたためShowMessages()と統合
    private void ShowText()
    {
        // 次のメッセージが選択肢表示なら
        if (messages[currentIndex] == "SHOW_YESNO_OPTIONS_HERE")
        {
            // 選択肢を呼び出す
            SelectOption();
            currentIndex++;
        }
        // 次のメッセージ表示
        messageText.text = messages[currentIndex];
    }
    */

    private void SelectOption()
    {
        Debug.Log("called function SelectOption");

        // 選択肢初期化（yes）
        nowSelect = true;
        optionWindow.SetActive(true);
    }

    /*
    private void NextMessage()
    {
        currentIndex++;

        // 次のメッセージが存在するかチェック
        if (currentIndex < messages.Length)
        {
            ShowText();
        }
        else
        {
            // 配列の終端に達したら非表示
            messageCanvas.SetActive(false);
            // 配列をクリア
            messages = null;

            GameRoot.I.isMessage = false;
        }
    }
    */

    private void SelectMoveUp()
    {
        if (!nowSelect)
        {
            selectArrow.transform.localPosition = new Vector3(50f, 10f, 0f);
            nowSelect = true;
        }
    }

    private void SelectMoveDown()
    {
        if (nowSelect)
        {
            selectArrow.transform.localPosition = new Vector3(50f, -28f, 0f);
            nowSelect = false;
        }

    }
}
