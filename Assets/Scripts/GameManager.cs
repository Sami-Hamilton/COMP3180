using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AnalyticsManager))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] panels = new GameObject[8];
    [SerializeField] private GameObject[] frames = new GameObject[8];
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject furniture;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject playerLocomotion;
    [Range(0, 1)]
    [SerializeField] private int testVersion = 0;
    private int trial = 0;
    private int[,] trialVersions = new int[,] { { 1, 3, 6, 5, 7, 4, 0, 2 }, { 0, 2, 7, 4, 6, 5, 1, 3 } };
    private Vector3 playerPosition;
    private Quaternion playerRotation;
    private AnalyticsManager analytics;

    static private GameManager instance;
    static public GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("No GameManager");
            }
            return instance;
        }
    }


    void Start()
    {
        analytics = gameObject.GetComponent<AnalyticsManager>();
        panels[trialVersions[testVersion, trial]].SetActive(true);
        playerPosition = playerTransform.position;
        playerRotation = playerTransform.rotation;
        playerLocomotion.SetActive(false);
        furniture.SetActive(false);
    }

    public void startTrial()
    {
        analytics.StartRecording((trialVersions[testVersion, trial] + 1) + "");
        furniture.SetActive(true);
        playerLocomotion.SetActive(true);
        panels[trialVersions[testVersion, trial]].SetActive(false);
        frames[trialVersions[testVersion, trial]].SetActive(true);
    }

    public void endTrial()
    {
        analytics.StopRecording();
        furniture.SetActive(false);
        playerTransform.SetPositionAndRotation(playerPosition, playerRotation);
        playerLocomotion.SetActive(false);
        frames[trialVersions[testVersion, trial]].SetActive(false);

        trial++;

        if (trial >= 8)
        {
            endPanel.SetActive(true);
        }
        else
        {
            panels[trialVersions[testVersion, trial]].SetActive(true);
        }
    }
}