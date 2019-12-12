using System;
using System.Linq;
using System.Web.DynamicData;
using AjaxControlToolkit.HTMLEditor;

namespace DynamicDataExtensions.Attributes.HTMLEditorAttribute
{
    /// <summary>
    /// Attribute to identify which column to use as a 
    /// parent column for the child column to depend upon
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class HtmlEditorAttribute : Attribute
    {
        /// <summary>
        /// Default Contructor
        /// </summary>
        public HtmlEditorAttribute()
        {
        }

        /// <summary>
        /// Active editing panel (Design, Html, Preview) on control loaded 
        /// </summary>
        public AjaxControlToolkit.HTMLEditor.ActiveModeType ActiveMode { get; set; }

        /// <summary>
        /// If true, editing panel is focused and cursor is set 
        /// inside it ("Design" or "HTML text") on initial load 
        /// or editing panel change
        /// </summary>
        public Boolean AutoFocus { get; set; }

        /// <summary>
        /// A css class override used to define a custom look 
        /// and feel for the HTMLEditor. See the HTMLEditor 
        /// Theming section for more details
        /// </summary>
        public String CssClass { get; set; }

        /// <summary>
        /// Sets the path of additional CSS file used for 
        /// HTMLEditor's content rendering in "Design" panel. 
        /// If not set, the default CSS file is used which is 
        /// embedded as a WebResource and is a 
        /// part of the Toolkit assembly
        /// </summary>
        public String DesignPanelCssPath { get; set; }

        /// <summary>
        /// Sets the path of CSS file used for HTMLEditor's 
        /// content rendering in "Design" and "Preview" panels. 
        /// If not set, the default CSS file is used which is 
        /// embedded as a WebResource and is a part of the 
        /// Toolkit assembly
        /// </summary>
        public String DocumentCssPath { get; set; }

        /// <summary>
        /// A css class override used to define a custom look for the 
        /// HTMLEditor's "HTML text" mode panel. See the HTMLEditor 
        /// Theming section for more details
        /// </summary>
        public String HtmlPanelCssClass { get; set; }

        /// <summary>
        /// If true, Tab key navigation is suppressed inside 
        /// HTMLEditor control 
        /// </summary>
        public Boolean IgnoreTab { get; set; }

        /// <summary>
        /// If true, HTMLEditor's content is cleaned up on 
        /// initial load. MS Word specific tags are removed 
        /// </summary>
        public Boolean InitialCleanUp { get; set; }

        /// <summary>
        /// If true, JavaScript code is suppressed 
        /// in HTMLEditor's content 
        /// </summary>
        public Boolean NoScript { get; set; }

        /// <summary>
        ///  If true, all Unicode characters in 
        ///  HTML content are replaced with &#code;
        /// </summary>
        public Boolean NoUnicode { get; set; }

        /// <summary>
        /// The client-side script that executes after 
        /// active mode (editing panel) changed
        /// </summary>
        public String OnClientActiveModeChanged { get; set; }

        /// <summary>
        /// The client-side script that executes before 
        /// active mode (editing panel) changed
        /// </summary>
        public String OnClientBeforeActiveModeChanged { get; set; }

        /// <summary>
        /// If true, no white spaces inserted on Tab key 
        /// press in Design mode. Default Tab key navigation 
        /// is processing in this case 
        /// </summary>
        public Boolean SuppressTabInDesignMode { get; set; }

        /// <summary>
        /// Sets the height of the body of the HTMLEditor 
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Sets the width of the body of the HTMLEditor 
        /// </summary>
        public int Width { get; set; }
    }
    public static partial class HelperExtansionMethods
    {
        /// <summary>
        /// Get the attribute or a default instance of the attribute
        /// if the Column attribute do not contain the attribute
        /// </summary>
        /// <typeparam name="T">
        /// Attribute type
        /// </typeparam>
        /// <param name="table">
        /// Column to search for the attribute on.
        /// </param>
        /// <returns>
        /// The found attribute or a default 
        /// instance of the attribute of type T
        /// </returns>
        public static T GetAttributeOrDefault<T>(this MetaColumn column) where T : Attribute, new()
        {
            return column.Attributes.OfType<T>().DefaultIfEmpty(new T()).FirstOrDefault();
        }
    }
}
