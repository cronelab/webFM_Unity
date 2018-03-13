//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using WebSocketSharp;
//public class WebSocketTest : MonoBehaviour
//{

//    // Use this for initialization
//    public WebSocket ws;
//    void Start()
//    {
//        ws = new WebSocket("ws://127.0.0.1:20100");
//        ws.Connect();

//        //print(ws);
//    }

//    // Update is called once per frame
//    public void testMess()
//    {
//        ws.OnMessage += (sender, e) =>
//                print(e.Data);

//        ws.Send("A");
//    }

//    void onClose()
//    {
//        ws.Close();

//    }
//}
