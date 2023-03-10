using UnityEngine;

public class RotatingGunSlideController : Slides.SimulationSlideController
{
    public float angularFrequency;
    public SimulationState.ReferenceFrame referenceFrame;
    public bool traceBulletPath;
    public bool showPosition;

    [Header("Lights")]
    public GameObject labFrameLight;
    public bool activateLabFrameLight;
    public GameObject gunFrameLight;
    public bool activateGunFrameLight;

    [Header("Inset Camera")]
    public Camera insetCamera;
    public bool showInsetCamera;

    [Header("Ground")]
    public Transform ground;
    public bool showGround;

    private RotatingGunSimulation sim;
    private bool hasInitialized;

    private Vector3 cameraPosition;
    private Quaternion cameraRotation;

    public override void InitializeSlide()
    {
        sim = simulation as RotatingGunSimulation;
        sim.angularFrequency = angularFrequency;
        sim.referenceFrame = referenceFrame;
        sim.traceBulletPath = traceBulletPath;
        sim.showPosition = showPosition;
        sim.Pause();

        if (labFrameLight) labFrameLight.SetActive(activateLabFrameLight);
        if (gunFrameLight) gunFrameLight.SetActive(activateGunFrameLight);
        if (insetCamera) insetCamera.gameObject.SetActive(false);
        if (ground) ground.gameObject.SetActive(showGround);

        hasInitialized = true;
    }

    private void OnEnable()
    {
        Slides.CameraController.OnCameraFinishTransition += HandleCameraTransitionComplete;
    }

    private void OnDisable()
    {
        Slides.CameraController.OnCameraFinishTransition -= HandleCameraTransitionComplete;

        // Reset the positions and orientations of the camera and simulation
        if (hasInitialized) sim.Reset(cameraPosition, cameraRotation);
    }

    public void HandleCameraTransitionComplete(Vector3 cameraPosition, Quaternion cameraRotation)
    {
        if (enabled)
        {
            this.cameraPosition = cameraPosition;
            this.cameraRotation = cameraRotation;
            sim.Resume();

            if (insetCamera) insetCamera.gameObject.SetActive(showInsetCamera);
        }
    }
}
