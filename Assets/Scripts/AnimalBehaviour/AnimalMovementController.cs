
using System.Collections.Generic;
using UnityEngine;


public class AnimalMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speedMove;

    [SerializeField] private float timeRunning;

    [SerializeField] private List<GameObject> objectsCantBeFlipped = new List<GameObject>();

    private bool isRunning = false;
    public bool IsRunning
    {
        get { return isRunning; }
    }

    private bool isFlip = false;

    [SerializeField] private float timeStanding;

    private float timeRun;

    [SerializeField] private Vector3 direction;

    private Animator animator;
    void Start()
    {
        timeRun = Time.time;

        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        ControlAnimalMove();

        ControlAnimalStatus();
    }

    private void ControlAnimalMove() {

        if (isRunning) {
            Debug.Log("check speed move : " + speedMove * Time.deltaTime);
            transform.position += direction * speedMove * Time.deltaTime;

        }
    }

    private void ControlAnimalStatus() {

        if (!isRunning && Time.time - timeRun > timeStanding) {

            animator.SetBool("ChangeMove", true);

            isRunning = true;

            timeRun = Time.time;

            ChangeDirection();

        }
        else
        {
            if (Time.time - timeRun > timeRunning && isRunning) {

                timeRun = Time.time;

                animator.SetBool("ChangeMove", false);

                isRunning = false;
            }
        }
    }

    public void ChangeDirection() {

        direction = Random.insideUnitCircle;

        CheckFlippingCondition();

    }

    public void ReverseDirection(){

        direction = new Vector2(direction.x * -1, direction.y * -1);

        CheckFlippingCondition();
    }

    private void CheckFlippingCondition() {

        Debug.Log("check direction : " + direction);

        if (direction.x > 0 && !isFlip) {

            isFlip = true;

            Flip(180f);


        }

        if (direction.x < 0 && isFlip)
        {

            isFlip = false;

            Flip(0f);
        }


    }

    private void Flip(float angleFlip) {

        Quaternion rotation = Quaternion.Euler(0f, angleFlip, 0f);

        transform.localRotation = rotation;

        foreach(GameObject _object in objectsCantBeFlipped){
            _object.transform.localRotation = rotation;
        }
    }

}
