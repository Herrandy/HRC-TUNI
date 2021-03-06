# HRC-TUNI
## Maintainer
- [Antti Hietanen](https://research.tuni.fi/vision/) <<antti.hietanen@tuni.fi>>, [Tampere University](https://www.tuni.fi/en)


## Description
This repository contains libraries and tools for a depth-sensor based model for workspace monitoring and an interactive Augmented Reality (AR) User Interface (UI) for safe HRC. The AR UI is implemented on two different hardware: a projector-mirror setup and a wearable AR gear (HoloLens). 
The repository contains the following modules:
- [a projection-based user interface](https://github.com/Herrandy/HRC-TUNI/tree/master/projector)
- [a head-mounted AR (Hololens) user interface](https://github.com/Herrandy/HRC-TUNI/tree/master/ar)
- [a depth-based safety system](https://github.com/Herrandy/HRC-TUNI/tree/master/safety_model)

## Dependencies
- ROS Melodic
- OpenCV (2.4.x, using the one from the official Ubuntu repositories is recommended)
- PCL (1.8.x, using the one from the official Ubuntu repositories is recommended)
- [iai_kinect2](https://github.com/code-iai/iai_kinect2)
- [ROS-industrial Universal Robot](https://github.com/ros-industrial/universal_robot) and [UR modern driver](https://github.com/ros-industrial/ur_modern_driver)

## Required hardware
In order to replicate the research work the following hardware are required:
- UR5 from Universal Robot family (tested on CB3 and UR software 3.5.4)
- Standard 3LCD projector
- Flat worktable
- Hololens
- Computer

## Install
1. Install ROS. [Instructions for Ubuntu 18.04](http://wiki.ros.org/melodic/Installation/Ubuntu)
2. Install [iai_kinect2](https://github.com/code-iai/iai_kinect2):
3. Install [ROS-industrial for UR](https://github.com/ros-industrial/universal_robot) and [UR modern driver](https://github.com/ros-industrial/ur_modern_driver). Follow the instructions on the webpages.
4. Clone this repository into your catkin workspace, install the dependencies and build it:
    ```bash
    cd ~/catkin_ws/src/
    git clone https://github.com/Herrandy/HRC-TUNI.git
    cd HRC-TUNI
    rosdep install -r --from-paths .
    cd ~/catkin_ws
    catkin_make -DCMAKE_BUILD_TYPE="Release"
    ```    

## Running the real robot
1. Make wired connection between the robot and the computer, [instructions for Ubuntu.](http://wiki.ros.org/universal_robot/Tutorials/Getting%20Started%20with%20a%20Universal%20Robot%20and%20ROS-Industrial)

2. Test connection: ```ping <robot_ip>```. Check that data packages are recieved.

3. Start the robot interface: ```roslaunch ur_modern_driver ur5_bringup.launch robot_ip:=<robot_ip>```. Check that _/joint_states_ is getting updated.

## Running the robot simulator
### Install URsim simulator
For debugging and development download [URSim](https://www.universal-robots.com/download/?option=16594#section16593) and install:
1. Extract files: ```tar xvf <URSIM_TAR> ```
2. Run ```./install.sh```
3. Run inside the extracted URSIM_folder: ```chmod u=rwx,g=rx,o=r ``` 
4. Install and wwitch to java 8: ```sudo apt install openjdk-8-jdk && sudo update-alternatives --config java```
5. Start simulator: ```sudo ./start-ursim.sh```
    
## Simple projector demo
```
$ roslaunch ur_modern_driver ur5_bringup.launch robot_ip:=192.168.125.100
$ roslaunch kinect2_bridge kinect2_bridge.launch max_depth:=2.0 publish_tf:=true
$ rosrun projector projector_interface.py
$ rosrun projector handle_interaction_markers.py
$ rosrun robot dashboard_client.py
$ roslaunch safety_model detect.launch safety_map_scale:=100 cluster_tolerance:=0.005 min_cluster_size:=200 anomalies_threshold:=20 cloud_diff_threshold:=0.02 viz:=false
```

## Citation
This is the reference implementation for the paper:

**_AR-based interaction for human-robot collaborative manufacturing_** _A. Hietanen, R. Pieters, M. Lanz, J. Latokartano, J.-K. Kämäräinen_ 

[PDF](https://www.sciencedirect.com/science/article/pii/S0736584519307355) | [Video](https://youtu.be/-WW0a-LEGLM)


If you find this code useful in your work, please consider citing:
```tex
@article{hietanen2020ar,
  title={Ar-based interaction for human-robot collaborative manufacturing},
  author={Hietanen, Antti and Pieters, Roel and Lanz, Minna and Latokartano, Jyrki and K{\"a}m{\"a}r{\"a}inen, Joni-Kristian},
  journal={Robotics and Computer-Integrated Manufacturing},
  volume={63},
  pages={101891},
  year={2020},
  publisher={Elsevier}
}

```
