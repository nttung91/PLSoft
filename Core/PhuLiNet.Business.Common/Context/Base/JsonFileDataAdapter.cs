using System;
using System.IO;
using Newtonsoft.Json;
using PhuLiNet.Business.Common.Context.Base;

namespace PhuLiNet.Business.Common.Context.Base
{
    internal class JsonFileDataAdapter : IContextDataAdapter
    {
        private readonly string _path;

        public JsonFileDataAdapter(string path)
        {
            _path = path;
        }

        public IContext LoadContext(Type contextType)
        {
            string filename = Path.Combine(_path, GetJsonFilename(contextType));
            if (File.Exists(filename))
            {
                using (StreamReader file = File.OpenText(filename))
                {
                    var serializer = new JsonSerializer();
                    JsonInit.InitSerializer(serializer);
                    try
                    {
                        return (IContext) serializer.Deserialize(file, contextType);
                    }
                    catch (JsonSerializationException e)
                    {
                        throw new JsonSerializationException(
                            string.Format("Error deserializing type {0}", contextType), e);
                    }
                }
            }

            return null;
        }

        public void SaveContext(IContext context)
        {
            string filename = Path.Combine(_path, GetJsonFilename(context.GetType()));
            using (StreamWriter file = File.CreateText(filename))
            {
                var serializer = new JsonSerializer();
                JsonInit.InitSerializer(serializer);
                serializer.Serialize(file, context);
            }
        }

        private string GetJsonFilename(Type contextType)
        {
            return string.Format("{0}.json", contextType.FullName);
        }
    }
}