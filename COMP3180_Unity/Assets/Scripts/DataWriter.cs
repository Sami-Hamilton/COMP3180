using UnityEngine;
using System.IO;
public class DataWriter : MonoBehaviour
{
    private string folder = "DataLogs";
    [SerializeField] private string participantNumber = "x";
    private string fileName;
    private string folderpath;
    private string dataFilepath;
    private string[] dataColumnHeaders = { "Frame Name", "Start/Stop Looking", "Time" };
    private string dataLineFormat;
    private StreamWriter dataAnalyticsLog = null;
    void Start()
    {
       OpenWriters();
    }

    private void OpenWriters()
    {
        fileName = "Participant " + participantNumber + " " + string.Format("{0:dd-MM-yyyy-HH-mm-ss}", System.DateTime.Now) + ".csv";

        folderpath = Path.Combine(Application.persistentDataPath, folder);
        if (!Directory.Exists(folderpath))
        {
            Directory.CreateDirectory(folderpath);
        }

        dataFilepath = Path.Combine(folderpath, fileName);
        dataAnalyticsLog = new StreamWriter(dataFilepath);

        dataLineFormat = SetupLog(dataAnalyticsLog, dataColumnHeaders);
    }

    public void EndReport()
    {
        dataAnalyticsLog?.Close();
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