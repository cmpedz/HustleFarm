
using UnityEngine;


public class AnimalMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speedMove;

    [SerializeField] private float timeRunning;

    private bool isRunning = false;
    public bool IsRunning
    {
        get { return isRunning; }
    }

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

        float signPosXOfDirection = direction.x / Mathf.Abs(direction.x);

        transform.localScale = new Vector2(transform.localScale.x * -1 * signPosXOfDirection, transform.localScale.y);
    }

    public void ReverseDirection(){
        direction = new Vector2(direction.x * -1, direction.y * -1);
    }

}
