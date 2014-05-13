using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Manor.Plugin.Contracts;
using Newtonsoft.Json;
using PhuLiNet.Plugin.Contracts;
using Technical.Permissions.AttributeHelper;
using Technical.Utilities.Responsibility;

namespace PhuLiNet.Plugin.Manager
{
    internal class PluginSummary : IPluginSummary
    {
        private PluginSummary()
        {
        }

        #region IPluginSummary Members

        public string Id { get; internal set; }
        public string FullNameOfType { get; internal set; }
        public string Shortcut { get; internal set; }
        public string Description { get; internal set; }
        public Image Image { get; internal set; }
        public Version Version { get; internal set; }
        public string PermissionId { get; internal set; }
        public string Responsible { get; internal set; }
        public string ProgramType { get; private set; }
        public string[] PreviousShortcuts { get; internal set; }

        public string PreviousShortcutsAsString
        {
            get
            {
                if (PreviousShortcuts != null)
                {
                    const string seperator = ", ";
                    var modules = PreviousShortcuts.Aggregate<string, string>(null,
                        (current, module) => current + (module + seperator));
                    if (modules.EndsWith(seperator)) modules = modules.TrimEnd(seperator.ToCharArray());
                    return modules;
                }
                return null;
            }
        }

        public bool IsValid { get; internal set; }
        public bool IsVisible { get; internal set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }

        #endregion

        internal static IPluginSummary CreateSummary(IPlugin plugin)
        {
            var summary = new PluginSummary
            {
                Id = plugin.Id,
                IsValid = plugin.IsValid,
                Version = plugin.Version,
                IsVisible = plugin.IsVisible,
                FullNameOfType = plugin.GetType().FullName,
                Description = plugin.Description,
                Shortcut = plugin.Shortcut,
                Image = plugin.Image,
                PreviousShortcuts = plugin.PreviousShortcuts,
                ValidFrom = plugin.ValidFrom,
                ValidTo = plugin.ValidTo,
                ProgramType = plugin.GetProgramType()
            };

            var permissionScanner = new PermissionAttributeScanner(plugin);
            summary.PermissionId = permissionScanner.GetPermissionId();

            var responsibleScanner = new ResponsibleAttributeScanner(plugin);
            summary.Responsible = responsibleScanner.GetAttribute() != null
                ? responsibleScanner.GetAttribute().ToString()
                : string.Empty;

            return summary;
        }

        public string ToJsonString()
        {
            var writer = new StringWriter();
            var serializer = new JsonSerializer {Formatting = Formatting.Indented};
            serializer.Serialize(writer, this);
            return writer.ToString();
        }
    }
}