using UnityEngine;


public class GameRoot
{
    // 静的プロパティで唯一のインスタンスを提供
    public static GameRoot I { get; private set; } = new GameRoot();
    //public static GameRoot I { get; private set; }

    public float currentTime;

    // 状態管理用のbool変数
    public bool isMessage;  // メッセージ表示中
    public bool isEvent;    // イベント実行中

    // 状態に応じて変更し、操作可能かを判別するbool変数
    public bool isActive_Move;      // 移動可能
    public bool isActive_MWindow;   // Message Windowおよび選択

    // イベント管理用の変数
    public bool selected;       // yes or no
    public int nowLabel;        // イベント進行管理

    // 役職管理用の変数
    public string ThisRole;     // 診断した役職の結果
    public int seeking = 0, decision = 0, sensitive = 0, patience = 0, insight = 0;


    //private void Awake()
    //{
    //    if (I != null && I != this) { Destroy(gameObject); return; }
    //    I = this;
    //    DontDestroyOnLoad(gameObject);  // シーンをまたいで生存
    //}
}
