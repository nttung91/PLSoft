namespace Technical.Permissions.AttributeHelper
{
    public class ProgramPermissionValidator
    {
        private readonly string _programId;
        private readonly int _programArtId;

        public ProgramPermissionValidator(string programId)
        {
            _programId = programId;
        }

        /// <summary>
        /// ONLY for compatility reasons to check permissions for external plugins/programs
        /// </summary>
        /// <param name="programArtId"></param>
        public ProgramPermissionValidator(int programArtId)
        {
            _programArtId = programArtId;
        }

        public bool HasProgramPermission()
        {
            if (!string.IsNullOrEmpty(_programId))
                return Provider.Get().CanAccessProgram(_programId);
            if (_programArtId > 0)
                return Provider.Get().CanAccessProgram(_programArtId);

            return false;
        }
    }
}