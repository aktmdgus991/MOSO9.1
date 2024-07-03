using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 카메라가 따라갈 대상 (캐릭터)
    public float yPosition;  // 카메라의 고정 Y 위치
    public float zPosition;  // 카메라의 고정 Z 위치
    public float smoothSpeed = 0.125f; // 카메라 이동 속도

    void Start()
    {
        // 초기 위치를 저장
        yPosition = transform.position.y;
        zPosition = transform.position.z;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // X축 위치만 업데이트
            Vector3 desiredPosition = new Vector3(target.position.x, yPosition, zPosition);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}