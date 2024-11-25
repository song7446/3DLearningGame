using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Charater
{
    public InputControl InputControl = null;
    public Animator Animator = null;

    public Transform CameraTransform = null;

    public Weapon Weapon = null;

    // 파라미터의 이름으로 가져옴 
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

    // 물리적 연산과 적용할 것이기 때문에 fixedupdate
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

            // Approximately 변수 두개 넣고 차이 정도를 구함 (근접했는지)
            // Dot = 내적
            // worldMoveDir이 Vector3.forward에 얼마만큼 겹쳐있는지 확인
            // Vector3.Dot(0.0.1,Vector3.forward) = 1f 겹쳐져있음
            //Vector3.Dot(0.0.-1,Vector3.forward) = -1f 정 반대임
            // 키보드 w가 카메라가 바라보는 정면을 향하는 벡터가 될것임
            // 키보드 s가 카메라가 바라보는 방향의 정반대를 향하는 벡터가 될것임
            if (Mathf.Approximately(Vector3.Dot(worldMoveDir,Vector3.forward),-1f))
            {
                resultForward = -moveVec;
                // 바라봐야할 방향을 구하는 변수 
                targetRotation = Quaternion.LookRotation(-moveVec);
            }
            else
            {
                // 입력 벡터 worldMoveDir를 통해서 얼마만큼 회전값이 필요한지 구해야하기 때문에 
                // Quaternion.FromToRotation(Vector3.forward, worldMoveDir) = 회전값
                // 카메라가 바라보는 정면의 방향 벡터값
                // moveVec = 방향값
                resultForward = Quaternion.FromToRotation(Vector3.forward, worldMoveDir) * moveVec;
                targetRotation = Quaternion.LookRotation(resultForward);
            }

            float curAngle = transform.eulerAngles.y;
            float targetAngle = Mathf.Atan2(resultForward.x, resultForward.z) * Mathf.Rad2Deg;

            // 두 각도의 차이중 더 작은 값을 반환 (360를 넘어갈 수 있기 때문)
            float angleDiff = Mathf.DeltaAngle(curAngle, targetAngle);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 400f * Velocity * Time.deltaTime);

            Animator.SetFloat(AngleRad_Hash, angleDiff * Mathf.Deg2Rad);
        }

    }

    // 업데이트 이후 레이트 업데이트 이전에 호출 
    // 각 캐릭터들의 애니메이터들과 유기적으로 연동할것이기 때문에 사용? 
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
            // 공격이 들어온 방향 1.0.1
            // player forward 0.0.1인 경우
            // 1.0.1
            // player forward 0.0.-1인 경우
            // -1.0.-1

            // 공격이 들어온 방향 
            Vector3 hittedVector = attacker.position - transform.position;
            hittedVector.y = 0f;

            // 로컬 포지션 방향대로
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
