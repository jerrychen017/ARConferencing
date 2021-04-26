using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.ARConferencing.Client
{

    public class OntoTarget : MonoBehaviour
    {
        [SerializeField]
        public GameObject Target;
        public GameObject Avatar;   

        // Update is called once per frame
        void Update()
        {
            if (ParticipantManager.LocalPlayerInstance != null) {
                Avatar = ParticipantManager.LocalPlayerInstance;
            }
            // Avatar.transform.position = Target.transform.position;
            Avatar.transform.position = Target.transform.position + new Vector3(-0.5f, 0, -0.2f);
            Avatar.transform.rotation = Target.transform.rotation;
            Avatar.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}