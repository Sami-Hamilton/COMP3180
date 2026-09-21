using UnityEngine;
using System.IO;
public class DataWriter : MonoBehaviour
{
    private string folder = "DataLogs";
    [SerializeField] private string playtestName = "Report";
    private string reportName;
    private string folderpath;
    private int nReports = 0;
    private string dataFilepath;
    private string[] dataColumnHeaders = { "Test Column" };
    private string dataLineFormat;
    private StreamWriter dataAnalyticsLog = null;
    void Start()
    {
       OpenWriters();
    }

    private void OpenWriters()
    {
        if (nReports == 0)
        {
            playtestName += string.Format("{0:dd-MM-yyyy-HH-mm-ss}", System.DateTime.Now);
        }
        reportName = playtestName;
        reportName += " Report " + (nReports + 1);

        folderpath = Path.Combine(Application.persistentDataPath, folder, reportName);
        if (!Directory.Exists(folderpath))
        {
            Directory.CreateDirectory(folderpath);
        }

        dataFilepath = Path.Combine(folderpath, "Data.csv");
        dataAnalyticsLog = new StreamWriter(dataFilepath);

        dataLineFormat = SetupLog(dataAnalyticsLog, dataColumnHeaders);
    }

    public void EndReport()
    {
        dataAnalyticsLog?.Close();
        nReports++;
        OpenWriters();
    }

    void OnDestroy()
    {
        dataAnalyticsLog?.Close();
    }

    private string SetupLog(StreamWriter log, string[] columnHeaders)
    {
        log.WriteLine(string.Join(",", columnHeaders));
        log.Flush();
        string lineFormat = "";
        for (int i = 0; i < columnHeaders.Length; i++)
        {
            if (i > 0)
            {
                lineFormat += ",";
            }
            lineFormat += string.Format("{{{0}}}", i);
        }
        return lineFormat;
    }

    public void WriteDataLine(params object[] data)
    {
        if (data.Length != dataColumnHeaders.Length)
        {
            Debug.LogError("Unexpected number of arguments to Data File");
        }
        dataAnalyticsLog.WriteLine(dataLineFormat, data);
        dataAnalyticsLog.Flush();
    }
}