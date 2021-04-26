using UnityEngine;
using UnityEngine.EventSystems;

using Photon.Pun;

using System.Collections;
using System.Collections.Generic;

namespace Com.ARConferencing.Client
{
    /// <summary>
    /// Player manager.
    /// Handles fire Input and Beams.
    /// </summary>
    public class ParticipantManager : MonoBehaviourPunCallbacks
    {

        #region IPunObservable implementation

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
        }


        #endregion



        #region Public Fields
        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;
        #endregion


        #region Private Fields

        // [Tooltip("The Beams GameObject to control")]
        // [SerializeField]
        // private GameObject beams;
        // //True, when the user is firing
        // bool IsFiring;

        #endregion



        #region MonoBehaviour CallBacks

        void Start()
        {
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("Starting participant manger!");
        }

        void Load()
        {
            Debug.Log("loading participant manger!");
        }

        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
        /// </summary>
        void Awake()
        {

            // #Important
            // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
            // if (photonView.IsMine)
            // {
            //     ParticipantManager.LocalPlayerInstance = this.gameObject;
            // }
            ParticipantManager.LocalPlayerInstance = this.gameObject;
            // #Critical
            // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
            DontDestroyOnLoad(this.gameObject);
            
            // if (beams == null)
            // {
            //     Debug.LogError("<Color=Red><a>Missing</a></Color> Beams Reference.", this);
            // }
            // else
            // {
            //     beams.SetActive(false);
            // }
        }

        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity on every frame.
        /// </summary>
        void Update()
        {

            // ProcessInputs();

            // // trigger Beams active state
            // if (beams != null && IsFiring != beams.activeInHierarchy)
            // {
            //     beams.SetActive(IsFiring);
            // }
        }

        #endregion

        #region Custom

        // /// <summary>
        // /// Processes the inputs. Maintain a flag representing when the user is pressing Fire.
        // /// </summary>
        // void ProcessInputs()
        // {
        //     if (Input.GetButtonDown("Fire1"))
        //     {
        //         if (!IsFiring)
        //         {
        //             IsFiring = true;
        //         }
        //     }
        //     if (Input.GetButtonUp("Fire1"))
        //     {
        //         if (IsFiring)
        //         {
        //             IsFiring = false;
        //         }
        //     }
        // }

        #endregion
    }
}

