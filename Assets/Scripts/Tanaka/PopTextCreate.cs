using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 自身のテキストの表示を変更する
/// </summary>
public class PopTextCreate : MonoBehaviour
{
    public void ChangeText(string text)
    {
        this.gameObject.GetComponent<Text>().text = text;
    }
}
