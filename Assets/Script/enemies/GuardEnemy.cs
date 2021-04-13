using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardEnemy : MonoBehaviour
{
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject end;
    [SerializeField] private float speed;
    [SerializeField] private int strength;
    private int target;

    // Start is called before the first frame update
    void Start()
    {
        target = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Transform actualTarget = start.transform;
        if (target == 1) {
            actualTarget = end.transform;
        }
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, actualTarget.localPosition, speed * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject == start || collision.gameObject == end) {
            target = 1 - target;
        } else if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerP>().reducirVida(strength);
        }
    }
}
