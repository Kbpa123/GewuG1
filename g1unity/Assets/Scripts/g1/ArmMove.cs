using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnitreeHg;

public class HandKeyboardControl : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "/hand_cmd";

    // 手臂关节数，根据机器人的手定义
    public int motorCount = 5;

    // 保存手臂目标命令
    private MotorCmdMsg[] motorCmdArray;

    void Start()
    {
        // 获取 ROSConnection 实例
        ros = ROSConnection.instance;
        ros.RegisterPublisher<HandCmdMsg>(topicName);

        // 初始化 motor_cmd 数组
        motorCmdArray = new MotorCmdMsg[motorCount];
        for (int i = 0; i < motorCount; i++)
        {
            motorCmdArray[i] = new MotorCmdMsg();
        }
    }

    void Update()
    {
        // 创建 HandCmdMsg
        HandCmdMsg handCmd = new HandCmdMsg();
        handCmd.motor_cmd = motorCmdArray;

        // 键盘控制示例（假设 W/S 控制第 0 个关节，A/D 控制第 1 个关节）
        float speed = 0.99f; // 每帧增量
        if (Input.GetKey(KeyCode.W))
            motorCmdArray[0].q += speed;
        if (Input.GetKey(KeyCode.S))
            motorCmdArray[0].q -= speed;
        if (Input.GetKey(KeyCode.A))
            motorCmdArray[1].q += speed;
        if (Input.GetKey(KeyCode.D))
            motorCmdArray[1].q -= speed;

        // 可以根据需要增加更多按键控制其他关节

        // 发布消息
        ros.Publish(topicName, handCmd);
    }
}
