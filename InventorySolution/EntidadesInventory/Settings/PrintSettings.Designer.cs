﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntidadesInventory.Settings {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.0.3.0")]
    internal sealed partial class PrintSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static PrintSettings defaultInstance = ((PrintSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new PrintSettings())));
        
        public static PrintSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8")]
        public string AnchoHoja {
            get {
                return ((string)(this["AnchoHoja"]));
            }
            set {
                this["AnchoHoja"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("25")]
        public string AltoHoja {
            get {
                return ((string)(this["AltoHoja"]));
            }
            set {
                this["AltoHoja"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public string MargenArriba {
            get {
                return ((string)(this["MargenArriba"]));
            }
            set {
                this["MargenArriba"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public string MargenAbajo {
            get {
                return ((string)(this["MargenAbajo"]));
            }
            set {
                this["MargenAbajo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public string MargenIzquierda {
            get {
                return ((string)(this["MargenIzquierda"]));
            }
            set {
                this["MargenIzquierda"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public string MargenDerecha {
            get {
                return ((string)(this["MargenDerecha"]));
            }
            set {
                this["MargenDerecha"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("cm")]
        public string MedidaPredeterminada {
            get {
                return ((string)(this["MedidaPredeterminada"]));
            }
            set {
                this["MedidaPredeterminada"] = value;
            }
        }
    }
}
