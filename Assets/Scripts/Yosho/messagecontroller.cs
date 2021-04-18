using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messagecontroller : MonoBehaviour
{
    List<GameObject> tagObjects;

    [SerializeField] GameObject niyari;

    [SerializeField] GameObject Buruburu;

    [SerializeField] GameObject kyun;

    [SerializeField] GameObject stamp;

    [SerializeField] GameObject oko;

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
        tagObjects.Add(message);

        if (niyari.gameObject.layer == message.gameObject.layer) 
        {
            Debug.Log("niyari");
            Instantiate(oko, generatePosition, generatePosition);
        }
        else if (Buruburu.gameObject.layer == message.gameObject.layer)
        {
            Debug.Log("Buruburu");
            Instantiate(Buruburu, generatePosition, generatePosition);
        }
        else if (kyun.gameObject.layer == message.gameObject.layer)
        {
            Debug.Log("kyun");
            Instantiate(kyun, generatePosition, generatePosition);
        }
        else if (stamp.gameObject.layer == message.gameObject.layer)
        {
            Debug.Log("stamp");
            Instantiate(stamp, generatePosition, generatePosition);
        }
        else if (oko.gameObject.layer == message.gameObject.layer)
        {
            Debug.Log("oko");
            Instantiate(oko, generatePosition, generatePosition);
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
