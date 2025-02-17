using UnityEngine;

public class PassKeyController : MonoBehaviour
{
    public int[] ansPassKey = { 3, 9, 1, 2 }; // 正しい順序
    private int[] inputPassKey = new int[4]; // ユーザーがクリックした順序
    private int currentIndex = 0; // 現在のインデックス
    private  bool ansuwerPass;

    [SerializeField]
    private GameObject UpArrow; // 成功時に表示するUI
    [SerializeField]
    private AudioSource successSE; // 成功時のSE
    [SerializeField]
    private AudioSource failureSE; // 失敗時のSE


    
    public void OnPanelClick(int digit)
    {
         if (ansuwerPass)
        {
            gameObject.SetActive(false);
            // 一度正解したら入力ができないようにする
            return;
        }
        ansuwerPass = false;
        Debug.Log("Panel Clicked! Digit: " + digit);

        // 入力された数字を配列に保存
        inputPassKey[currentIndex] = digit;
        currentIndex++;

        // 配列が満たされたら正誤判定
        if (currentIndex == ansPassKey.Length)
        {
            if (IsPassKeyCorrect())
            {
                Debug.Log("正解です！");
                UpArrow.SetActive(true);
                ansuwerPass = true;
                // 成功時のSEを再生
                if (successSE != null)
                    {
                        successSE.Play();
                    }
                GameSaveData.Instance.SetGameFlag("Panel0PassKeyCorrect", 1);
                
            }
            else
            {
                ansuwerPass = false;
                Debug.Log("入力が間違っています");
                ResetInput();
                // 失敗時のSEを再生
                if (failureSE != null)
                {
                    failureSE.Play();
                }
                    
                // 失敗した場合も currentIndex と inputPassKey をリセット
                currentIndex = 0;
                for (int i = 0; i < inputPassKey.Length; i++)
                {
                    inputPassKey[i] = 0;
                }
            }
        }
    }

    private bool IsPassKeyCorrect()
    {
        // 入力されたパスキーが正しいかどうかをチェック
        for (int i = 0; i < ansPassKey.Length; i++)
        {
            if (inputPassKey[i] != ansPassKey[i])
            {
                return false;
            }
        }
        return true;
    }

    private void ResetInput()
    {
        // 入力をリセット
        currentIndex = 0;
        for (int i = 0; i < inputPassKey.Length; i++)
        {
            inputPassKey[i] = 0;
        }
    }
}
