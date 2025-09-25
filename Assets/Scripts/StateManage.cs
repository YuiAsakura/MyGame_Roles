using UnityEngine;

public class StateManage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの操作状態を監視
        if (GameRoot.I.isMove == false)     // 制限中なら状態により解除
        {
            if (GameRoot.I.isMessage == false && GameRoot.I.isEvent == false && GameRoot.I.isItem == false)
            {
                GameRoot.I.isMove = true;
            }
        }
        else
        {
            if (GameRoot.I.isMessage == true || GameRoot.I.isEvent == true || GameRoot.I.isItem == true)
            {
                GameRoot.I.isMove = false;
            }
        }
        Debug.Log($"isMove:{GameRoot.I.isMove}  isMessage:{GameRoot.I.isMessage}  isEvent:{GameRoot.I.isEvent}");
    }
}
