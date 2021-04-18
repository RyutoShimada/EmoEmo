using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageText : MonoBehaviour
{
    Text text = null;

    public void ChainText(int ChainCount)
    {
        GameObject gm = transform.Find("Text").gameObject;
        text = gm.GetComponent<Text>();
        text.text = ChainCount.ToString();
    }
}
