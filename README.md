# Installation Procedure

This short and simple manual is intended to help the community use our proposed framework for Edge computing, Cloud computing and NDN experimentation. Our framework integrates ndnSIM, Edge Computing and Cloud computing. However, our code and framework could also be used for standalone Edge/Cloud computing purposes. Moreover, if one’s is not familiar with ndnSIM or their research area is not NDN, then they could also use their own tool to generate requests from end user devices and can avail the benefits of Edge Cloud computing.  In order to enable the operation between ndnSIM and Edge Cloud Computing, we need some changes in some specific files and are discussed as follows:
Basically, there are 3 major parts of our system 1) NDN 2) Edge Computing 3) Cloud Computing. Following steps details the procedure. 

## NDN related Code changes:
NDN related changes are implemented in ndnSIM simulator. We have changed the files (ndn-producer.cpp and ndn-producer.hpp) in the apps folder of ndnSIM. 
The installation procedure is straight forward for ndnSIM and similar to the one of official ndnSIM. However once ndnSIM is downloaded and installed then following changes should be done in order to connect ndnSIM with Edge/and Cloud application. 
At our GitHub page, under NEC/ndnSIM/apps/ndn-producer.cpp file the code written in following function needs to be added in order to connect ndnSIM with Edge or Cloud application.

Producer::GetContentFromEdge()

However, one’s may do changes in ndnSIM according their own application or project’s requirements.   

## Edge Application.

Edge and Cloud applications are developed (from scratch) in Microsoft Visual Studio 2017 community edition. For the Edge application, you may check the code in following path / github folder.

## NEC/Edge/
Download all the code from NEC/Edge. Once download then to run the Edge application first you need to publish all of the files in Visual Studio. In order to publish the code, we recommend the Visual Studio 2017 version. Once the code is published, all of published files can be deployed in Internet Information Services (IIS). IIS is used in order to host websites, web applications and services needed by users or developers such as APIs and Web Interfaces.
The detail of deployment can be found in following link.  
https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/visual-studio-web-deployment/deploying-to-iis

It is recommended to publish  Web Application and Web API separately in order to run both of these application under separate application pool.

## Cloud Application.

Cloud application can be deployed same as the Edge Application. However, it is recommended to deploy Cloud application on Microsoft Azure or Amazon web server. The rationale of deploying the Cloud application on Microsoft Azure or Amazon is that this application must be at multiple hop distance from the Edge tier and things/devices tier so that you can test better latency related measurements.  If you don't have Microsoft Azure or Amazon server then you can deploy it on any powerful machine but make sure that machine must be at multiple hops distance. 

For tracing  results you may also use our self-developed application available on our GitHub page under NEC/Tracehelper. To aid better understanding we also provide a sample tracefile.txt in NEC/Tracehelper/Tracehelper/TraceFile/ 

