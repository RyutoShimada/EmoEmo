using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageText : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
       GameObject gm = transform.Find("Text").gameObject;
        text = gm.GetComponent<Text>();
    }

   
    void Update()
    {
        
    }

    public void ChainText(int ChainCount)
    {
        text.text = ChainCount.ToString();
    }
    

}
