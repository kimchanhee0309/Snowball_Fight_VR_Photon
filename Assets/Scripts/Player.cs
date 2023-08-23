using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using System.IO;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Player : MonoBehaviour
{
    public Transform pHead;
    public Transform pLeft;
    public Transform pRight;


    Transform oHead;
    Transform oLeft;
    Transform oRight;

    PhotonView pv;

    public Animator animatorLeft;
    public Animator animatorRight;

    void Start()
    {
        pv = GetComponent<PhotonView>();
        XROrigin o = FindObjectOfType<XROrigin>();

        oHead = o.transform.Find("Camera Offset/Main Camera");
        oLeft = o.transform.Find("Camera Offset/LeftHand Controller");
        oRight = o.transform.Find("Camera Offset/RightHand Controller");

        if(pv.IsMine)
        {
            foreach(var r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = false;
            }
        }
    }

    void SetTransform(Transform t, Transform s)
    {
        t.position = s.position;
        t.rotation = s.rotation;
    }

    void UpdateAnimation(InputDevice Device, Animator animator)
    {
        if (Device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            animator.SetFloat("Trigger", triggerValue);
        else
            animator.SetFloat("Trigger", 0);

        if (Device.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            animator.SetFloat("Grip", gripValue);
        else
            animator.SetFloat("Grip", 0);
    }

    void Update()
    {
        if(pv.IsMine)
        {
            SetTransform(pHead, oHead);
            SetTransform(pLeft, oLeft);
            SetTransform(pRight, oRight);

            UpdateAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), animatorLeft);
            UpdateAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), animatorRight);
        }
    }
}
