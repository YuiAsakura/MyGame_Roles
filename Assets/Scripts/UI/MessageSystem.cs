using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MessageSystem : MonoBehaviour
{
    // 外部からアクセスできる唯一のインスタンス
    public static MessageSystem I { get; private set; }

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

    private void Awake()
    {
        // もしインスタンスがまだ存在しなければ、自身をインスタンスとして設定
        if (I == null)
        {
            I = this;
            // シーンをまたいでオブジェクトを維持する
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // すでにインスタンスが存在する場合は、新しいオブジェクトを破棄
            Destroy(this.gameObject);
        }
    }

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

    private void Update()
    {
        if (optionWindow.activeInHierarchy && GameRoot.I.isActive_MWindow)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                SelectMoveUp();
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                SelectMoveDown();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameRoot.I.selected = nowSelect;
                optionWindow.SetActive(false);
            }
        }
    }

    // メッセージを表示する関数
    public IEnumerator ShowMessages(string[] messageArray)
    {
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));

        // メッセージ表示の初期化処理
        GameRoot.I.isMessage = true;
        messageCanvas.SetActive(true);
        messages = messageArray;
        currentIndex = 0;

        // 配列が空の場合はここで終了
        if (messages.Length < 0)
        {
            messageCanvas.SetActive(false);
            GameRoot.I.isMessage = false;
            yield break;
        }

        // メッセージと選択肢の表示・入力を制限するメインループ
        while (currentIndex < messages.Length)
        {
            yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));

            // 選択肢表示用の特殊なメッセージ
            if (messages[currentIndex] == "SHOW_YESNO_OPTIONS")
            {   
                // 次のメッセージも表示
                currentIndex++;
                messageText.text = messages[currentIndex];

                // Debug.Log("yes or no");
                SelectOption();

                // 選択肢の入力が完了するまで待機
                yield return new WaitUntil(() => !optionWindow.activeInHierarchy);
            }
            else
            {
                messageText.text = messages[currentIndex];
                // 通常のメッセージではスペースキーが押されるまで待機
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) && GameRoot.I.isActive_MWindow);
            }

            currentIndex++;

            // 次のメッセージがあれば表示
            //if (currentIndex < messages.Length)
            //{
            //    messageText.text = messages[currentIndex];
            //}
        }

        // すべてのメッセージ表示が完了
        messageCanvas.SetActive(false);
        messages = null;
        messageText.text = null;
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
        // Debug.Log("called function SelectOption");

        // 選択肢初期化（yes）
        nowSelect = true;
        optionWindow.SetActive(true);
        // 矢印位置の初期化
        selectArrow.transform.localPosition = new Vector3(140f, 70f, 0f);
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
            selectArrow.transform.localPosition = new Vector3(140f, 70f, 0f);
            nowSelect = true;
        }
    }

    private void SelectMoveDown()
    {
        if (nowSelect)
        {
            selectArrow.transform.localPosition = new Vector3(140f, -5f, 0f);
            nowSelect = false;
        }

    }
}