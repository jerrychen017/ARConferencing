using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Photon.Pun;
using Photon.Realtime; 
// using ExitGames.Client.Photon;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class HumanBodyTracker : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The Skeleton prefab to be controlled.")]
        GameObject m_SkeletonPrefab;

        [SerializeField]
        [Tooltip("The ARHumanBodyManager which will produce body tracking events.")]
        ARHumanBodyManager m_HumanBodyManager;

        public const byte CustomManualInstantiationEventCode = 1; // photon network
        public const byte CustomManualDestroyEventCode = 2; // photon network

        /// <summary>
        /// Get/Set the <c>ARHumanBodyManager</c>.
        /// </summary>
        public ARHumanBodyManager humanBodyManager
        {
            get { return m_HumanBodyManager; }
            set { m_HumanBodyManager = value; }
        }

        /// <summary>
        /// Get/Set the skeleton prefab.
        /// </summary>
        public GameObject skeletonPrefab
        {
            get { return m_SkeletonPrefab; }
            set { m_SkeletonPrefab = value; }
        }

        Dictionary<TrackableId, BoneController> m_SkeletonTracker = new Dictionary<TrackableId, BoneController>();

        void OnEnable()
        {
            Debug.Assert(m_HumanBodyManager != null, "Human body manager is required.");
            m_HumanBodyManager.humanBodiesChanged += OnHumanBodiesChanged;
        }

        void OnDisable()
        {
            if (m_HumanBodyManager != null)
                m_HumanBodyManager.humanBodiesChanged -= OnHumanBodiesChanged;
        }

        void OnHumanBodiesChanged(ARHumanBodiesChangedEventArgs eventArgs)
        {
            BoneController boneController;

            foreach (var humanBody in eventArgs.added)
            {
                if (!m_SkeletonTracker.TryGetValue(humanBody.trackableId, out boneController))
                {
                    Debug.Log($"Adding a new skeleton [{humanBody.trackableId}].");
                    //var newSkeletonGO = Instantiate(m_SkeletonPrefab, humanBody.transform);

                    var newSkeletonGO = PhotonNetwork.Instantiate(m_SkeletonPrefab.name, humanBody.transform.position, humanBody.transform.rotation, 0);
                    //var newSkeletonGO = PhotonNetwork.Instantiate(m_SkeletonPrefab.name, newSkeletonGO.transform.position, newSkeletonGO.transform.rotation, 0);
                    // var newSkeletonGO = PhotonNetwork.Instantiate(m_SkeletonPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
                    //PhotonTransformView ptv = newSkeletonGO.GetComponent<PhotonTransformView>();
                    //ptv.m_SynchronizePosition = true;
                    //ptv.m_SynchronizeRotation = true;
                    newSkeletonGO.transform.SetParent(humanBody.transform);

                    // instantiate on photon network
                    // PhotonView photonView = newSkeletonGO.GetComponent<PhotonView>();
                    // if (PhotonNetwork.AllocateViewID(photonView))
                    // {
                    //     object[] data = new object[]
                    //     {
                    //         newSkeletonGO.transform.position, newSkeletonGO.transform.rotation, photonView.ViewID
                    //     };

                    //     RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                    //     {
                    //         Receivers = ReceiverGroup.Others,
                    //         CachingOption = EventCaching.AddToRoomCache
                    //     };

                    //     SendOptions sendOptions = new SendOptions
                    //     {
                    //         Reliability = true
                    //     };

                    //     PhotonNetwork.RaiseEvent(CustomManualInstantiationEventCode, data, raiseEventOptions, sendOptions);
                    // }
                    // else
                    // {
                    //     Debug.LogError("Failed to allocate a ViewId.");

                    //     Destroy(newSkeletonGO);
                    // }
                    // end of photon network code

                    boneController = newSkeletonGO.GetComponent<BoneController>();
                    m_SkeletonTracker.Add(humanBody.trackableId, boneController);
                }

                boneController.InitializeSkeletonJoints();
                boneController.ApplyBodyPose(humanBody);
            }

            foreach (var humanBody in eventArgs.updated)
            {
                if (m_SkeletonTracker.TryGetValue(humanBody.trackableId, out boneController))
                {
                    boneController.ApplyBodyPose(humanBody);
                }
            }

            foreach (var humanBody in eventArgs.removed)
            {
                Debug.Log($"Removing a skeleton [{humanBody.trackableId}].");
                if (m_SkeletonTracker.TryGetValue(humanBody.trackableId, out boneController))
                {

                    // var toBeDestroyed = boneController.gameObject;
                    // // destroy on photon network
                    // PhotonView photonView = toBeDestroyed.GetComponent<PhotonView>();
                    
                    // object[] data = new object[]
                    // { photonView.ViewID };

                    // RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                    // {
                    //     Receivers = ReceiverGroup.Others,
                    //     CachingOption = EventCaching.AddToRoomCache
                    // };

                    // SendOptions sendOptions = new SendOptions
                    // {
                    //     Reliability = true
                    // };

                    // PhotonNetwork.RaiseEvent(CustomManualDestroyEventCode, data, raiseEventOptions, sendOptions);

                    Destroy(boneController.gameObject);
                    m_SkeletonTracker.Remove(humanBody.trackableId);
                }
            }
        }
    }
}