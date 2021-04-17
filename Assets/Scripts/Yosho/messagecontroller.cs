using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messagecontroller : MonoBehaviour
{
    List<GameObject> tagObjects;

    [SerializeField] GameObject message;

    [SerializeField] Transform generatePosition;

    int currentCount = 0;

    void Start()
    {
        tagObjects = new List<GameObject>();
    }



    public void Generate()
    {
        Debug.Log(tagObjects);
        tagObjects.Add(message);
        currentCount++;
        Instantiate(tagObjects[currentCount - 1], generatePosition, generatePosition);
        if (currentCount > 4)
        {
            tagObjects.RemoveAt(tagObjects.Count - 1);
            currentCount--;
            //Destroy(tagObjects[tagObjects.Count - 1]);
        }
    }
}
