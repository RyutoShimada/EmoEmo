using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messagecontroller : MonoBehaviour
{
    List<GameObject> tagObjects;

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

    void Start()
    {
        tagObjects = new List<GameObject>();
    }

    public void Generate(GameObject message)
    {
        //GameObject messages = Instantiate(message, generatePosition, generatePosition);
        

        if (niyari.gameObject.layer == message.gameObject.layer) 
        {
            Debug.Log("niyari");
            GameObject niyariObj =  Instantiate(niyari, generatePosition, generatePosition);
            tagObjects.Add(niyariObj);
        }
        else if (Buruburu.gameObject.layer == message.gameObject.layer)
        {
            Debug.Log("Buruburu");
            GameObject buruburuObj = Instantiate(Buruburu, generatePosition, generatePosition);
            tagObjects.Add(buruburuObj);
        }
        else if (kyun.gameObject.layer == message.gameObject.layer)
        {
            Debug.Log("kyun");
            GameObject kyunObj = Instantiate(kyun, generatePosition, generatePosition);
            tagObjects.Add(kyunObj);
        }
        else if (upu.gameObject.layer == message.gameObject.layer)
        {
            Debug.Log("upu");
            GameObject upuObj = Instantiate(upu, generatePosition, generatePosition);
            tagObjects.Add(upuObj);
        }
        else if (oko.gameObject.layer == message.gameObject.layer)
        {
            Debug.Log("oko");
            GameObject okoObj = Instantiate(oko, generatePosition, generatePosition);
            tagObjects.Add(okoObj);
        }
        else if (pien.gameObject.layer == message.gameObject.layer)
        {
            Debug.Log("pien");
            GameObject pienObj = Instantiate(pien, generatePosition, generatePosition);
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
        tagObjects.Add(gm);
        currentCount++;
        if (currentCount > 4)
        {
            currentCount--;
            Destroy(tagObjects[0]);
            tagObjects.RemoveAt(0);
        }
    }
}
