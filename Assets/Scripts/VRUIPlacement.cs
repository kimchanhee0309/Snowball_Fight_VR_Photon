using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRUIPlacement : MonoBehaviour
{
    public Transform vrCamera; // VR 카메라의 Transform 컴포넌트
    public Transform uiElement; // UI를 움직일 대상 UI 요소
    public float yOffset = 1.0f; // UI 요소가 카메라 위로 얼마나 떨어져 있는지 설정
    public float distanceFromCamera = 1.0f;

    void Update()
    {
        if (vrCamera != null && uiElement != null)
        {
            Vector3 cameraTopMiddle = vrCamera.position + vrCamera.forward * distanceFromCamera + vrCamera.up * yOffset;
            uiElement.position = cameraTopMiddle;
            uiElement.rotation = vrCamera.rotation;
        }
    }
}
