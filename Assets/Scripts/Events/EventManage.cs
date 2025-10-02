using UnityEngine;

public class EventManage : MonoBehaviour
{
    void Update()
    {
        // イベント総実行回数に応じて個性値増加
        switch (GameRoot.I.eventCount[0])
        {
            case 5:
            case 10:
            case 15:
            case 20:
            case 25:
                GameRoot.I.decision++;
                GameRoot.I.insight++;
                break;
        }

        // 木箱、樽のオブジェクトを動かした時間に応じて個性値増加
        switch (GameRoot.I.objectMove)
        {
            case 100:
            case 500:
            case 1000:
            case 1500:
            case 2000:
                GameRoot.I.seeking++;
                break;
        }
        
    }
}
