using UnityEngine;

public class MoveObjectEvent : MonoBehaviour
{
    void Update()
    {
        if (transform.hasChanged)
        {
            GameRoot.I.objectMove++;
            Debug.Log("move:" + GameRoot.I.objectMove);

            // 変更フラグをクリア
            transform.hasChanged = false;
        }

        // オブジェクトを動かした時間に応じてステータス変化
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