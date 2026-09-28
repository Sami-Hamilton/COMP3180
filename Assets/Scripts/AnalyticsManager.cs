using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DataWriter))]
public class AnalyticsManager : MonoBehaviour
{
    private DataWriter datalog;
    private bool started = false;

    static private AnalyticsManager instance;
    static public AnalyticsManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("No AnalyticsManager");
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }


    void Start()
    {
        datalog = gameObject.GetComponent<DataWriter>();
    }

    public void StartRecording()
    {
        started = true;
    }

    public void StopRecording()
    {
        datalog.EndReport();
        started = false;
    }


    //Writing Methods
    public void StartLookingFrame(string frameName)
    {
        if (datalog != null && started)
        {
            datalog.WriteDataLine(
                frameName,
                "Start Looking",
                string.Format("{0:HH:mm:ss.FFFFFFF}", System.DateTime.Now)
            );
        }
    }

    public void StopLookingFrame(string frameName)
    {
        if (datalog != null && started)
        {
            datalog.WriteDataLine(
                frameName,
                "Stop Looking",
                string.Format("{0:HH:mm:ss.FFFFFFF}", System.DateTime.Now)
            );
        }
    }
}