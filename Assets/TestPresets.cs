using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPresets : MonoBehaviour
{
    public GameObject[] presets;
    public RuntimeAnimatorController controller;
    public Transform cameraTransform;
    public float cameraSpeedX = 0.1f;
    public float maximumX = 121f;
    public float x = 0f;

    // Start is called before the first frame update
    void Start()
    {
        int n = 0;
        foreach (var preset in presets)
        {
            var go = Instantiate(preset, new Vector3(n, 0, 0), new Quaternion(0, 180, 0, 0));
            if (go && go.TryGetComponent(out Animator ac))
                ac.runtimeAnimatorController = controller;
            n++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTransform.position.x < maximumX)
            x = cameraSpeedX * Time.deltaTime;
        else
            x = 0f;

        cameraTransform.position += new Vector3(x, 0, 0);
    }
}
