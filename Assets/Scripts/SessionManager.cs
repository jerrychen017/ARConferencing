using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace Com.ARConferencing.Client
{
    public class SessionManager : MonoBehaviourPunCallbacks
    {
        #region Public Fields 

        // [Tooltip("The prefab to use for representing the player")]
        // public GameObject playerPrefab;

        #endregion
        

        #region Photon Callbacks


        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()
        {
            Debug.LogFormat("left room!");
            SceneManager.LoadScene(0);
        }


        #endregion

        #region MonoBehaviour CallBacks

        void Start() 
        {
            // if (playerPrefab == null)
            // {
            //     print("SessionManager: prefab is null");
            //     Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'",this);
            // }
            // else
            // {
            //     Debug.LogFormat("We are Instantiating LocalPlayer from {0}", Application.loadedLevelName);
            //     // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate


            //     PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 0f, 5f), Quaternion.identity, 0);
            //     print("SessionManager: instantiated on network");
            //     // if (ParticipantManager.LocalPlayerInstance == null)
            //     // {
            //     //     Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
            //     //     // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
            //     //     PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
            //     //     print("SessionManager: instantiated on network");
            //     // }
            //     // else
            //     // {
            //     //     print("SessionManager: didn't instantiate");
            //     //     Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
            //     // }   
            //     // PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f,5f,0f), Quaternion.identity, 0);
            // }
        }

        #endregion


        #region Public Methods


        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        #endregion

        #region Private Methods

        void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
            }
            Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
            // PhotonNetwork.LoadLevel("Room for " + PhotonNetwork.CurrentRoom.PlayerCount);
            
            // // Create a temporary reference to the current scene.
            // Scene currentScene = SceneManager.GetActiveScene ();
 
            // // Retrieve the name of this scene.
            // string sceneName = currentScene.name;
            // Debug.LogFormat("!! Scenename is  " + sceneName);
            PhotonNetwork.LoadLevel(1);
            // SceneManager.LoadScene(1);
            // if (sceneName == "Viewer Client") {
            //     PhotonNetwork.LoadLevel(2);
            // } else {
            //     PhotonNetwork.LoadLevel(1);
            // }
            
        }


        #endregion

        #region Photon Callbacks


        public override void OnPlayerEnteredRoom(Player other)
        {
            Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting


            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

                LoadArena();
            }
        }


        public override void OnPlayerLeftRoom(Player other)
        {
            Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects

            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


                LoadArena();
            }
        }


        #endregion

    }
}