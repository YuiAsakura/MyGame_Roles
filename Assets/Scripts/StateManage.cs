using UnityEngine;

public class StateManage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 状態の初期化
        // 管理する変数は以下
        GameRoot.I.isMessage = false;
        GameRoot.I.isEvent = false;
        GameRoot.I.isActive_Move = false;
        GameRoot.I.isActive_MWindow = false;
    }

    // Update is called once per frame
    void Update()
    {
        // イベントまたはメッセージが進行中の時、プレイヤー移動を無効化。両方offの時は有効化
        if (GameRoot.I.isMessage == false && GameRoot.I.isEvent == false)
        {
            GameRoot.I.isActive_Move = true;
        }
        else
        {
            GameRoot.I.isActive_Move = false;
        }

        // メッセージが進行中の時、メッセージウィンドウ操作を有効化
        GameRoot.I.isActive_MWindow = GameRoot.I.isMessage;

        //Debug.Log($"isMove:{GameRoot.I.isMove}  isMessage:{GameRoot.I.isMessage}  isEvent:{GameRoot.I.isEvent}");
    }
}
