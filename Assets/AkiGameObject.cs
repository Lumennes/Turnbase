using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Animations;

public class AkiGameObject : MonoBehaviour
{
    public AssetReference SpawnablePrefab;


    // Start is called before the first frame update
    void Start()
    {
        /*StartCoroutine();*/
        //StartSpawner();
        SpawnTemporaryCube();
    }

    /*IEnumerator */void StartSpawner()
    {
        //while (true)
        {
            //yield return new WaitForSeconds(DelayBetweenSpawns);
            //StartCoroutine(SpawnTemporaryCube());
        }
    }

    List<AsyncOperationHandle<GameObject>> handles;

    /*IEnumerator*/void SpawnTemporaryCube()
    {
        handles = new List<AsyncOperationHandle<GameObject>>();

        //for (int i = 0; i < NumberOfPrefabsToSpawn; i++)
        //{
            //Instantiates a prefab with the address "Cube".  If this isn't working make sure you have your Addressable Groups
            //window setup and a prefab with the address "Cube" exists.
            AsyncOperationHandle<GameObject> handle = SpawnablePrefab.InstantiateAsync();
            handles.Add(handle);
        //}


        handle.Completed += Handle_Completed;
        //yield return new WaitForSeconds(DealyBeforeDestroying);

        //Release the AsyncOperationHandles which destroys the GameObject

    }

    private void Handle_Completed(AsyncOperationHandle<GameObject> obj)
    {
        Debug.Log(gameObject.name + " completed!");
        //AnimatorController ac = FindObjectOfType<AnimatorController>(); 
        //TODO AnimatorController не работает???
        // не то
        //ac.animators = new Animator[1];//.Clear(ac.animators, 0, ac.animators.Length);
        //ac.animators[0] = handles[0].Result.GetComponent<Animator>();
        // то - увеличивает массив
        //Array.Resize(ref ac.animators, ac.animators.Length + 1);
        // так можно наверно последний элемент массива найти
        //ac.animators[^1] = handles[0].Result.GetComponent<Animator>();
        //throw new System.NotImplementedException();
    }

    private void OnDisable()
    {
        foreach (var handle in handles)
        {
            handle.Completed -= Handle_Completed;
            Addressables.Release(handle);
        }
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
