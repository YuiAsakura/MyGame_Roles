using UnityEngine;
using System.Collections;

// Event一覧を管理するスクリプト
// EventLaunchをアタッチした各オブジェクトに設定した関数が呼び出される
public class EventList : MonoBehaviour
{
    public MessageSystem messageSystem;

    private string[] eventMessage;
    public const string SHOW_YESNO_OPTIONS = "SHOW_YESNO_OPTIONS";

    public void StartEV01()
    {
        StartCoroutine(ev01bench());
    }

    private IEnumerator ev01bench()
    {
        eventMessage = new string[] {
            "ベンチだ。",
            SHOW_YESNO_OPTIONS,
            "ベンチで休みますか？\n時間を消費します",
        };

        // メッセージ表示コルーチンの完了を待つ
        yield return StartCoroutine(messageSystem.ShowMessages(eventMessage));
        Debug.Log("イベントメッセージ終了");

        // メッセージ表示が完了した後の処理
        if (GameRoot.I.selected)
        {
            eventMessage = new string[] { "休みました", "test" };
        }
        else
        {
            eventMessage = new string[] { "やめました", "test" };
        }
        Debug.Log(eventMessage[0]);
        yield return StartCoroutine(messageSystem.ShowMessages(eventMessage));

        GameRoot.I.isEvent = false;
    }
}
