using UnityEngine;


public class GameRoot
{
    // 静的プロパティで唯一のインスタンスを提供
    public static GameRoot I { get; private set; } = new GameRoot();
    //public static GameRoot I { get; private set; }
    public string ThisRole;

    //private void Awake()
    //{
    //    if (I != null && I != this) { Destroy(gameObject); return; }
    //    I = this;
    //    DontDestroyOnLoad(gameObject);  // シーンをまたいで生存
    //}
}
