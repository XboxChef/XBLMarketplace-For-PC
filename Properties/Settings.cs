// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Properties.Settings
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace XBLMarketplace_For_PC.Properties
{
    [CompilerGenerated]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = (Settings)SettingsBase.Synchronized((SettingsBase)new Settings());

        private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
        {
        }

        private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
        {
        }

        public static Settings Default => Settings.defaultInstance;

        [DefaultSettingValue("50")]
        [UserScopedSetting]
        [DebuggerNonUserCode]
        public int entry_per_page
        {
            get => (int)this[nameof(entry_per_page)];
            set => this[nameof(entry_per_page)] = (object)value;
        }

        [DefaultSettingValue("1")]
        [DebuggerNonUserCode]
        [UserScopedSetting]
        public int last_page_viewed
        {
            get => (int)this[nameof(last_page_viewed)];
            set => this[nameof(last_page_viewed)] = (object)value;
        }

        [DefaultSettingValue("0")]
        [UserScopedSetting]
        [DebuggerNonUserCode]
        public int regionindex
        {
            get => (int)this[nameof(regionindex)];
            set => this[nameof(regionindex)] = (object)value;
        }

        [UserScopedSetting]
        [DefaultSettingValue("0")]
        [DebuggerNonUserCode]
        public int mediaindex
        {
            get => (int)this[nameof(mediaindex)];
            set => this[nameof(mediaindex)] = (object)value;
        }

        [DefaultSettingValue("0")]
        [UserScopedSetting]
        [DebuggerNonUserCode]
        public int languageindex
        {
            get => (int)this[nameof(languageindex)];
            set => this[nameof(languageindex)] = (object)value;
        }

        [DefaultSettingValue("2")]
        [UserScopedSetting]
        [DebuggerNonUserCode]
        public int batchdelay
        {
            get => (int)this[nameof(batchdelay)];
            set => this[nameof(batchdelay)] = (object)value;
        }

        [DefaultSettingValue("")]
        [UserScopedSetting]
        [DebuggerNonUserCode]
        public string DecompressPathString
        {
            get => (string)this[nameof(DecompressPathString)];
            set => this[nameof(DecompressPathString)] = (object)value;
        }

        [DefaultSettingValue("")]
        [DebuggerNonUserCode]
        [UserScopedSetting]
        public string IsoPathString
        {
            get => (string)this[nameof(IsoPathString)];
            set => this[nameof(IsoPathString)] = (object)value;
        }

        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        [UserScopedSetting]
        public string DownloadPathString
        {
            get => (string)this[nameof(DownloadPathString)];
            set => this[nameof(DownloadPathString)] = (object)value;
        }
    }
}
