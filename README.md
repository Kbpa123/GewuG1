# 🐾 Unitree Unity 控制项目



通过 Unity 与 ROS 实现 Unitree 机器人（G1/Go2）的实时控制与交互。

## 🛠️ 安装依赖

请确保已经安装以下组件：

- **Unitree SDK 2 Python**
- **unitree_ros2**
- **ROS-TCP-Endpoint**


## ⚙️ 配置 ROS 环境

- **加载系统 ROS**
```bash
source /opt/ros/<ros版本>/setup.bash
```

- **加载 Unitree ROS2**
```bash
source ~/unitree_ros2/setup.sh
```

- **加载 ROS-TCP-Endpoint**
```bash
source ~/ros_tcp_endpoint/install/setup.bash
```

## ▶️ 运行流程

1. **启动 ROS TCP Endpoint**
```bash
ros2 run ros_tcp_endpoint default_server_endpoint --ros-args -p ros__parameters.ros_tcp_port:=10000
```

2. **运行对应的bridge.py**
```bash
python3 bridge.py
```
3.**启动 Unity**

打开 Unity 项目，运行对应场景

确保 ROS-TCP Connector 端口与 Endpoint 一致（默认 10000）

🔹 提示：source → 启动 Endpoint → 运行 bridge → 启动 Unity

🔹 提示：注意修改unity中Ros Connection组件的ip为本地ip




