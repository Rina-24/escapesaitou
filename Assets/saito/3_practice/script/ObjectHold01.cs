using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold01 : MonoBehaviour
{
    Transform hold;
    bool push;
    // bool pushenter;
    // GameObject[] Bucket_Ten;
    // GameObject[] Bucket_Seven;
    // GameObject[] Bucket_Three;
    // int num10;
    // int num7;
    // int num3;


    void Start()
    {
        // Bucket_Ten = new GameObject[]{
        //     GameObject.Find("WaterOne_ten"),
        //     GameObject.Find("WaterTwo_ten"),
        //     GameObject.Find("WaterThree_ten"),
        //     GameObject.Find("WaterFour_ten"),
        //     GameObject.Find("WaterFive_ten"),
        //     GameObject.Find("WaterSix_ten"),
        //     GameObject.Find("WaterSeven_ten"),
        //     GameObject.Find("WaterEight_ten"),
        //     GameObject.Find("WaterNine_ten"),
        //     GameObject.Find("WaterTen_ten")
        // };

        // Bucket_Seven = new GameObject[]{
        //     GameObject.Find("WaterOne_seven"),
        //     GameObject.Find("WaterTwo_seven"),
        //     GameObject.Find("WaterThree_seven"),
        //     GameObject.Find("WaterFour_seven"),
        //     GameObject.Find("WaterFive_seven"),
        //     GameObject.Find("WaterSix_seven"),
        //     GameObject.Find("WaterSeven_seven")
        // };

        // Bucket_Three = new GameObject[]{
        //     GameObject.Find("WaterOne_three"),
        //     GameObject.Find("WaterTwo_three"),
        //     GameObject.Find("WaterThree_three")
        // };

        // foreach (GameObject obj in Bucket_Seven)
        // {
        //     obj.SetActive(false);
        // }

        // foreach (GameObject obj in Bucket_Three)
        // {
        //     obj.SetActive(false);
        // }
    }

    private void Update()
    {
        // updateメソッド内でGetkeyを使わないと反応しずらいため、こちらに記載、pushに代入
        push = Input.GetKeyDown("space");
        // pushenter = Input.GetKeyDown("Return");

        if (push)
        {
            // spaceを離したら、親オブジェクトをnullへ
            if (hold != null)
            {
                hold.SetParent(null);
                hold = null;
            }
        }
    }

    // otherコライダーに接触している間の処理
    private void OnTriggerStay(Collider other)
    {
        // for (int i = 9; i >= 0; i--)
        // {
        //     if (Bucket_Ten[i] == null)
        //     {
        //         continue;
        //     }
        //     else if (Bucket_Ten[i] == true)
        //     {
        //         num10 = i;
        //     }
        //     else if (Bucket_Ten[0] == null)
        //     {
        //         num10 = 0;
        //     }
        // }

        // for (int i = 6; i >= 0; i--)
        // {
        //     if (Bucket_Seven[i] == null)
        //     {
        //         continue;
        //     }
        //     else if (Bucket_Seven[i] == true)
        //     {
        //         num7 = i;
        //     }
        //     else
        //     {
        //         num7 = 0;
        //     }
        // }

        // for (int i = 2; i >= 0; i--)
        // {
        //     if (Bucket_Seven[i] == null)
        //     {
        //         continue;
        //     }
        //     else if (Bucket_Three[i] == true)
        //     {
        //         num3 = i;
        //     }
        //     else
        //     {
        //         num3 = 0;
        //     }
        // }

        // 親がnullでpush(Input.GetKeyDown("space"))がtrueならば
        if (hold == null && push)
        {
            if (other.gameObject.name == "Bucket_10")
            {
                other.transform.SetParent(this.transform);  // other（衝突しているオブジェクト）を親にする
                other.transform.localPosition = new Vector3(0, -2, 10);  // 親オブジェクトへ移行後のポジションを指定
                hold = other.transform;  // holdをnullではなくし、updataメソッド内のif文の条件を満たす
            }
            else if (other.gameObject.name == "Bucket_07")
            {
                other.transform.SetParent(this.transform);
                other.transform.localPosition = new Vector3(0, -2, 10);
                hold = other.transform;
            }
            else if (other.gameObject.name == "Bucket_03")
            {
                other.transform.SetParent(this.transform);
                other.transform.localPosition = new Vector3(0, -2, 10);
                hold = other.transform;
            }
            else if (other.gameObject.name == "MagicPot")
            {
                other.transform.SetParent(this.transform);
                other.transform.localPosition = new Vector3(0, -2, 10);
                hold = other.transform;
            }
        }
        // else if (hold != null && pushenter)
        // {
        //     if (other.gameObject.name == "Bucket_10")
        //     {
        //         if (transform.Find("Bucket_07") != null && transform.Find("Bucket_03") == null)
        //         {
        //             if (num7 < 7)
        //             {
        //                 int y = 7 - num7;
        //                 for (int i = (num10 - 1); num7 >= 0; num7--)
        //                 {
        //                     if (i >= 0)
        //                     {
        //                         Bucket_Ten[i].SetActive(false);
        //                         i -= 1;
        //                         if ((y + num7) <= 7)
        //                         {
        //                             Bucket_Seven[y + num7].SetActive(true);
        //                         }
        //                         else
        //                         {
        //                             continue;
        //                         }
        //                     }
        //                     else
        //                     {
        //                         break;
        //                     }
        //                 }
        //             }
        //         }
        //         else if (transform.Find("Bucket_03") != null && transform.Find("Bucket_07") == null)
        //         {
        //             if (num3 < 3)
        //             {
        //                 int y = 3 - num3;
        //                 for (int i = (num10 - 1); num3 >= 0; num3--)
        //                 {
        //                     if (i >= 0)
        //                     {
        //                         Bucket_Ten[i].SetActive(false);
        //                         i -= 1;
        //                         if ((y + num3) <= 3)
        //                         {
        //                             Bucket_Three[y + num3].SetActive(true);
        //                         }
        //                         else
        //                         {
        //                             continue;
        //                         }
        //                     }
        //                     else
        //                     {
        //                         break;
        //                     }
        //                 }
        //             }

        //         }

        //     }
        //     else if (other.gameObject.name == "Bucket_07")
        //     {
        //         if (transform.Find("Bucket_10") != null && transform.Find("Bucket_03") == null)
        //         {
        //             if (num10 < 10)
        //             {
        //                 int y = 10 - num10;
        //                 for (int i = (num7 - 1); num10 >= 0; num10--)
        //                 {
        //                     if (i >= 0)
        //                     {
        //                         Bucket_Seven[i].SetActive(false);
        //                         i -= 1;
        //                         if ((y + num10) <= 10)
        //                         {
        //                             Bucket_Ten[y + num10].SetActive(true);
        //                         }
        //                         else
        //                         {
        //                             continue;
        //                         }
        //                     }
        //                     else
        //                     {
        //                         break;
        //                     }
        //                 }
        //             }


        //         }
        //         else if (transform.Find("Bucket_03") != null && transform.Find("Bucket_10") == null)
        //         {

        //         }

        //     }
        //     else if (other.gameObject.name == "Bucket_03")
        //     {
        //         if (transform.Find("Bucket_07") != null && transform.Find("Bucket_10") == null)
        //         {


        //         }
        //         else if (transform.Find("Bucket_10") != null && transform.Find("Bucket_07") == null)
        //         {

        //         }

        //     }
    }

    // }

}