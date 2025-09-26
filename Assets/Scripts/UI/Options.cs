using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] private GameObject optionWindow;
    [SerializeField] private GameObject selectArrow;

    private bool nowSelect; // ture = yes, false = no

    public bool SelectOption()
    {
        Debug.Log("called function SelectOption");

        // 選択肢初期化（yes）
        nowSelect = true;
        optionWindow.SetActive(true);

        // 以下の文は簡潔にしたい
        while (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("wait select");
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SelectMoveUp();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SelectMoveDown();
            }
        }

        optionWindow.SetActive(false);
        // 選択結果を返す（true = yes, false = no）
        return nowSelect;
    }

    private void SelectMoveUp()
    {
        if (!nowSelect)
        {
            selectArrow.transform.position = new Vector3(50f, 10f, 0f);
        }
    }

    private void SelectMoveDown()
    {
        if (nowSelect)
        {
            selectArrow.transform.position = new Vector3(50f, -28f, 0f);
        }

    }

}