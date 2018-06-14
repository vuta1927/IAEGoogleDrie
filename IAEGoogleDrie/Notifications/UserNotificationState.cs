﻿namespace IAEGoogleDrie.Notifications
{
    /// <summary>
    /// Represents state of a <see cref="UserNotificationInfo"/>.
    /// </summary>
    public enum UserNotificationState
    {
        /// <summary>
        /// Notification is not read by user yet.
        /// </summary>
        Unread = 0,

        /// <summary>
        /// Notification is read by user.
        /// </summary>
        Read
    }
}