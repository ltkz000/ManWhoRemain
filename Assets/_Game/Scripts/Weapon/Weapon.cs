using UnityEngine;

public class Weapon : MonoBehaviour
{
    public BoxCollider boxCollider;
    public Transform weaponTransform;

    [SerializeField] protected GameObject weaponObj;

    protected CharacterCombatAbtract _attacker;
    protected Vector2 targetPos;
    protected Transform _target;
    protected Vector3 rotate;
    protected Vector3 flyVector;
    protected Vector3 lastPosition;
    protected float rotateSpeed;
    protected bool isStuck;
    [SerializeField] protected bool isFlyback;
    protected float timerStuck;
    protected float timerComeback;

    [SerializeField] private float flySpeed;

    private void Start() 
    {
        isFlyback = false;
        rotate = new Vector3(0, 1, 0);
    }

    public void InitOnHand()
    {
        weaponObj.SetActive(true);
        boxCollider.enabled = false;
    }

    public void DisappearOnHand()
    {
        weaponObj.SetActive(false);
    }

    public void AppearOnHand()
    {
        weaponObj.SetActive(true);
    }

    private void Update() 
    {
        if(!isStuck)
        {
            FlyRotate();
        }  

        OutOfRange();

        if(isStuck)
        {
            timerStuck += Time.deltaTime;

            if(timerStuck >= ConstValues.WEAPONSTUCK_TIME)
            {
                _attacker.PoolBackWeapon(this.gameObject);
                timerStuck = 0;
                isStuck = false;
            }
        }
    }

    public void  Fly(CharacterCombatAbtract attacker, Transform target)
    {
        isFlyback = false;
        rotateSpeed = 600f;

        _attacker = attacker;
        flyVector = Vector3.zero;
        flyVector.x = target.position.x - _attacker.characterTransform.position.x;
        flyVector.z = target.position.z - _attacker.characterTransform.position.z;
        flyVector = flyVector.normalized;

        lastPosition = weaponTransform.position;
    }

    public void FlyRotate()
    {
        weaponTransform.Rotate(rotate * rotateSpeed * Time.deltaTime);
        if(isFlyback)
        {
            timerComeback += Time.deltaTime;

            Vector3 comebackPos = _attacker.characterTransform.position;
            comebackPos.y = weaponTransform.position.y;

            weaponTransform.position = Vector3.MoveTowards(weaponTransform.position, comebackPos, Time.deltaTime * flySpeed);

            if(timerComeback > ConstValues.WEAPONSTUCK_TIME)
            {
                _attacker.PoolBackWeapon(gameObject);
                timerComeback = 0;
            }
        }
        else
        {
            weaponTransform.position = Vector3.MoveTowards(weaponTransform.position, weaponTransform.position + flyVector, Time.deltaTime * flySpeed);
        }
        
    }

    public virtual void OutOfRange()
    {
        if(_attacker != null)
        {
            float distance = Vector3.Distance(weaponTransform.position, lastPosition);

            if(distance > _attacker.attackRange - 1f)
            {
                _attacker.PoolBackWeapon(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        CharacterCombatAbtract characterCombat = CachedCollision.GetCharacterCombatCollider(other);
        
        if(characterCombat != null && characterCombat != _attacker)
        {
            OnTarGet(characterCombat);
        }

        if(characterCombat == _attacker)
        {
            _attacker.PoolBackWeapon(this.gameObject);
            isFlyback = false;
            timerComeback = 0;
        }

        if(other.CompareTag(ConstValues.OBSTACLE_TAG))
        {
            isStuck = true;
        }

        // IHit hit = other.GetComponent<IHit>();

        // if(hit != null)
        // {
        //     hit.OnHit();
        // }
    }

    private void OnTarGet(CharacterCombatAbtract target)
    {
        target.BeingKilled();
        _attacker.PoolBackWeapon(gameObject);
        _attacker.UpdateOnKill(target);
    }   
}
