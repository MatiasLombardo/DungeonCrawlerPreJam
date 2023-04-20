using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] int m_ambience1 = 15;
    [SerializeField] int m_ambience2 = 1;
    [SerializeField] int m_ambience3 = 2;

    // Start is called before the first frame update
    void Start()
    {
        MusicaNivel1();
    }

    public void MusicaNivel1()
    {
        AudioManager.Instance.PlayMusic(m_ambience1);
    }

    public void MusicaNivel2()
    {
        AudioManager.Instance.PlayMusic(m_ambience2);
    }

    public void MusicaNivel3()
    {
        AudioManager.Instance.PlayMusic(m_ambience3);
    }




}
