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
    }
}