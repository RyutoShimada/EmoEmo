using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopText : MonoBehaviour
{
    [SerializeField] GameObject m_popTextPanel = null;
    [SerializeField] GameObject m_popText = null;

    public void InstantiatePopText()
    {
        GameObject go = Instantiate(m_popText, m_popTextPanel.transform);
        go.GetComponentInChildren<PopTextCreate>().ChangeText(go.transform.GetSiblingIndex().ToString());

    }
}
