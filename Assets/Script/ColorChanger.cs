using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorChanger : MonoBehaviour {

    [SerializeField]
    private Volume volume;
    
    private bool isActive = false;

    [SerializeField]
    private GameObject farestPoint;

    [SerializeField]
    private GameObject startPoint;

    [SerializeField]
    private float fullRadius;

    [SerializeField]
    private GameObject player;

    private ColorAdjustments color;
    void Start() {
        volume.profile.TryGet<ColorAdjustments>(out color);
    }

    public void setColorFilter() {
        isActive = !isActive;

        if (volume && isActive) {
            color.colorFilter.value = new Color(0.584f, 0.559f, 1.774f, 1);
        } else {
            color.colorFilter.value = new Color(1, 1, 1, 0);
        }
    }

    void Update() {
        float playerDistance = Vector3.Distance(player.transform.position, startPoint.transform.position);
        float pointsDistance = Vector3.Distance(farestPoint.transform.position, startPoint.transform.position);
        if (Input.GetButtonDown("CambiarMundo")) {
            setColorFilter();
        }
        
        if (!isActive) {
            if (playerDistance < pointsDistance) {
                if (playerDistance <= fullRadius) {
                    color.colorFilter.value = new Color(1, 0.3f, 0.3f, 0);
                } else {
                    float percentage = 1 - (playerDistance / pointsDistance);
                    color.colorFilter.value = new Color(1, 1 - percentage, 1 - percentage, 0);
                }
            } else {
                color.colorFilter.value = new Color(1, 1, 1, 0);
            }
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(startPoint.transform.position, fullRadius);
    }
}