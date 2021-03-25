using UnityEngine;

public class ModelManager : MonoBehaviour
{
    [SerializeField] Transform AlignedModel;

    public static ModelManager Instance;
    void Awake()
    {
        Instance = this;
    }

    public void AlignModel(Transform wallQR, Transform ghostQR)
    {
        AlignedModel.rotation = wallQR.rotation;
        AlignedModel.position = wallQR.position;
        var offset = wallQR.position - ghostQR.position;
        AlignedModel.transform.position += offset;

        Quaternion rotationDifference = wallQR.rotation * Quaternion.Inverse(ghostQR.rotation);
        var newRotation = rotationDifference * AlignedModel.rotation;
        AlignedModel.rotation = newRotation;

        var specialOffset = wallQR.position - ghostQR.position;
        AlignedModel.position += specialOffset;
    }
}
