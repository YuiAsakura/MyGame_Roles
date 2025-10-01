using UnityEngine;
using System.Collections;

// Event一覧を管理するスクリプト
// EventLaunchをアタッチした各オブジェクトに設定した関数が呼び出される
public class EventList : MonoBehaviour
{
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
        //MessageSystem.I.ShowMessages(eventMessage);

        // メッセージ表示コルーチンの完了を待つ
        yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));
        Debug.Log("イベントメッセージ終了");

        // メッセージ表示が完了した後の処理
        if (GameRoot.I.selected)
        {
            if (GameRoot.I.currentTime >= 10)
            {
                eventMessage = new string[] { "休みました" };
                GameRoot.I.sensitive += 3;
                GameRoot.I.currentTime -= 10;
            }
            else
            {
                eventMessage = new string[] { "時間が足りません" };
            }
        }
        else
        {
            eventMessage = new string[] { "やめました" };
        }
        //Debug.Log(eventMessage[0]);
        yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));
        GameRoot.I.isEvent = false;
    }
}
