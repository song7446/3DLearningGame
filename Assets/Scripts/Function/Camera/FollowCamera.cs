using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform Target = null;

    public bool InvertY = false;

    public float ArcSpeed = 1f;
    public float MoveSpeed = 1f;
    public float Distance = 4f;

    private Vector3 ElapsedVec = Vector3.zero;

    // �÷��̾ ������ ������Ʈ���� ȣ��Ǵµ� 
    // ī�޶� ������Ʈ�� �ִٸ� ������ ������� ���� 
    // �׷��� ������ lateupdate�� ���� ���߿� ī�޶� ���� 
    private void LateUpdate()
    {
        CalPosition();
        CalLookAt();
    }

    private void CalPosition()
    {
        var targetPos = Target.position;

        Vector2 mouseValue = InputControl.Instance.MouseInput;
        mouseValue *= ArcSpeed;
        ElapsedVec.x += mouseValue.x;
        ElapsedVec.y = Mathf.Clamp(ElapsedVec.y + (mouseValue.y * (InvertY ? 1f : -1f)), 0.2f, 1.9f);

        transform.position = targetPos + (new Vector3(Mathf.Cos(ElapsedVec.x) * Mathf.Sin(ElapsedVec.y), Mathf.Cos(ElapsedVec.y), Mathf.Sin(ElapsedVec.x) * Mathf.Sin(ElapsedVec.y)) * Distance);

        //ElapsedVec += Time.deltaTime * Vector3.one;
        // x,y �������� ȸ��
        // transform.position = new Vector3(Mathf.Sin(ElapsedVec.y), Mathf.Cos(ElapsedVec.y), 0f);
        // y,z �������� ȸ�� 
        // transform.position = new Vector3(0f, Mathf.Cos(ElapsedVec.y), Mathf.Sin(ElapsedVec.y));
        // x,z ������ ȸ�� 
        // transform.position = new Vector3(Mathf.Cos(ElapsedVec.x), 0f, Mathf.Sin(ElapsedVec.x));
    }

    private void CalLookAt()
    {
        Vector3 dirVector = Target.position - transform.position;

        Vector3 eulerVector = Vector3.zero;

        eulerVector.y = Mathf.Atan2(dirVector.x, dirVector.z) * Mathf.Rad2Deg;
        eulerVector.x = -Mathf.Asin(dirVector.y / dirVector.magnitude) * Mathf.Rad2Deg;
        eulerVector.z = 0f;

        transform.rotation = Quaternion.Euler(eulerVector);

        // ���� �̷��� �� 
        //transform.LookAt(Target.position);
    }
}
