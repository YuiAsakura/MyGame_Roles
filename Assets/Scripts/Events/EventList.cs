using UnityEngine;
using System.Collections;
using System;

// Event一覧を管理するスクリプト
// EventLaunchをアタッチした各オブジェクトに設定した関数が呼び出される
public class EventList : MonoBehaviour
{
    private string[] eventMessage;
    public const string SHOW_YESNO_OPTIONS = "SHOW_YESNO_OPTIONS";

    // イベントカウントの配列要素を増加させる
    private void addeventCount(int eventNum)
    {
        if (eventNum >= GameRoot.I.eventCount.Length)
        {
            // 配列サイズを2まで増加
            Array.Resize(ref GameRoot.I.eventCount, eventNum + 1);
        }
        GameRoot.I.eventCount[eventNum]++;
    }

    /* ここからイベント起動用の関数 */
    public void StartEV01()
    {
        addeventCount(1);
        StartCoroutine(ev01bench());
    }

    public void StartEV02()
    {
        addeventCount(2);
        StartCoroutine(ev02chest());
    }

    public void StartEV03()
    {
        addeventCount(3);
        StartCoroutine(ev03monument());
    }

    public void StartEv04()
    {
        addeventCount(4);
        StartCoroutine(ev04pray());
    }

    /* ここからイベント本体の関数 */
    private IEnumerator ev01bench()
    {
        eventMessage = new string[] {
            "硬そうな石のベンチだ。",
            SHOW_YESNO_OPTIONS,
            "ベンチで休みますか？\n時間を消費します。",
        };

        // メッセージ表示コルーチンの完了を待つ
        yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));

        // メッセージ表示が完了した後の処理
        if (GameRoot.I.selected)
        {
            if (GameRoot.I.currentTime >= 10)
            {
                eventMessage = new string[] { "落ち着いた気分になった。" };
                GameRoot.I.sensitive += 2;
                GameRoot.I.patience += 5;
                GameRoot.I.currentTime -= 10;
            }
            else
            {
                eventMessage = new string[] { "ゆっくりできる時間はなさそうだ...。" };
            }
        }
        else
        {
            eventMessage = new string[] { "やめておこう。" };
        }

        yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));
        GameRoot.I.isEvent = false;
    }

    private IEnumerator ev02chest()
    {
        eventMessage = new string[] {
            "ふたが外れかけている宝箱がある。",
            SHOW_YESNO_OPTIONS,
            "開けてみようか？"
        };
        yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));

        // 選択結果に応じて分岐
        if (!GameRoot.I.selected)
        {
            eventMessage = new string[] { "触らないでおいた。" };
            yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));
            GameRoot.I.decision += 1;
            GameRoot.I.insight += 3;
            // イベントを終了
            GameRoot.I.isEvent = false;
            yield break;
        }

        eventMessage = new string[] { SHOW_YESNO_OPTIONS, "...中身はミミックかもしれない。\n本当に開けますか？" };
        yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));

        if (!GameRoot.I.selected)
        {
            eventMessage = new string[] { "やっぱりやめておこう。" };
            yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));
            GameRoot.I.insight += 2;
            GameRoot.I.patience += 2;
            // イベントを終了
            GameRoot.I.isEvent = false;
            yield break;
        }

        eventMessage = new string[] { "中身は空っぽだった。\n誰かに開けられた後のようだ。" };
        yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));
        GameRoot.I.seeking += 2;
        GameRoot.I.decision += 2;

        GameRoot.I.isEvent = false;
    }

    private IEnumerator ev03monument()
    {
        Debug.Log("event03");
        eventMessage = new string[] { "刻まれた文字が青く光っている石碑だ。\n不思議な力を感じる...。" };
        yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));
        GameRoot.I.sensitive += 1;
        GameRoot.I.patience += 1;

        GameRoot.I.isEvent = false;
    }

    private IEnumerator ev04pray()
    {
        eventMessage = new string[] {
            "神聖なたたずまいをしている女性の銅像がある。",
            SHOW_YESNO_OPTIONS,
            "祈りますか？"
        };

        yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));

        if (GameRoot.I.selected)
        {
            // ScreenFaderのインスタンスを取得（GameObject.Find()は非推奨ですが、ここでは簡潔さのために使用）
            // EventManageのようなシングルトンクラスにScreenFaderをアタッチするのが理想的らしい
            // そのうち調整したい
            ScreenFader screenFader = FindObjectOfType<ScreenFader>();
            if (screenFader == null)
            {
                Debug.LogError("Fader コンポーネントが見つかりません。");
                GameRoot.I.isEvent = false;
                yield break;
            }

            // フェードアウトとキー入力待機を実行し、時間を取得
            StartCoroutine(screenFader.EventWaitFade());

            // 時間に応じて個性値変更
            if (GameRoot.I.waitedTime < 2.0f)
            {
                GameRoot.I.decision += 2;
            }
            else if (GameRoot.I.waitedTime < 5.0f)
            {
                GameRoot.I.sensitive += 3;
            }
            else
            {
                GameRoot.I.patience += 5;
            }
        }
        else
        {
            eventMessage = new string[] { "やめておこう。" };
            yield return StartCoroutine(MessageSystem.I.ShowMessages(eventMessage));
            GameRoot.I.decision += 1;
            GameRoot.I.insight += 1;
        }

        // イベント終了処理
        GameRoot.I.isEvent = false;

    }
}
