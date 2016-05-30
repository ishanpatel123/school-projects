using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;
using System.Threading;

public class COM : MonoBehaviour {
	
	public SerialPort sPort;
	public Thread sThread;
	public int bytes;
	public static float xAxis,yAxis,zAxis;
	bool connectOnce = false;

	void Start () {
		sPort = new SerialPort("\\\\.\\COM19", 9600);
	}
	
	void Update () { 
		if (connectOnce == false) {
			connect ();
			connectOnce = true;
		}	
	}
	
	void connect() {
		try 
		{
			sPort.Open();
			sPort.Handshake = Handshake.None;
			sThread = new Thread(receiveData);
			sThread.Start ();
		}
		catch (SystemException e)
		{
			Debug.Log ("Error: "+e.Message);
		}
		
	}
	
	void receiveData() {
		if ((sPort != null) && (sPort.IsOpen)) 
		{
			byte temp;
			string dataRec = "";
			string avalues = "";
			temp = (byte)sPort.ReadByte();
			while(temp !=255) 
			{
				dataRec += ((char)temp);
				temp = (byte)sPort.ReadByte();
				if((temp=='>') && (dataRec.Length > 30))
				{
					avalues = dataRec;
					parseString(avalues);
					dataRec = "";
				}
			}
		}
	}
	
	void parseString(string line) 
	{
		string[] split = line.Split (',');
		xAxis = float.Parse (split [2]);
		yAxis = float.Parse (split [3]);
		zAxis = float.Parse (split [4]);
	}
}