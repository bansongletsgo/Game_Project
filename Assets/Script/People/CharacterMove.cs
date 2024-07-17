using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    static public CharacterMove instance;
    public string currentMapName;
    private BoxCollider2D boxCollider;
    public LayerMask layerMask;
    public float speed; //일반 속도
    private Vector3 vector; //위치 벡터값
    public float runSpeed; //쉬프트 달리기 속도
    private float applyRunSpeed; //달리기 속도 적용
    private bool applyRunFlag = false;
    public float walkCount;
    private float currentWalkCount;
    private bool canMove = true;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            boxCollider = GetComponent<BoxCollider2D>();
            animator = GetComponent<Animator>();
        }
        else{
            Destroy(this.gameObject);
        }
        
    }
    IEnumerator MoveCoroutine(){
        while(Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical")!=0){
            if(Input.GetKey(KeyCode.LeftShift)){
            applyRunSpeed = runSpeed;
            applyRunFlag = true;
        }
        else
        {
            applyRunSpeed = 0;
            applyRunFlag = false;
        }
            
        vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);
        if(vector.x!=0){
            vector.y = 0;
        }

        animator.SetFloat("DirX", vector.x);
        animator.SetFloat("DirY", vector.y);

        RaycastHit2D hit;
        Vector2 start = transform.position;; //현재 캐릭터 위치
        Vector2 end = start + new Vector2(vector.x * speed * walkCount, vector.y * speed * walkCount); //이동하고자 하는 위치

        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, layerMask);
        boxCollider.enabled = true;

        if(hit.transform != null)break;

        animator.SetBool("Walking", true);

        while(currentWalkCount<walkCount){
            if(vector.x != 0){
                transform.Translate(vector.x*(speed+applyRunSpeed), 0, 0);
            }
            else if(vector.y != 0){
                transform.Translate(0, vector.y*(speed+applyRunSpeed), 0);
            }
            if(applyRunFlag){
                currentWalkCount++;
            }
            currentWalkCount++;
            yield return new WaitForSeconds(0.005f);   
        }
        currentWalkCount = 0;
        }

        animator.SetBool("Walking", false);
        canMove = true;
    }
    // Update is called once per frame
    void Update()
    {   
        if(canMove){
           if(Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical")!=0){
                canMove = false;
                StartCoroutine(MoveCoroutine());
            } 
        }
    }
}
