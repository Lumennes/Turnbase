
using System.Reflection;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

internal class LoadSceneByAddress : MonoBehaviour
{
    public int index = 0;
    public string[] key; // address string
    public AsyncOperationHandle<SceneInstance> loadHandle;
    public ResourceLocationBase[] locations;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadScene();
    }

    void NextScene()
    {
        if (index == key.Length - 1)
            index = 0; 
        else
            index++;

        LoadScene();
    }

    void LoadScene()
    {
        loadHandle = Addressables.LoadSceneAsync(key[index]/*, LoadSceneMode.Additive*/);
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            NextScene();
        }
    }

    //void OnDestroy()
    //{
    //    try
    //    {
    //        Debug.Log("Пробуем осободить сцену");
    //        Addressables.UnloadSceneAsync(loadHandle);
    //    }
    //    catch
    //    {
    //        Debug.Log("Не получилось " + loadHandle.Result.Scene.name);
    //        Debug.Log(loadHandle.ToString());
    //    }
    //}
}