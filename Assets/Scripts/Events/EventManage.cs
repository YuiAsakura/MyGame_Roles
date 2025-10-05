using UnityEngine;
using System.Collections.Generic;

public class EventManage : MonoBehaviour
{
    // 処理済みのイベント回数等を記録するセット
    // 高速なためHashSetを用いる
    public HashSet<int> processedEventCounts = new HashSet<int>();
    public HashSet<int> processedObjectMove = new HashSet<int>();
    public HashSet<int> processedPlayerMove = new HashSet<int>();

    void Update()
    {
        Debug.Log($"🌟:{GameRoot.I.seeking} 👍:{GameRoot.I.decision} ❤:{GameRoot.I.sensitive} 💭:{GameRoot.I.patience} 🔎:{GameRoot.I.insight}");

        // イベント総実行回数に応じて個性値増加
        int currentEventCount = GameRoot.I.eventCount[0];
        if (!processedEventCounts.Contains(currentEventCount))
        {
            switch (currentEventCount)
            {
                case 5:
                case 10:
                case 15:
                case 20:
                case 25:
                    GameRoot.I.decision++;
                    GameRoot.I.insight++;
                    processedEventCounts.Add(currentEventCount);
                    break;
            }
        }

        // 木箱、樽のオブジェクトを動かした時間に応じて個性値増加
        int currentObjectMove = GameRoot.I.objectMove;
        if (!processedObjectMove.Contains(currentObjectMove))
        {
            switch (GameRoot.I.objectMove)
            {
                case 100:
                case 500:
                case 1000:
                case 1500:
                case 2000:
                    GameRoot.I.seeking++;
                    processedObjectMove.Add(currentObjectMove);
                    break;
            }
        }

        // プレイヤーが移動した時間に応じて個性値変化
        int currentPlayerMove = GameRoot.I.PlayerMove;
        if (!processedPlayerMove.Contains(currentPlayerMove))
        {
            switch (GameRoot.I.PlayerMove)
            {
                case 2000:
                case 4000:
                case 6000:
                case 8000:
                case 10000:
                    GameRoot.I.seeking++;
                    GameRoot.I.sensitive++;
                    processedPlayerMove.Add(currentPlayerMove);
                    break;
            }
        }
    }
}
