using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Charater
{
    public InputControl InputControl = null;
    public Animator Animator = null;

    public Transform CameraTransform = null;

    public Weapon Weapon = null;

    // �Ķ������ �̸����� ������ 
    private readonly int HitX_Hash = Animator.StringToHash("HitX");
    private readonly int HitY_Hash = Animator.StringToHash("HitY");
    private readonly int Die_Hash = Animator.StringToHash("Die");
    private readonly int Input_Hash = Animator.StringToHash("Input");
    private readonly int Velocity_Hash = Animator.StringToHash("Velocity");
    private readonly int AngleRad_Hash = Animator.StringToHash("AngleRad");
    private readonly int Attack_Hash = Animator.StringToHash("Attack");

    private float Velocity = 0f;

    public override void Init()
    {
        Charater_Type = ECHARATER_TYPE.PLAYER;
        State = ECHARACTER_STATE.IDLE;
    }

    // ������ ����� ������ ���̱� ������ fixedupdate
    private void FixedUpdate()
    {
        Vector3 moveVec = InputControl.MoveInput;

        if (moveVec.magnitude < 0.1f)
        {
            Velocity = Mathf.Clamp01(Velocity - 0.1f);
        }
        else
        {
            Velocity = Mathf.Clamp01(Velocity + (moveVec.magnitude * Time.deltaTime));
        }

        Animator.SetBool(Input_Hash, Velocity>0.2f || InputControl.Attack);

        if (Velocity < 0.1f)
        {
            Idle();
        }
        else
        {
            Move();

            moveVec.z = moveVec.y;
            moveVec.y = 0f;
            Vector3 worldMoveDir = moveVec.normalized;

            moveVec = CameraTransform.rotation * Vector3.forward;
            moveVec.y = 0f;
            moveVec.Normalize();

            Vector3 resultForward;
            Quaternion targetRotation;

            // Approximately ���� �ΰ� �ְ� ���� ������ ���� (�����ߴ���)
            // Dot = ����
            // worldMoveDir�� Vector3.forward�� �󸶸�ŭ �����ִ��� Ȯ��
            // Vector3.Dot(0.0.1,Vector3.forward) = 1f ����������
            //Vector3.Dot(0.0.-1,Vector3.forward) = -1f �� �ݴ���
            // Ű���� w�� ī�޶� �ٶ󺸴� ������ ���ϴ� ���Ͱ� �ɰ���
            // Ű���� s�� ī�޶� �ٶ󺸴� ������ ���ݴ븦 ���ϴ� ���Ͱ� �ɰ���
            if (Mathf.Approximately(Vector3.Dot(worldMoveDir,Vector3.forward),-1f))
            {
                resultForward = -moveVec;
                // �ٶ������ ������ ���ϴ� ���� 
                targetRotation = Quaternion.LookRotation(-moveVec);
            }
            else
            {
                // �Է� ���� worldMoveDir�� ���ؼ� �󸶸�ŭ ȸ������ �ʿ����� ���ؾ��ϱ� ������ 
                // Quaternion.FromToRotation(Vector3.forward, worldMoveDir) = ȸ����
                // ī�޶� �ٶ󺸴� ������ ���� ���Ͱ�
                // moveVec = ���Ⱚ
                resultForward = Quaternion.FromToRotation(Vector3.forward, worldMoveDir) * moveVec;
                targetRotation = Quaternion.LookRotation(resultForward);
            }

            float curAngle = transform.eulerAngles.y;
            float targetAngle = Mathf.Atan2(resultForward.x, resultForward.z) * Mathf.Rad2Deg;

            // �� ������ ������ �� ���� ���� ��ȯ (360�� �Ѿ �� �ֱ� ����)
            float angleDiff = Mathf.DeltaAngle(curAngle, targetAngle);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 400f * Velocity * Time.deltaTime);

            Animator.SetFloat(AngleRad_Hash, angleDiff * Mathf.Deg2Rad);
        }

    }

    // ������Ʈ ���� ����Ʈ ������Ʈ ������ ȣ�� 
    // �� ĳ���͵��� �ִϸ����͵�� ���������� �����Ұ��̱� ������ ���? 
    private void OnAnimatorMove()
    {
        transform.position += Animator.deltaPosition;
    }

    public override void Idle()
    {     
        Animator.SetFloat(Velocity_Hash, 0f);
    }

    public override void Attack()
    {
        Animator.SetTrigger(Attack_Hash);
    }

    public override void Move()
    {
        Animator.SetFloat(Velocity_Hash, 1f);
    }

    public void Dead()
    {
        Animator.SetTrigger(Die_Hash);
    }

    public void TakeDamage(int damage, Transform attacker)
    {
        Stat.HP -= damage;

        if (Stat.HP > 0)
        {
            // player 0.0.0
            // attacker 1.0.1
            // ������ ���� ���� 1.0.1
            // player forward 0.0.1�� ���
            // 1.0.1
            // player forward 0.0.-1�� ���
            // -1.0.-1

            // ������ ���� ���� 
            Vector3 hittedVector = attacker.position - transform.position;
            hittedVector.y = 0f;

            // ���� ������ ������
            hittedVector = transform.InverseTransformDirection(hittedVector);

            Animator.SetFloat(HitX_Hash, hittedVector.x);
            Animator.SetFloat(HitY_Hash, hittedVector.z);
        }
        else
        {
            Dead();
        }
    }
}
