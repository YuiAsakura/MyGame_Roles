using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageSystem : MonoBehaviour
{
    // メッセージを表示するテキスト
    [SerializeField] private TextMeshProUGUI messageText;
    // メッセージ表示全体を制御するCanvas
    [SerializeField] private GameObject messageCanvas;

    private string[] messages;      // 表示するメッセージの配列
    private int currentIndex = 0;   // 現在表示中のメッセージのインデックス

    // メッセージを表示する関数
    public void ShowMessages(string[] messageArray)
    {
        // Canvasをアクティブにする
        messageCanvas.SetActive(true);

        // 外部から渡されたメッセージ配列を格納
        messages = messageArray;
        currentIndex = 0;

        // 最初のメッセージを表示
        if (messages.Length > 0)
        {
            messageText.text = messages[currentIndex];
        }
        else
        {
            // 配列が空の場合は非表示にする
            messageCanvas.SetActive(false);
        }
    }

    private void Update()
    {
        // Canvasが非アクティブなら処理しない
        if (!messageCanvas.activeInHierarchy) return;

        // スペースキーが押されたかチェック
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 次のメッセージへ進む
            NextMessage();
        }
    }

    private void NextMessage()
    {
        currentIndex++;

        // 次のメッセージが存在するかチェック
        if (currentIndex < messages.Length)
        {
            // 次のメッセージを表示
            messageText.text = messages[currentIndex];
        }
        else
        {
            // 配列の終端に達したら非表示
            messageCanvas.SetActive(false);
            // 配列をクリア
            messages = null;
        }
    }
}
