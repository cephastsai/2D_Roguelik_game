using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

public class Reader : MonoBehaviour
{

    private FileInfo theSourceFile = null;
    private StreamReader StreamReader = null;
    private string text = " ";
    private String[] oringinData = new String[50];
    private int i = 0;

    // Use this for initialization
    void Start()
    {
        theSourceFile = new FileInfo("Assets/Resources/test.txt");
        StreamReader = theSourceFile.OpenText();
        if (text != null)
        {
            //ReadToEnd:可以將文件從頭讀到尾
            //ReadLine:只可讀取文件的一行文字
            text = StreamReader.ReadToEnd();
            oringinData[i] = text;
            Debug.Log("test:" + oringinData[i]);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
