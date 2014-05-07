using System;
using System.Collections.Generic;
using System.Linq;
using Manor.Utilities.Environment;
using Manor.Utilities.Extensions;

namespace Manor.ConnectionStrings.DbTypes
{
    public class DatabaseModeValidator
    {
        private readonly ESourceMode _sourceMode = ESourceMode.Undefined;

        public ESourceMode SourceMode
        {
            get { return _sourceMode; }
        }

        public DatabaseModeValidator()
        {
            if (MenuServer.SourceModeExists()) _sourceMode = MenuServer.SourceMode();
        }

        public DatabaseModeValidator(ESourceMode sourceMode)
        {
            _sourceMode = sourceMode;
        }

        public List<EDatabaseMode> GetAllowedDatabaseModes()
        {
            var databaseModes = new List<EDatabaseMode>();

            var enumValues = Enum.GetValues(typeof (EDatabaseMode));

            foreach (var enumValue in enumValues)
            {
                var databaseMode = ((EDatabaseMode) enumValue);
                var allowedSourceModes = databaseMode.GetAttributesOfType<AllowedSourceModeAttribute>();

                databaseModes.AddRange(from allowedSourceMode in allowedSourceModes
                    where allowedSourceMode.SourceMode == _sourceMode
                    select databaseMode);
            }

            return databaseModes;
        }

        public bool IsAllowed(EDatabaseMode databaseMode)
        {
            return GetAllowedDatabaseModes().Exists(mode => mode == databaseMode);
        }
    }
}