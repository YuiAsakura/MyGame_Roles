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
            "硬そうな石のベンチだ。",
            SHOW_YESNO_OPTIONS,
            "ベンチで休みますか？\n時間を消費します",
        };

        // メッセージ表示コルーチンの完了を待つ
        yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));

        // メッセージ表示が完了した後の処理
        if (GameRoot.I.selected)
        {
            if (GameRoot.I.currentTime >= 10)
            {
                eventMessage = new string[] { "落ち着いた気分になった" };
                GameRoot.I.sensitive += 2;
                GameRoot.I.patience += 5;
                GameRoot.I.currentTime -= 10;
            }
            else
            {
                eventMessage = new string[] { "ゆっくりできる時間はなさそうだ" };
            }
        }
        else
        {
            eventMessage = new string[] { "やめておこう" };
        }

        yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));
        GameRoot.I.isEvent = false;
    }

    private IEnumerator ev02chest()
    {
        eventMessage = new string[] {
            "ふたが外れかけている宝箱がある",
            SHOW_YESNO_OPTIONS,
            "開けてみようか？"
        };
        yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));

        // 選択結果に応じて分岐
        if (!GameRoot.I.selected)
        {
            eventMessage = new string[] { "触らないでおいた" };
            yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));
            GameRoot.I.decision += 1;
            GameRoot.I.insight += 3;
            // 処理を終了
            yield break;
        }

        eventMessage = new string[] { SHOW_YESNO_OPTIONS, "...中身はミミックかもしれない。\n本当に開けますか？" };
        yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));

        if (!GameRoot.I.selected)
        {
            eventMessage = new string[] { "やっぱりやめておこう" };
            yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));
            GameRoot.I.insight += 2;
            GameRoot.I.patience += 2;
            // 処理を終了
            yield break;
        }

        eventMessage = new string[] { "中身は空っぽだった。\n誰かに開けられた後のようだ" };
        yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));
        GameRoot.I.seeking += 2;
        GameRoot.I.decision += 2;
        
        GameRoot.I.isEvent = false;
    }
}
