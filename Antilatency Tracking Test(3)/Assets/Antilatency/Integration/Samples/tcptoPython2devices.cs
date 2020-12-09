using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Security;
using System;

public class tcptoPython2devices : MonoBehaviour
{
    public string IP = "127.0.0.1"; //
    public int Port = 1234;
    public byte[] dane;
    public Socket client;

    public float rx1;
    public float ry1;
    public float rz1;
    public float x1;
    public float y1;
    public float z1;

    public float rx2;
    public float ry2;
    public float rz2;
    public float x2;
    public float y2;
    public float z2;



    // Use this for initialization
    public void Changing()
    {




        //x1 = Camera.main.transform.position.x;


        rx1 = GameObject.Find("RightHandBracer").transform.rotation.eulerAngles.x;
        ry1 = GameObject.Find("RightHandBracer").transform.rotation.eulerAngles.y;
        rz1 = GameObject.Find("RightHandBracer").transform.rotation.eulerAngles.z;
        x1 = GameObject.Find("RightHandBracer").transform.position.x;
        y1 = GameObject.Find("RightHandBracer").transform.position.y;
        z1 = GameObject.Find("RightHandBracer").transform.position.z;


        rx2 = GameObject.Find("LeftHandBracer").transform.rotation.eulerAngles.x;
        ry2 = GameObject.Find("LeftHandBracer").transform.rotation.eulerAngles.y;
        rz2 = GameObject.Find("LeftHandBracer").transform.rotation.eulerAngles.z;
        x2 = GameObject.Find("LeftHandBracer").transform.position.x;
        y2 = GameObject.Find("LeftHandBracer").transform.position.y;
        z2 = GameObject.Find("LeftHandBracer").transform.position.z;



        int x = (int)x1;

        string rx = rx1.ToString();
        string ry = ry1.ToString();
        string rz = rz1.ToString();
        string x0 = x1.ToString();
        string y0 = y1.ToString();
        string z0 = z1.ToString();

        string rxb = rx2.ToString();
        string ryb = ry2.ToString();
        string rzb = rz2.ToString();
        string x0b = x2.ToString();
        string y0b = y2.ToString();
        string z0b = z2.ToString();


        dane = System.Text.Encoding.ASCII.GetBytes(x0 + ";" + y0 + ";" + z0 + ";" + rx + ";" + ry + ";" + rz + ";" + x0b + ";" + y0b + ";" + z0b + ";" + rxb + ";" + ryb + ";" + rzb);//encode string  data into byte for sending 
        client.Send(dane);//send data to port 
        byte[] b = new byte[1024];

        ////////////////////////////////////////////////////////
        //dane1 = System.Text.Encoding.ASCII.GetBytes(x0);//encode string  data into byte for sending 
        //dane2 = System.Text.Encoding.ASCII.GetBytes(y0);//encode string  data into byte for sending 
        //dane3 = System.Text.Encoding.ASCII.GetBytes(z0);//encode string  data into byte for sending 
        //client.Send(dane1);//send data to port 
        //client.Send(dane2);//send data to port 
        //client.Send(dane3);//send data to port 
        //byte[] b = new byte[1024];

        ////////////////////////////////////////




    }
    void Start()
    {
        //calling that function of sending and reciveing data 
        //Changing();
        client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(IP, Port);//connecting port with ip address 

    }

    void Update()
    {
        //if u want to chang again again so fast then cal that function herer
        Changing();

    }
}
