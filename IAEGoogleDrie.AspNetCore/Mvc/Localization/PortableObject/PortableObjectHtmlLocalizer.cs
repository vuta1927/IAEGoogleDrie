﻿//using Microsoft.AspNetCore.Mvc.Localization;
//using Microsoft.Extensions.Localization;
//
//namespace IAEGoogleDrie.AspNetCore.AspNetCore.Mvc.Localization.PortableObject
//{
//    public class PortableObjectHtmlLocalizer : HtmlLocalizer
//    {
//        private readonly IStringLocalizer _localizer;
//
//        public string Context { get; private set; }
//
//        public PortableObjectHtmlLocalizer(IStringLocalizer localizer) : base(localizer)
//        {
//            _localizer = localizer;
//        }
//
//        public override LocalizedHtmlString this[string name] => ToHtmlString(_localizer[name]);
//
//        public override LocalizedHtmlString this[string name, params object[] arguments]
//        {
//            get
//            {
//                // TODO: Extract plural arguments, call _localizer with only plural arguments -> result; then call ToHtmlString(result, arguments)
//
//                return ToHtmlString(_localizer[name, arguments]);
//            }
//        }
//    }
//}