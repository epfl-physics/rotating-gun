using UnityEngine;

public class TheoryBasisVectors : MonoBehaviour
{
    public GameObject labBasisVectors;
    public GameObject gunBasisVectors;
    public SimulationState simState;

    private bool quantitiesTabIsActive;

    private void Awake()
    {
        HideAll();
    }

    public void SetCoordinatesTabVisibility(bool tabIsActive)
    {
        if (tabIsActive)
        {
            ShowAll();
        }
        else
        {
            HideAll();
        }
    }

    public void SetQuantitiesTabVisibility(bool tabIsActive)
    {
        HideAll();

        if (simState && tabIsActive)
        {
            switch (simState.referenceFrame)
            {
                case SimulationState.ReferenceFrame.Lab:
                    SetLabBasisVisibility(true);
                    SetGunBasisVisibility(false);
                    break;
                case SimulationState.ReferenceFrame.Gun:
                    SetLabBasisVisibility(false);
                    SetGunBasisVisibility(true);
                    break;
                default:
                    break;
            }
        }

        quantitiesTabIsActive = tabIsActive;
    }

    public void UpdateReferenceFrame(bool frameIsLab)
    {
        if (simState && quantitiesTabIsActive)
        {
            switch (simState.referenceFrame)
            {
                case SimulationState.ReferenceFrame.Lab:
                    SetLabBasisVisibility(true);
                    SetGunBasisVisibility(false);
                    break;
                case SimulationState.ReferenceFrame.Gun:
                    SetLabBasisVisibility(false);
                    SetGunBasisVisibility(true);
                    break;
                default:
                    break;
            }
        }
    }

    public void SetLabBasisVisibility(bool isVisible)
    {
        if (labBasisVectors) labBasisVectors.SetActive(isVisible);
    }

    public void SetGunBasisVisibility(bool isVisible)
    {
        if (gunBasisVectors) gunBasisVectors.SetActive(isVisible);
    }

    private void HideAll()
    {
        SetLabBasisVisibility(false);
        SetGunBasisVisibility(false);
    }

    private void ShowAll()
    {
        SetLabBasisVisibility(true);
        SetGunBasisVisibility(true);
    }
}
