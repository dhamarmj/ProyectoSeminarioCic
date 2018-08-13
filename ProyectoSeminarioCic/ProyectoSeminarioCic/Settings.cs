using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ProyectoSeminarioCic
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault("email", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("email", value);
            }
        }
        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("password", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("password", value);
            }
        }
        public static string AccesToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("accesstoken", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("accesstoken", value);
            }
        }
        public static string Rol
        {
            get
            {
                return AppSettings.GetValueOrDefault("rol", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("rol", value);
            }
        }
        public static string idUsuario
        {
            get
            {
                return AppSettings.GetValueOrDefault("idusuario", SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue("idusuario", value);
            }
        }

    }
}
