using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using SocketIO;

public class Controller : MonoBehaviour {

    public Login login;
    public MoveNav nav;
    public Player playGameObj;
    public SocketIOComponent socket;

	// Use this for initialization
	void Start () {
        StartCoroutine(ConnectToServer());
        socket.On("USER_CONNECTED",OnUserConnected);
        socket.On("PLAY", OnUserPlay);
        socket.On("MOVE", OnUserMove);
        socket.On("USER_DISCONNECTED", OnUserDisconnected);
        
    }

    

    void OnUserMove (SocketIOEvent evt)
    {
        GameObject player = GameObject.Find(JsonToString(evt.data.GetField("name").ToString(), "\"")) as GameObject;
        player.transform.position = JsonToVecter3(JsonToString(evt.data.GetField("position").ToString(), "\""));

    }

    string JsonToString(string target, string s)
    {
        string[] newString = Regex.Split(target,s);
        return newString[1];
    }

    Vector3 JsonToVecter3(string target)
    {
        Vector3 newVector;
        string[] newString = Regex.Split(target, ",");
        newVector = new Vector3(float.Parse(newString[0]), float.Parse(newString[1]), float.Parse(newString[2]));
        return newVector;
    }


    void OnUserDisconnected(SocketIOEvent evt)
    {
        Destroy(GameObject.Find(JsonToString(evt.data.GetField("name").ToString(), "\"")));

    }

    void OnClickPlayBtn()
    {
        if(login.inputField.text != "")
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["name"] = login.inputField.text;
            Vector3 position = new Vector3(0, 0, 0);
            data["position"] = position.x + "," + position.y + "," + position.z;
            socket.Emit("PLAY", new JSONObject(data));

        }else
        {
            login.inputField.text = "please enter your name again";
        }
    }

    IEnumerator ConnectToServer()
    {
        yield return new WaitForSeconds(0.5f);
        socket.Emit("USER_CONNECT");
        yield return new WaitForSeconds(1f);
        Dictionary<string, string> data = new Dictionary<string, string>();
        Vector3 position = new Vector3(0, 0, 0);
        data["position"] = position.x + "," + position.y + "," + position.z;
        socket.Emit("PLAY", new JSONObject(data));

    }

    private void OnUserConnected(SocketIOEvent evt)
    {
        Debug.Log("Get the message from server is:" + evt.data + "OnUserConnected");
    }

    private void OnUserPlay(SocketIOEvent evt)
    {
        Debug.Log("Get the message from server is:" + evt.data + "OnUserPlay");
    }
}
