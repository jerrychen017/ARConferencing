using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Singletons/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    [SerializeField]
    private GameSettings _gameSettings; 
    public static GameSettings GameSettings { get { return Instance._gameSettings; } }

    private List<NetworkedPrefab> _networkedPrefabs = new List<NetworkedPrefab>(); 

    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position, Quaternion rotation)
    {
        foreach (NetworkedPrefab networkedPrefab in Instance._networkedPrefabs)
        {
            if (networkedPrefab.Prefab == obj) 
            {
                GameObject result = PhotonNetwork.Instantiate(networkedPrefab.Path, position, rotation); 
                return result;
            }
        }
        return null; 
    }

//     [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
//     private static void PopulateNetworkedPrefabs()
//     {
//         if (!Application.isEditor)
//             return; 

//         GameObject[] results = Resources.LoadAll<GameObject>(""); 
//         for (int i = 0; i < results.Length; i++) 
//         {
//             if (results[i].GetComponent<PhotonView>() != null)
//             {
//                 string path = AssetDatabase.GetAssetPath(results[i]);
//                 Instance._networkedPrefabs.Add(new NetworkedPrefab(results[i], path));
//             }
//         }

//     }
}
