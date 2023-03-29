using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] AudioClip m_ambience;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic(m_ambience);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
