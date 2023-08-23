using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRUIPlacement : MonoBehaviour
{
    public Transform vrCamera; // VR ī�޶��� Transform ������Ʈ
    public Transform uiElement; // UI�� ������ ��� UI ���
    public float yOffset = 1.0f; // UI ��Ұ� ī�޶� ���� �󸶳� ������ �ִ��� ����
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
