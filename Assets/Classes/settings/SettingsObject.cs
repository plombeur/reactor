using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

public class SettingsObject
{
    private Dictionary<string, Setting> settings;
    private SettingsReader reader;

    public SettingsObject(string path, List<Setting> template)
    {
        this.reader = new SettingsReader(path);
        settings = new Dictionary<string, Setting>();
        foreach (Setting setting in template)
            settings.Add(setting.getSettingName(), setting);
    }

    public bool load()
    {
        Dictionary<string, string> textSettings = reader.read();
        if (textSettings == null)
            return false;

        foreach (KeyValuePair<string, Setting> couple in settings)
            if (textSettings.ContainsKey(couple.Value.getSettingName()))
                couple.Value.setBruteTextValue(textSettings[couple.Value.getSettingName()]);

        return true;
    }

    public void save()
    {
        Dictionary<string, string> textSettings = new Dictionary<string, string>();
        foreach (KeyValuePair<string, Setting> couple in settings)
            textSettings.Add(couple.Value.getSettingName(), couple.Value.getBruteTextValue());
        reader.write(textSettings);
    }

    public Setting getSetting(string key)
    {
        return settings[key];
    }

    public bool setSetting(string key, string value)
    {
        return settings[key].setString(value);
    }
    public bool setSetting(string key, int value)
    {
        return settings[key].setInt(value);
    }
    public bool setSetting(string key, float value)
    {
        return settings[key].setFloat(value);
    }
    public void loadDefault()
    {
        foreach (KeyValuePair<string, Setting> couple in settings)
            couple.Value.resetDefault();
    }
}