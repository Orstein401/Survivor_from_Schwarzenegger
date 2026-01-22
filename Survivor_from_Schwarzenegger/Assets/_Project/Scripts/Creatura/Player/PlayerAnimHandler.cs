//using UnityEngine;

//public class PlayerAnimParamHandler : MonoBehaviour
//{
//    [SerializeField] private string MoveXName = "MoveX";
//    [SerializeField] private string MoveYName = "MoveY";
//    [SerializeField] private string isMovingName = "IsMoving";

//    private Animator _anim;
//    private Player _movement;

//    private bool IsMoving = false;


//    private void Awake()
//    {
//        _anim = GetComponentInChildren<Animator>();
//        _movement = GetComponent<Player>();
//    }

//    private void Update()
//    {
//        AnimationMove();
//    }

//    private void AnimationMove()
//    {
//        Vector2 dir = _movement.Direction;

//        bool isMoving = dir != Vector2.zero;

//        _anim.SetBool("IsMoving", true);
//        if (isMoving)
//        {
//            _anim.SetBool("IsMoving", true);
//            _anim.SetFloat("MoveX", dir.x);
//            _anim.SetFloat("MoveY", dir.y);
//        }
//        else { _anim.SetBool("IsMoving", false); }
//    }
//}

