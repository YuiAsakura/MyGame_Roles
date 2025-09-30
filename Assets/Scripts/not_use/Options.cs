using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] private GameObject optionWindow;
    [SerializeField] private GameObject selectArrow;

    private bool nowSelect; // ture = yes, false = no

    public void SelectOption()
    {
        Debug.Log("called function SelectOption");

        // 選択肢初期化（yes）
        nowSelect = true;
        optionWindow.SetActive(true);
    }

        private void Update()
    {
        // optionWindowが非アクティブなら処理しない
        if (!optionWindow.activeInHierarchy) return;

        Debug.Log("wait select");
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameRoot.I.selected = nowSelect;
            optionWindow.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectMoveUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SelectMoveDown();
        }
    }

    private void SelectMoveUp()
    {
        if (!nowSelect)
        {
            selectArrow.transform.localPosition = new Vector3(50f, 10f, 0f);
            nowSelect = true;
        }
    }

    private void SelectMoveDown()
    {
        if (nowSelect)
        {
            selectArrow.transform.localPosition = new Vector3(50f, -28f, 0f);
            nowSelect = false;
        }

    }

}