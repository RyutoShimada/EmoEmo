using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messagecontroller : MonoBehaviour
{
    List<GameObject> tagObjects;
    List<GameObject> tagObjectsStamp;

    [SerializeField] GameObject niyari;

    [SerializeField] GameObject Buruburu;

    [SerializeField] GameObject kyun;

    [SerializeField] GameObject oko;

    [SerializeField] GameObject upu;

    [SerializeField] GameObject pien;

    [SerializeField] GameObject stamp;
    //[SerializeField] GameObject message;

    Chaincontroller m_chain;

    [SerializeField] Transform generatePosition;

    int currentCount = 0;
    int currentCountStamp = 0;

    void Start()
    {
        tagObjects = new List<GameObject>();
        tagObjectsStamp = new List<GameObject>();
    }

    public void Generate(GameObject chainObj, int chainCount)
    {
        //GameObject messages = Instantiate(message, generatePosition, generatePosition);
        

        if (niyari.gameObject.layer == chainObj.gameObject.layer) 
        {
            GameObject niyariObj =  Instantiate(niyari, generatePosition, generatePosition);
            niyariObj.GetComponent<MessageText>().ChainText(chainCount);
            tagObjects.Add(niyariObj);
        }
        else if (Buruburu.gameObject.layer == chainObj.gameObject.layer)
        {
            GameObject buruburuObj = Instantiate(Buruburu, generatePosition, generatePosition);
            buruburuObj.GetComponent<MessageText>().ChainText(chainCount);
            tagObjects.Add(buruburuObj);
        }
        else if (kyun.gameObject.layer == chainObj.gameObject.layer)
        {
            GameObject kyunObj = Instantiate(kyun, generatePosition, generatePosition);
            kyunObj.GetComponent<MessageText>().ChainText(chainCount);
            tagObjects.Add(kyunObj);
        }
        else if (upu.gameObject.layer == chainObj.gameObject.layer)
        {
            GameObject upuObj = Instantiate(upu, generatePosition, generatePosition);
            upuObj.GetComponent<MessageText>().ChainText(chainCount);
            tagObjects.Add(upuObj);
        }
        else if (oko.gameObject.layer == chainObj.gameObject.layer)
        {
            GameObject okoObj = Instantiate(oko, generatePosition, generatePosition);
            okoObj.GetComponent<MessageText>().ChainText(chainCount);
            tagObjects.Add(okoObj);
        }
        else if (pien.gameObject.layer == chainObj.gameObject.layer)
        {
            GameObject pienObj = Instantiate(pien, generatePosition, generatePosition);
            pienObj.GetComponent<MessageText>().ChainText(chainCount);
            tagObjects.Add(pienObj);
        }
        
        currentCount++;
        if (currentCount > 4)
        {
            currentCount--;
            Destroy(tagObjects[0]);
            tagObjects.RemoveAt(0);
        }
    }

    public void Stamp()
    {
        GameObject gm = Instantiate(stamp, generatePosition, generatePosition);
        tagObjectsStamp.Add(gm);
        currentCountStamp++;
        if (currentCount > 4)
        {
            currentCountStamp--;
            Destroy(tagObjectsStamp[0]);
            tagObjectsStamp.RemoveAt(0);
        }
    }
}
