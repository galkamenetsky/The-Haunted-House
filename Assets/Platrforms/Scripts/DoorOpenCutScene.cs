using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DoorOpenCutScene : MonoBehaviour, IKeyCollectObserver
{
    [SerializeField] private GameObject timeLine;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    public void SetDoor(Transform door)
    {
        virtualCamera.LookAt = door;
        virtualCamera.Follow = door;
    }

    public void OnKeyCollected(Key key)
    {
        timeLine.gameObject.SetActive(true);
    }
}
