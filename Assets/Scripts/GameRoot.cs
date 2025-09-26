using UnityEngine;


public class GameRoot
{
    // 静的プロパティで唯一のインスタンスを提供
    public static GameRoot I { get; private set; } = new GameRoot();
    //public static GameRoot I { get; private set; }

    // 状態管理用のbool変数
    public bool isMove = false;     // 操作中
    public bool isMessage = false;  // メッセージ表示中
    public bool isEvent = false;    // イベント実行中
    public bool isItem = false;     // アイテム表示中

    public string ThisRole;
    public bool selected;

    //private void Awake()
    //{
    //    if (I != null && I != this) { Destroy(gameObject); return; }
    //    I = this;
    //    DontDestroyOnLoad(gameObject);  // シーンをまたいで生存
    //}
}
