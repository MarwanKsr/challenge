//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Enoca.Core.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class _Product {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal _Product() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Enoca.Core.Resources._Product", typeof(_Product).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Product name can&apos;t be Empty.
        /// </summary>
        public static string Product_Exception_EmptyName {
            get {
                return ResourceManager.GetString("Product_Exception_EmptyName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Product not found.
        /// </summary>
        public static string Product_Exception_EntityNotFound {
            get {
                return ResourceManager.GetString("Product_Exception_EntityNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Company cann&apos;t be null.
        /// </summary>
        public static string Product_Exception_InvalidCompanyId {
            get {
                return ResourceManager.GetString("Product_Exception_InvalidCompanyId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Price can&apos;t be less than zero.
        /// </summary>
        public static string Product_Exception_InvalidPrice {
            get {
                return ResourceManager.GetString("Product_Exception_InvalidPrice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stock can&apos;t be zero or less than zero.
        /// </summary>
        public static string Product_Exception_InvalidStockNumber {
            get {
                return ResourceManager.GetString("Product_Exception_InvalidStockNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This product is out of stock.
        /// </summary>
        public static string Product_Exception_OutOfStock {
            get {
                return ResourceManager.GetString("Product_Exception_OutOfStock", resourceCulture);
            }
        }
    }
}
