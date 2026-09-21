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

    void Update()
    {
        if (started)
        {
            UpdateWriteData();
        }
    }

    public void StartRecord()
    {
        if (!started)
        {
            StartWriteData();
            started = true;
        }
    }

    public void EndRecord()
    {
        if (datalog != null && started)
        {
            StopWriteData();
        }
        datalog.EndReport();
        started = false;
    }

    //Writing Methods
    private void StartWriteData()
    {
        if (datalog != null)
        {
            datalog.WriteDataLine(
                "START!"
                );
        }
    }
    private void UpdateWriteData()
    {
        if (datalog != null)
        {
            datalog.WriteDataLine(
                "UPDATE!"
                );
        }
    }
    private void StopWriteData()
    {
        if (datalog != null)
        {
            datalog.WriteDataLine(
                "STOP!"
                );
        }
    }
}