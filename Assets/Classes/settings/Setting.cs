using System;
using UnityEngine;

public class Setting
{
    private string name;
    private SettingDataInteger intValue;
    private SettingDataFloat floatValue;
    private SettingDataString stringValue;
    private SettingDataKey keyValue;

    public Setting(string name, int min, int max, int defaultValue)
    {
        this.name = name;
        this.intValue = new SettingDataInteger(defaultValue,min,max);
    }
    public Setting(string name, float min, float max, float defaultValue )
    {
        this.name = name;
        this.floatValue = new SettingDataFloat(defaultValue, min, max);
    }
    public Setting(string name, string defaultValue )
    {
        this.name = name;
        this.stringValue = new SettingDataString(defaultValue);
    }
    public Setting(string name, string defaultValue, string[] acceptableList )
    {
        this.name = name;
        this.stringValue = new SettingDataString(defaultValue,acceptableList);
    }
    public Setting(string name, KeyCode defaultValue)
    {
        this.name = name;
        this.keyValue = new SettingDataKey(defaultValue);
    }
    public string getSettingName()
    {
        return name;
    }
    public string getBruteTextValue()
    {
        if (intValue != null)
            return intValue.getValue().ToString();
        else if (floatValue != null)
            return floatValue.getValue().ToString();
        else if (stringValue != null)
            return stringValue.getValue();
        else if (keyValue != null)
            return keyValue.getValue().ToString();
        return null;
    }
    public void setBruteTextValue(string bruteValue)
    {
        if (intValue != null)
            intValue.setValueText(bruteValue);
        else if (floatValue != null)
            floatValue.setValueText(bruteValue);
        else if (stringValue != null)
            stringValue.setValueText(bruteValue);
        else if (keyValue != null)
            keyValue.setValueText(bruteValue);
    }
    public int getInt()
    {
        return intValue.getValue();
    }
    public float getFloat()
    {
        return floatValue.getValue();
    }
    public string getString()
    {
        return stringValue.getValue();
    }
    public KeyCode getKey()
    {
        return keyValue.getValue();
    }
    public bool setInt(int newValue)
    {
        return !intValue.setValue(newValue, false);
    }
    public bool setFloat(float newValue)
    {
        return floatValue.setValue(newValue,false);
    }
    public bool setString(string newValue)
    {
        return stringValue.setValue(newValue,false);
    }
   public bool setKey(KeyCode newKey)
    {
        return keyValue.setValue(newKey, false); 
   }
    public void resetDefault()
    {
        if (intValue != null)
            intValue.resetDefault();
        else if (floatValue != null)
            floatValue.resetDefault();
        else if (stringValue != null)
            stringValue.resetDefault();
        else if (keyValue != null)
            keyValue.resetDefault();
    }
}

abstract class SettingData<T>
{
    protected T value, defaultValue;

    public SettingData(T defaultValue)
    {
        this.value = defaultValue;
        this.defaultValue = defaultValue;
    }
    public T getValue()
    {
        return value;
    }
    public bool setValueText(string bruteValue)
    {
        T value;
        if (!tryParse(bruteValue, out value))
            return false;
        return setValue(value,true);
    }
    public bool setValue(T newValue,bool validateIfNecessary)
    {
        if (validateIfNecessary)
        {
            this.value = newValue;
            validate();
        }
        if (!isValide(newValue))
            return false;

        this.value = newValue;
        return true;
    }
    public void resetDefault()
    {
        this.value = defaultValue;
    }
    public abstract bool tryParse(string bruteValue,out T value);
    public abstract bool isValide(T value);
    public abstract void validate();
}
class SettingDataInteger : SettingData<int>
{
    private int min, max;

    public SettingDataInteger(int defaultValue,int min, int max) : base(defaultValue)
    {
        this.min = min;
        this.max = max;
    }
    public float getMin()
    {
        return min;
    }
    public float getMax()
    {
        return max;
    }
    public override void validate()
    {
        value = Mathf.Min(getValue(), min);
        value = Mathf.Max(getValue(), max);
    }

    public override bool tryParse(string bruteValue, out int value)
    {
        string[] splitedValue = bruteValue.Split(new char[] { '.' });
        if (splitedValue.Length == 2)
        {
            float floatValue;
            if (float.TryParse(bruteValue,out floatValue))
            {
                value = (int)floatValue;
                return true;
            }
        }
        else if (splitedValue.Length < 2)
        {
            int intValue;
            if (int.TryParse(bruteValue, out intValue))
            {
                value = intValue;
                return true;
            }
        }
        value = 0;
        return false;
    }

    public override bool isValide(int value)
    {
        if (value >= min && value <= max)
            return true;
        return false;
    }
}

class SettingDataFloat : SettingData<float>
{
    private float min, max;

    public SettingDataFloat(float defaultValue,float min, float max ) : base(defaultValue)
    {
        this.min = min;
        this.max = max;
    }
    public float getMin()
    {
        return min;
    }
    public float getMax()
    {
        return max;
    }
    public override void validate()
    {
        value = Mathf.Min(getValue(), min);
        value = Mathf.Max(getValue(), max);
    }
    public override bool tryParse(string bruteValue, out float value)
    {
        string[] splitedValue = bruteValue.Split(new char[] { '.' });
        if (splitedValue.Length == 2)
        {
            float floatValue;
            if (float.TryParse(bruteValue, out floatValue))
            {
                value = floatValue;
                return true;
            }
        }
        else if (splitedValue.Length < 2)
        {
            int intValue;
            if (int.TryParse(bruteValue, out intValue))
            {
                value = (float)intValue;
                return true;
            }
        }
        value = 0;
        return false;
    }

    public override bool isValide(float value)
    {
        if (value >= min && value <= max)
            return true;
        return false;
    }
}

class SettingDataString : SettingData<string>
{
    private string[] acceptables;

    public SettingDataString(string defaultValue) : base(defaultValue)
    {

    }
    public SettingDataString(string defaultValue,string[] acceptableList) : base(defaultValue)
    {
        this.acceptables = acceptableList;
    }
    public override void validate()
    {
       if (acceptables != null)
        {
            if (isValide(getValue()))
                return;
            resetDefault();
        }
    }
    public override bool tryParse(string bruteValue, out string value)
    {
        value = bruteValue;
        return true;
    }

    public override bool isValide(string value)
    {
        if (acceptables != null)
        {
            foreach (string acceptable in acceptables)
                if (acceptable.Equals(getValue()))
                    return true;
            return false;
        }
        return true;
    }
}
class SettingDataKey : SettingData<KeyCode>
{
    public SettingDataKey(KeyCode defaultValue) : base(defaultValue)
    {
    
    }

    public override bool tryParse(string bruteValue, out KeyCode value)
    {
        try
        {
            object codeObject = Enum.Parse(typeof(KeyCode), bruteValue);
            if (codeObject != null)
            {
                value = (KeyCode)codeObject;
                return true;
            }
            else
            {
                value = KeyCode.None;
                return false;
            }
        }
        catch (Exception)
        {
            value = KeyCode.None;
            return false;
        }
    }

    public override bool isValide(KeyCode value)
    {
        return true;
    }

    public override void validate()
    {
        // nothing to do
    }
}