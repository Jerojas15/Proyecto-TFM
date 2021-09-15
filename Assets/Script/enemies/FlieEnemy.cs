using System.Collections;
using UnityEngine;

public class FlieEnemy : MonoBehaviour
{
    enum State { moving, targeting, attacking, dying };
    enum Rotation { down, up };

    [SerializeField] private float timeMoving;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float topAngle;
    [SerializeField] private float bottomAngle;
    [SerializeField] private GameObject raycastLauncher;
    [SerializeField] private int strength;

    private float startMovingTime = 0;
    private Rotation direction = Rotation.down;
    private State actualState = State.moving;
    private Vector3 targetPosition;

    void Start() {
    }

    void Update()
    {
        switch (actualState) {
            case State.moving:
                move();
                break;
            case State.targeting:
                searchTarget();
                break;
            case State.attacking:
                attack();
                break;
            case State.dying:
                die();
                break;
        }
    }

    private void move() {
        if (startMovingTime + Time.time < startMovingTime + timeMoving) {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        } else {
            actualState = State.targeting;
        }
    }

    private void searchTarget() {
        if (transform.rotation.eulerAngles.z > bottomAngle) {
            if (direction == Rotation.down) {
                direction = Rotation.up;
            } else if (direction == Rotation.up) {
                direction = Rotation.down;
            }
        }

        var rotationDirection = 1;
        if (direction == Rotation.up) {
            rotationDirection = -1;
        }
        
        transform.Rotate(rotationDirection * Vector3.forward, rotationSpeed * Time.deltaTime);
        Debug.DrawRay(raycastLauncher.transform.position, -transform.right * 20f, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(raycastLauncher.transform.position, -transform.right, 20f);

        if (hit.collider != null && hit.collider.transform.CompareTag("Player")) {
            actualState = State.attacking;
            targetPosition = hit.collider.transform.position;
        }
    }

    private void attack() {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, attackSpeed * Time.deltaTime);
       // die();
    }

    private void die() {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        Destroy(gameObject,2);

    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerP>().reducirVida(strength);
        }
        if (actualState == State.attacking) {
            actualState = State.dying;
        }
    }
}
