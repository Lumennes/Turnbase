using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Translate : MonoBehaviour
{
    public string ru;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        if (GlobalConditionC.language == "ru")
            if (TryGetComponent(out Text text))
                text.text = ru;
            else if (TryGetComponent(out TextMesh textmesh))
                textmesh.text = ru;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
