using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] m_emote;
    float randomMuzzle;
    int randomEmote;
    float m_timer = 0.0f;
    float m_interval = 1.0f;


    void Update()
    {
        randomEmote = Random.Range(0, m_emote.Length);

        m_timer += Time.deltaTime;

        if (m_timer >= m_interval)
        {
            m_timer = 0.0f;
            GameObject e = Instantiate(m_emote[randomEmote]);
            randomMuzzle = Random.Range(-1.0f, 1.0f);
            e.transform.position = new Vector3(randomMuzzle, 3, 3);
        }
    }
}
