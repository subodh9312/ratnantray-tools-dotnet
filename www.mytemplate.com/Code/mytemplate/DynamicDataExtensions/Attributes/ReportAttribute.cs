using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.DynamicData;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace DynamicDataExtensions.Attributes
{
    /*******************************************/
    //RESTRICTIONS:
    //1. Column Display Names cannot have '/' or '-' character.
    /*******************************************/
    public class ReportAttribute : Attribute
    {
        public string Prefix { get; private set; }
        public string Postfix { get; private set; }
        public Morphenes Affix { get; private set; }

        private ReportAttribute()
        {
        }

        public ReportAttribute(string prefix, string postfix)
        {
            if (prefix.Contains('-') || prefix.Contains('/'))
                throw new Exception("ReportAttibute Prefix cannot have the following characters '-', '/'");
            if (postfix.Contains('-') || postfix.Contains('/'))
                throw new Exception("ReportAttibute Postfix cannot have the following characters '-', '/'");

            Prefix = prefix;
            Postfix = postfix;
            if (prefix == "" && postfix == "")
                Affix = Morphenes.NONE;
            else if (prefix == "" && postfix != "")
                Affix = Morphenes.ONLY_POSTFIX;
            else if (prefix != "" && postfix == "")
                Affix = Morphenes.ONLY_PREFIX;
            else if (prefix != "" && postfix != "")
                Affix = Morphenes.BOTH;
            else
                throw new Exception("Could not deduce ReportAttribute Morphenes!");
        }
    }

    public enum Morphenes
    {
        ONLY_PREFIX,
        ONLY_POSTFIX,
        BOTH,
        NONE
    }

    public static class ReportExtensions
    {
        public static void AddReportsLinks(MetaTable table, ContentPlaceHolder cph, Page page)
        {
            foreach (MetaColumn C in table.Columns)
            {
                List<ReportAttribute> Atr = C.Attributes.OfType<ReportAttribute>().ToList<ReportAttribute>();

                if (Atr.Count > 0)
                {
                    Literal lt = new Literal();
                    lt.Text = String.Format("<h2>{0} by {1} </h2>", table.DisplayName, C.DisplayName);
                    cph.Controls.Add(lt);

                    ReportAttribute Dec = Atr[0];
                    string Prefix;
                    string Postfix;

                    Prefix = String.IsNullOrEmpty(Dec.Prefix) ? "" : (Dec.Prefix + "-");
                    Postfix = String.IsNullOrEmpty(Dec.Postfix) ? "" : ("-" + Dec.Postfix);

                    if (C.ColumnType == typeof(System.Boolean))
                    {
                        BulletedList BLBool = new BulletedList();
                        BLBool.DisplayMode = BulletedListDisplayMode.HyperLink;

                        BLBool.Items.Add(new ListItem(Prefix + "Yes" + Postfix, page.ResolveUrl("~/" + table.DisplayName + "/" + C.DisplayName + "/" + Prefix + "Yes" + Postfix)));
                        BLBool.Items.Add(new ListItem(Prefix + "No" + Postfix, page.ResolveUrl("~/" + table.DisplayName + "/" + C.DisplayName + "/" + Prefix + "No" + Postfix)));
                        BLBool.Items.Add(new ListItem(Prefix + "All" + Postfix, page.ResolveUrl("~/" + table.DisplayName + "/" + C.DisplayName + "/" + Prefix + "All" + Postfix)));

                        cph.Controls.Add(BLBool);
                    }
                    else if (C.IsInteger && C.GetEnumType().IsEnum)
                    {
                        BulletedList BLEnum = new BulletedList();
                        BLEnum.DisplayMode = BulletedListDisplayMode.HyperLink;

                        Array values = C.GetEnumType().GetEnumValues();
                        foreach (object value in values)
                        {
                            BLEnum.Items.Add(new ListItem(Prefix + value.ToString() + Postfix, page.ResolveUrl("~/" + table.DisplayName + "/" + C.DisplayName + "/" + Prefix + value.ToString() + Postfix)));
                        }

                        cph.Controls.Add(BLEnum);
                    }
                }
            }
        }
    }
}
