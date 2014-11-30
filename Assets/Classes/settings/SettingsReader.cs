using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

public class SettingsReader
{
    private string filePath;

    public SettingsReader(string filePath)
    {
        this.filePath = filePath;
    }

    public Dictionary<string, string> read()
    {
        Dictionary<string, string> settingMap = new Dictionary<string, string>();
        try
        {
            StreamReader stream = File.OpenText(filePath);
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                string[] lineTokens = line.Split(new char[] { '=' });
                if (lineTokens.Length != 2)
                    Debug.LogError("cannot parse line (too many arguments): " + line);
                else
                {
                    string key = lineTokens[0].Trim();
                    string value = lineTokens[1].Trim();

                    if (key.Length == 0 || value.Length == 0)
                        Debug.LogError("cannot parse line (incorrect argument): " + line);
                    else
                    {
                        try
                        {
                            settingMap.Add(key, value);
                        }
                        catch (ArgumentException)
                        {
                            settingMap.Remove(key);
                            settingMap.Add(key, value);
                        }
                    }
                }
            }
            stream.Close();
            return settingMap;
        }
        catch (FileNotFoundException)
        {
            return null;
        }

    }

    public void write(Dictionary<string, string> settings)
    {
        StreamWriter stream = new StreamWriter(filePath);
        foreach (KeyValuePair<string, string> couple in settings)
        {
            stream.WriteLine(couple.Key + '=' + couple.Value);
        }
        stream.Close();
    }
}