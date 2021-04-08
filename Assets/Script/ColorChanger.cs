using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ColorChanger : MonoBehaviour {
    ColorGrading colorGrading;
    private bool isActive = false;

    [SerializeField]
    private GameObject farestPoint;

    [SerializeField]
    private GameObject startPoint;

    [SerializeField]
    private GameObject player;

    void Start() {
        GetComponent<PostProcessVolume>().profile.TryGetSettings(out colorGrading);
    }

    public void setColorFilter() {
        isActive = !isActive;
        colorGrading.active = isActive;

        if (colorGrading && isActive) {
            colorGrading.enabled.value = true;
            colorGrading.colorFilter.value = new Color(0.584f, 0.559f, 1.774f, 1);
            colorGrading.lift.value = new Vector4(0, 0, 1, 0);
            colorGrading.gamma.value = new Vector4(0, 0, 1, 0);
            colorGrading.gain.value = new Vector4(0, 0, 1, 0);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            setColorFilter();
        }
        float playerDistance = Vector3.Distance(player.transform.position, startPoint.transform.position);
        float pointsDistance = Vector3.Distance(farestPoint.transform.position, startPoint.transform.position);

        if (!isActive) {
            if (playerDistance < pointsDistance) {
                colorGrading.active = true;
                float percentage = 1 - (playerDistance / pointsDistance);
                colorGrading.enabled.value = true;
                colorGrading.colorFilter.value = new Color(0.584f, 0.559f, 1.774f, 1);
                colorGrading.lift.value = new Vector4(1 * percentage, 0, 0, 0);
                colorGrading.gamma.value = new Vector4(1 * percentage, 0, 0, 0);
                colorGrading.gain.value = new Vector4(1 * percentage, 0, 0, 0);
            } else {
                colorGrading.active = false;
            }
        }
    }
}