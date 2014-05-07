using Technical.Reflection;
using Technical.Utilities.Extensions;

namespace Technical.Settings
{
    /// <summary>
    /// Reads and writes a POCO setting class
    /// </summary>
    public class SettingPocoDatastore
    {
        private readonly object _settingPocoInstance;

        public SettingPocoDatastore(object settingPocoInstance)
        {
            _settingPocoInstance = settingPocoInstance;
        }

        public void Read(string sectionId)
        {
            var provider = Provider.Get();
            var section = provider.LoadSection(sectionId);

            var properties = PropertyReflectionHelper.GetPropertyNames(_settingPocoInstance);

            foreach (var propertyName in properties)
            {
                if (section.ContainsSetting(propertyName))
                {
                    _settingPocoInstance.SetPropertyValue(propertyName,
                        section.GetSettingUntyped(propertyName).ValueAsObject);
                }
                else
                {
                    throw new SettingException(
                        string.Format("Property {0} on type {1} has not matching Setting-Id in Section-Id {2}",
                            propertyName, _settingPocoInstance.GetType().Name, sectionId));
                }
            }
        }

        public void Write(string sectionId)
        {
            var provider = Provider.Get();
            var section = provider.LoadSection(sectionId);

            var properties = PropertyReflectionHelper.GetPropertyNames(_settingPocoInstance);

            foreach (var propertyName in properties)
            {
                if (section.ContainsSetting(propertyName))
                {
                    section.GetSettingUntyped(propertyName).ValueAsObject =
                        _settingPocoInstance.GetPropertyValue(propertyName);
                }
                else
                {
                    throw new SettingException(
                        string.Format("Property {0} on type {1} has not matching Setting-Id in Section-Id {2}",
                            propertyName, _settingPocoInstance.GetType().Name, sectionId));
                }
            }

            provider.SaveSection(section);
        }
    }
}