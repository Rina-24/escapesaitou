using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TresureBoxCodeControlller : MonoBehaviour
{
    [SerializeField]
    int[] Answer = { };

    [SerializeField]
    CodePanel[] codePanels = default;

    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private GameObject NewPanel;
    [SerializeField]
    private GameObject getItem;

    [SerializeField]
    private AudioSource successSE;

    [SerializeField]
    private AudioSource failureSE;

    private bool birdClear = false;

    void Start()
    {
        if (birdClear == true)
        {
            int BirdTresureBoxOpen = GameSaveData.Instance.GetGameFlag("BirdTresureBoxOpen");
            ClosePanel();
            ChangePanel();
            GetItem();
        }

    }
    public void OnClickButton()
    {
        Debug.Log("ボタン検知");
        if (CheckClear())
        {
            // 成功時のSEを再生
            if (successSE != null)
            {
                successSE.Play();
            }
            Debug.Log("Clear");
            birdClear = true;

            // 正解の場合、他のパネルを非アクティブにする
            ClosePanel();
            // 宝箱の画像を変更しアイテムゲット
            ChangePanel();
            GetItem();

            // セーブデータにクリアフラグを設定
            GameSaveData.Instance.SetGameFlag("BirdTresureBoxOpen", 1);

        }
    }

    bool CheckClear()
    {
        for (int i = 0; i < codePanels.Length; i++)
        {
            if (codePanels[i].number != Answer[i])
            {
                Debug.Log($"Panel {i + 1} 間違っています. Expected: {Answer[i]}, Actual: {codePanels[i].number}");
                // 失敗時のSEを再生
                if (failureSE != null)
                {
                    failureSE.Play();
                }
                return false;
            }
        }
        return true;
    }

    void ClosePanel()
    {
        Panel.SetActive(false);
    }

    void ChangePanel()
    {
        NewPanel.SetActive(true);
    }

    void GetItem()
    {
        getItem.SetActive(true);
    }
}


