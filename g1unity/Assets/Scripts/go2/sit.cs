using System.Collections;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;

public class Go2UnityControl : MonoBehaviour
{
    private ROSConnection ros;
    public string cmdTopic = "/go2_cmd";

    // 循环站立/坐下时间
    public float standDuration = 3f;
    public float sitDuration = 3f;

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<StringMsg>(cmdTopic);

        StartCoroutine(StandSitLoop());
    }

    private IEnumerator StandSitLoop()
    {
        while (true)
        {
            SendCommand("stand_up");
            Debug.Log("Unity发送站立命令");
            yield return new WaitForSeconds(standDuration);

            SendCommand("stand_down");
            Debug.Log("Unity发送坐下命令");
            yield return new WaitForSeconds(sitDuration);
        }
    }

    private void SendCommand(string cmd)
    {
        StringMsg msg = new StringMsg(cmd);
        ros.Publish(cmdTopic, msg);
    }
}
