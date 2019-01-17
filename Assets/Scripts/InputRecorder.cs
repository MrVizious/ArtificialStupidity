using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{

    private string path;
    private float startTime;
    private List<Tuple<string, float>> actions;



    void Start(){
        //Empty List of actions and times
        actions = new List<Tuple<string, float>>();
        //startTime begins with a negative value until the start button is pressed
        startTime = -1f;

        //Debugger of the created path
        if(debugPath){
            //Path  of the file created using the current time as name
            path = Application.dataPath + "/InputLogs/" + DateTime.Now.ToString("dd_MM_yyyy__HH_mm_ss") + ".txt";
            Debug.Log(path);
            if(debugCreateFile) CreateDummyFile();
        }
    }

    // Update is called once per frame
    void Update(){
        //If the button (Left-Ctrl // Letf-Click) has been pressed, the startTime changes to  start or stop the recording of the actions
        if(Input.GetButtonDown("Fire1")){
            if(startTime<0){
                startTime = Time.time;
                if(debugRecording) Debug.Log("Input recording BEGAN at time: " + Time.time);
            } else {
                startTime = -1f;
                if(debugRecording) Debug.Log("Input recording STOPPED at time: " + Time.time);
                SaveActionsLog();
            }
        }
        if(startTime>=0){
            //TODO Start to record the inputs with the relative time at which they were performed
            if(Input.GetButtonDown("Jump")){
                actions.Add(new Tuple<string, float>("Jump", Time.time-startTime));
            }
        }
    }


    private void SaveActionsLog(){
        if(debugSaving) Debug.Log("Saving ACTUAL data!");

        path = Application.dataPath + "/InputLogs/" + DateTime.Now.ToString("dd_MM_yyyy__HH_mm_ss") + ".txt";
        if(debugPath) Debug.Log("Saving ACTUAL data at: " + path);

        if (!File.Exists(path)){
            // Create a file to write to
            using (StreamWriter sw = File.CreateText(path)){
                //Write in a separate line every single action as "Action\ntime", and empty the list after
                foreach(Tuple<string, float> action in actions){
                    sw.WriteLine(action.Item1);
                    sw.WriteLine(action.Item2);
                }
                actions.Clear();
            }
        }
    }

    //TODO Implement reading in another script using StreamReader https://docs.microsoft.com/en-us/dotnet/api/system.io.file?redirectedfrom=MSDN&view=netframework-4.7.2





    /***************************************************************************
     *                               DEBUGGING                                 *
     **************************************************************************/

     //Variables for the editor. If checked, they will allow some debugging
     public bool debugPath;
     public bool debugCreateFile;
     public bool debugRecording;
     public bool debugSaving;



    /* This function simply creates a dummy file with no real information.
     * Can be useful to check if the file itself is being generated with the given path.
     */
    private void CreateDummyFile(){
        //Checks if the name of the file already exists. If that is te case, the new file is not created
        if (!File.Exists(path)){
            // Create a file to write to
            using (StreamWriter sw = File.CreateText(path)){
                //Dummy text
                sw.WriteLine("Test line... Hello!");
            }
        }
    }


}
