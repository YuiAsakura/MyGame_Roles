using UnityEngine;

public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance { get; private set;}

    private void Awake()
    {
        if (Instance == null)
        {
            // 自身をインスタンスとする
            Instance = this;
        }
        else
        {
            // インスタンスが複数存在しないように、既に存在していたら自身を消去する
            Destroy(GameRoot);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
