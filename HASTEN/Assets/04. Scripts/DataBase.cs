using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class DataBase : MonoBehaviour
{
    public string dbURL;
    // Start is called before the first frame update
    void Start()
    {
        dbURL = "http://localhost/";
    }

    IEnumerator dbConn()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("Stage", GameMgr.getInst().Stage);

        UnityWebRequest webRequest = UnityWebRequest.Post(dbURL, wwwForm);
        yield return webRequest.SendWebRequest();
        //WWW webRequest = new WWW(dbURL, wwwForm);
        
        //yield return webRequest;


        //form.AddField("id", New_IDInputField.text);
        //form.AddField("pwd", New_PassInputField.text);

        //WWW webRequest = new WWW(CreateUrl, form);
        //yield return webRequest;

        //Debug.Log(webRequest.text);

        //yield return null;
    }
}
