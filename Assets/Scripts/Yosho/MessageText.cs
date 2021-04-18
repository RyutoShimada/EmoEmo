using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageText : MonoBehaviour
{
    Text text = null;

    // Start is called before the first frame update
    void Start()
    {
       GameObject gm = transform.Find("Text").gameObject;
        text = gm.GetComponent<Text>();
        Debug.Log(text);
    }

    public void ChainText(int ChainCount)
    {
        Debug.Log(text);
        text.text = ChainCount.ToString();
    }
    

}
