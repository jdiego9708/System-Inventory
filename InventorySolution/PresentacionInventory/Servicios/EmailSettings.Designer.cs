﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PresentacionInventory.Servicios {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
    internal sealed partial class EmailSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static EmailSettings defaultInstance = ((EmailSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new EmailSettings())));
        
        public static EmailSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("jdiego9708@gmail.com")]
        public string emailTo {
            get {
                return ((string)(this["emailTo"]));
            }
            set {
                this["emailTo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("solucionesinformaticas9708@gmail.com")]
        public string eMailFrom {
            get {
                return ((string)(this["eMailFrom"]));
            }
            set {
                this["eMailFrom"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("smtp.gmail.com")]
        public string eMailSMTP {
            get {
                return ((string)(this["eMailSMTP"]));
            }
            set {
                this["eMailSMTP"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("soluciones2020*")]
        public string eMailPass {
            get {
                return ((string)(this["eMailPass"]));
            }
            set {
                this["eMailPass"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("587")]
        public string portEmail {
            get {
                return ((string)(this["portEmail"]));
            }
            set {
                this["portEmail"] = value;
            }
        }
    }
}
