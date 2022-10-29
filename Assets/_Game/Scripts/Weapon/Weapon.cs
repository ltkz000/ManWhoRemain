using UnityEngine;

public class Weapon : MonoBehaviour
{
    public BoxCollider boxCollider;
    public Rigidbody rigidbody;
    public Transform transform;

    [SerializeField] private GameObject weaponObj;

    private CharacterCombatAbtract _attacker;
    private Vector3 rotate;
    private Vector3 lastPosition;
    private float rotateSpeed;

    [SerializeField] private float flySpeed;

    private void Start() 
    {
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
        FlyRotate();
        OutOfRange();
    }

    public void Fly(CharacterCombatAbtract attacker, Transform target)
    {
        _attacker = attacker;
        var velo = (target.position - transform.position).normalized * flySpeed;
        velo.y = 0;
        rigidbody.velocity = velo;   
        rotateSpeed = 600f;

        lastPosition = transform.position;
    }

    public void FlyRotate()
    {
        transform.Rotate(rotate * rotateSpeed * Time.deltaTime);
    }

    public void OutOfRange()
    {
        if(_attacker != null)
        {
            float distance = Vector3.Distance(transform.position, lastPosition);

            if(distance - 0.5f > _attacker.attackRange)
            {
                _attacker.PoolBackWeapon(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        CharacterCombatAbtract characterCombat = CachedCollision.GetCharacterCombatCollider(other);
        if(characterCombat != null)
        {
            OnTarGet(characterCombat);
        }

        if(other.CompareTag(ConstValues.OBSTACLE_TAG))
        {
            _attacker.PoolBackWeapon(this.gameObject);
        }
    }

    private void OnTarGet(CharacterCombatAbtract target)
    {
        target.BeingKilled();
        target.PoolBackWeapon(gameObject);
        _attacker.UpdateOnKill(target);
    }   
}
