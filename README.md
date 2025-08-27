需要安装
unitree_sdk2_python;
unitree_ros2;
ROS-TCP-Endpoint;

运行流程：
source ros(包括ROS-TCP-Endpoint，unitree_ros2,系统 ros）


启动Endpoint
ros2 run ros_tcp_endpoint default_server_endpoint --ros-args -p ros__parameters.ros_tcp_port:=10000


运行对应的bridge.py


运行unity
