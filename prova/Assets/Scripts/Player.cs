using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    [SerializeField] private GameObject bullet;
    private InputSystem_Actions inputActions;
    private Rigidbody2D _rb;
    private float timeCooldown = 0.5f;
    private float initialTime = 0.5f;
    [SerializeField] private Transform _shootPoint;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
        _shootPoint = GetComponentInChildren<Transform>().GetChild(0);
    }
    private void OnEnable()
    {
        inputActions.Enable();
        
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 8)
            GameOver();
    }
    public void GameOver()
    {
        inputActions.Disable();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (Time.time >= timeCooldown && context.performed)
        {
            Instantiate(bullet, _shootPoint.position, Quaternion.identity);
            timeCooldown = initialTime + Time.time;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _rb.linearVelocity = context.ReadValue<Vector2>() * 4;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 clickPoint = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            RaycastHit2D hit = Physics2D.Raycast(clickPoint, Vector3.forward, 12f);
            if (hit)
            {
                AudioClip clip = null;
                foreach (var kvp in AudioManager.Instance.clipList)
                {
                    if (AudioManager.Instance.clipList.ContainsKey(AudioClips.Yamete))
                        clip = kvp.Value;
                }
                AudioSource aSource = GetComponent<AudioSource>();
                if (clip != null)
                {
                    aSource.clip = clip;
                }
                aSource.Play();
            }
            
            //AudioManager.Instance.clipList.ContainsKey(AudioClips.Yamete);
         }
        //    Debug.Log(context.ReadValue<Vector2>());
        /*Debug.Log(Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()));

        //Ray ray = Camera.main.ScreenPointToRay(context.ReadValue<Vector2>());
        //if (Physics.Raycast(ray, ))
        Ray ray;
        Vector3 origin = Input.mousePosition;*/
    }
}
