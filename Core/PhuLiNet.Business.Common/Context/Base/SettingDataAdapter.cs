using System;
using Technical.Settings;
using Technical.Settings.Contracts;
using Newtonsoft.Json;
using PhuLiNet.Business.Common.Context.Base;

namespace PhuLiNet.Business.Common.Context.Base
{
    internal class SettingDataAdapter : IContextDataAdapter
    {
        private const string SectionId = "BusinessContexts";

        public IContext LoadContext(Type contextType)
        {
            JsonInit.InitConverter();

            IConfigProvider configProvider = Provider.Get();
            IConfigSection section = configProvider.LoadSingleSetting(SectionId, contextType.FullName);
            if (section.ContainsSetting(contextType.FullName))
            {
                var jsonString = section.GetSetting<string>(contextType.FullName, null).Value;
                try
                {
                    if (!string.IsNullOrEmpty(jsonString))
                    {
                        return (IContext) JsonConvert.DeserializeObject(jsonString, contextType);
                    }
                    return null;
                }
                catch (JsonSerializationException e)
                {
                    throw new JsonSerializationException(string.Format("Error deserializing type {0}", contextType), e);
                }
            }
            return null;
        }

        public void SaveContext(IContext context)
        {
            JsonInit.InitConverter();

            IConfigProvider configProvider = Provider.Get();
            IConfigSection section = configProvider.LoadSingleSetting(SectionId, context.GetType().FullName);
            section.GetSetting<string>(context.GetType().FullName, null, true).Value =
                JsonConvert.SerializeObject(context);
            configProvider.SaveSection(section);
        }
    }
}