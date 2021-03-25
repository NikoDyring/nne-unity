using TMPro;
using UnityEngine;

public class DisplayDataCube : MonoBehaviour
{

    [SerializeField] GameObject canvas;
    [SerializeField] TextMeshProUGUI idText;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI colorText;
    [SerializeField] TextMeshProUGUI percentageText;
    [SerializeField] TextMeshProUGUI lastEditText;
    [SerializeField] TextMeshProUGUI detailedDescriptionText;

    DataCube data;

    // Simple singleton
    public static DisplayDataCube Instance;

    private void Awake()
    {
        Instance = this;

        // Add close event listener
    }

    public DisplayDataCube SetData(DataCube data)
    {
        idText.text = data.ID.ToString();
        colorText.text = data.Name;
        infoText.text = data.Info;
        percentageText.text = data.Percentage.ToString();
        lastEditText.text = data.LastEdit;
        detailedDescriptionText.text = data.DetailedDescription;

        return Instance;
    }

    public void Show()
    {
        canvas.SetActive(true);
    }

    public void Hide()
    {
        canvas.SetActive(false);
    }

}