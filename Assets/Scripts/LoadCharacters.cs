using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using Google.Play.AssetDelivery;

public class LoadCharacters : MonoBehaviour
{

   // public AssetReference ReferenceField;
   // public AssetReference house;
    void Start()
    {
        Addressables.InitializeAsync().Completed += OnAddressableIntialized;
    }
   
        void OnAddressableIntialized(AsyncOperationHandle<IResourceLocator> locator)
        {
            StartCoroutine(LoadAllAssetsByKey());
        }

        IEnumerator LoadAllAssetsByKey()
        {

            //
            // var loader=   Addressables.LoadResourceLocationsAsync("Level3", null);
            // while (!loader.IsDone)
            // {
            //     yield return null;
            // }
            //
            // foreach (var location in loader.Result)
            // {
            //     UnityEngine.Debug.LogError(" Internal id "+location.InternalId);
            //     AsyncOperationHandle<GameObject> goHandleT = Addressables.LoadAssetAsync<GameObject>(location.InternalId);
            //     yield return goHandleT;
            //     if(goHandleT.Status == AsyncOperationStatus.Succeeded)
            //     {
            //         UnityEngine.Debug.LogError(" ObjectName " + goHandleT.Result.name);
            //         Instantiate(goHandleT.Result, gameObject.transform);
            //     }
            // }
            
            var op = Addressables.InstantiateAsync("Field",transform);
            yield return op;
            if (op.Result == null || !(op.Result is GameObject))
            {
              
                UnityEngine.Debug.LogError(" Unable to load " + op.Result.name);
            }
  
            AsyncOperationHandle<GameObject> goHandle = Addressables.LoadAssetAsync<GameObject>("Field");
                yield return goHandle;
                if(goHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    UnityEngine.Debug.LogError(" goHandle " + goHandle.Result.name);
                    Instantiate(goHandle.Result, gameObject.transform);
                }
                
                AsyncOperationHandle<GameObject> goHandle1 = Addressables.LoadAssetAsync<GameObject>("House_1Room_Blue");
                yield return goHandle1;
                if(goHandle1.Status == AsyncOperationStatus.Succeeded)
                {
                    UnityEngine.Debug.LogError(" goHandle " + goHandle1.Result.name);
                    Instantiate(goHandle1.Result, gameObject.transform);
                }
            
        }

}
