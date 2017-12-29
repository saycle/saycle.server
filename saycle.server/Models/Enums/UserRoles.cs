namespace saycle.server.Models.Enums
{
    /// <summary>
    /// Roles a user can own.
    /// </summary>
    public static class UserRoles
    {
        /// <summary>
        /// Administrators can do anything.
        /// </summary>
        public const string Administrator = "Administrator";

        /// <summary>
        /// Editors can edit texts.
        /// </summary>
        public const string Editor = "Editor";

        /// <summary>
        /// Users can create new stories and contribute.
        /// </summary>
        public const string User = "User";
    }
}
