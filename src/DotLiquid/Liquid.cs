﻿using System.Resources;
using DotLiquid.Util;

namespace DotLiquid
{
    /// <summary>
    /// Utiliy containing regexes for Liquid syntax and registering default tags and blocks
    /// </summary>
    public static class Liquid
    {
        internal static readonly ResourceManager ResourceManager = new ResourceManager(typeof(Properties.Resources));

        public static readonly string FilterSeparator = R.Q(@"\|");
        public static readonly string ArgumentSeparator = R.Q(@",");
        public static readonly string FilterArgumentSeparator = R.Q(@":");
        public static readonly string VariableAttributeSeparator = R.Q(@".");
        /// <summary>
        /// Tag开始{%, 正则：(?-mix:\{\%)
        /// </summary>
        public static readonly string TagStart = R.Q(@"\{\%");
        /// <summary>
        /// Tag结束%}, 正则：(?-mix:\%\})
        /// </summary>
        public static readonly string TagEnd = R.Q(@"\%\}");
        /// <summary>
        ///
        /// </summary>
        public static readonly string VariableSignature = R.Q(@"\(?[\w\-\.\[\]]\)?");
        public static readonly string VariableSegment = R.Q(@"[\w\-]");
        /// <summary>
        /// 对象开始{{, 正则：(?-mix:\{\{)
        /// </summary>
        public static readonly string VariableStart = R.Q(@"\{\{");
        /// <summary>
        /// 对象结束}}, 正则：(?-mix:\}\})
        /// </summary>
        public static readonly string VariableEnd = R.Q(@"\}\}");
        public static readonly string VariableIncompleteEnd = R.Q(@"\}\}?");
        public static readonly string QuotedString = R.Q(@"""[^""]*""|'[^']*'");
        public static readonly string QuotedFragment = string.Format(R.Q(@"{0}|(?:[^\s,\|'""]|{0})+"), QuotedString);
        public static readonly string QuotedAssignFragment = string.Format(R.Q(@"{0}|(?:[^\s\|'""]|{0})+"), QuotedString);
        public static readonly string TagAttributes = string.Format(R.Q(@"(\w+)\s*\:\s*({0})"), QuotedFragment);
        public static readonly string AnyStartingTag = R.Q(@"\{\{|\{\%");
        public static readonly string PartialTemplateParser = string.Format(R.Q(@"{0}.*?{1}|{2}.*?{3}"), TagStart, TagEnd, VariableStart, VariableIncompleteEnd);
        public static readonly string TemplateParser = string.Format(R.Q(@"({0}|{1})"), PartialTemplateParser, AnyStartingTag);
        public static readonly string VariableParser = string.Format(R.Q(@"\[[^\]]+\]|{0}+\??"), VariableSegment);
        public static readonly string LiteralShorthand = R.Q(@"^(?:\{\{\{\s?)(.*?)(?:\s*\}\}\})$");

        /// <summary>
        /// 匹配{# xx #}的正则表达式
        /// </summary>
        public static readonly string CommentShorthand = R.Q(@"^(?:\{\s?\#\s?)(.*?)(?:\s*\#\s?\})$");
        public static bool UseRubyDateFormat = false;

        static Liquid()
        {
            Template.RegisterTag<Tags.Assign>("assign");
            Template.RegisterTag<Tags.Block>("block");
            Template.RegisterTag<Tags.Capture>("capture");
            Template.RegisterTag<Tags.Case>("case");
            Template.RegisterTag<Tags.Comment>("comment");
            Template.RegisterTag<Tags.Cycle>("cycle");
            Template.RegisterTag<Tags.Extends>("extends");
            Template.RegisterTag<Tags.For>("for");
            Template.RegisterTag<Tags.Break>("break");
            Template.RegisterTag<Tags.Continue>("continue");
            Template.RegisterTag<Tags.If>("if");
            Template.RegisterTag<Tags.IfChanged>("ifchanged");
            Template.RegisterTag<Tags.Include>("include");
            Template.RegisterTag<Tags.Literal>("literal");
            Template.RegisterTag<Tags.Unless>("unless");
            Template.RegisterTag<Tags.Raw>("raw");

            Template.RegisterTag<Tags.Html.TableRow>("tablerow");

            Template.RegisterFilter(typeof(StandardFilters));
        }
    }
}
