using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteGenerator : MonoBehaviour
{
    [SerializeField] Transform[] m_muzzle;
    [SerializeField] GameObject[] m_emote;
    int randomMuzzle;
    int randomEmote;

    void Start()
    {
        
    }

    void Update()
    {
        randomMuzzle = Random.Range(0, m_muzzle.Length);
        randomEmote = Random.Range(0, m_emote.Length);

        StartCoroutine(GenerateEmote());
    }

    IEnumerator GenerateEmote()
    {
        yield return new WaitForSeconds(0.5f);

        Instantiate(m_emote[randomEmote], m_muzzle[randomMuzzle].position, m_muzzle[randomMuzzle].rotation);
    }
}
