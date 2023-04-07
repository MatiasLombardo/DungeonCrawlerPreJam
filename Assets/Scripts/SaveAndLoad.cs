using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZSerializer;

public class SaveAndLoad : MonoBehaviour
{
    // Start is called before the first frame update
    public async void OnSave()
    {
        await ZSerialize.SaveScene();
    }

    // Update is called once per frame
    public async void OnLoad()
    {
        await ZSerialize.LoadScene();
    }
}
