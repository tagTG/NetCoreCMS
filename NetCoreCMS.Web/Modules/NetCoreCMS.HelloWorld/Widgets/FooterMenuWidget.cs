﻿using NetCoreCMS.Framework.Core.Mvc.Views;
using NetCoreCMS.Framework.Modules.Widgets;
using NetCoreCMS.HelloWorld.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreCMS.HelloWorld.Widgets
{
    public class FooterMenuWidget : IWidget
    {
        string _title;
        string _body;
        string _footer;
        string _configJson;
        string _description;
        string _viewFileName;
        IViewRenderService _viewRenderService;

        public string WidgetId { get { return "NetCoreCMS.HelloWorld.Widgets.FooterMenuWidget"; } }

        public string Title { get { return _title; } }

        public string Description { get { return _description; } }

        public string Body { get { return _body; } }

        public string Footer { get { return _footer; } }

        public string ConfigJson { get { return _configJson; } }

        public string ViewFileName { get { return _viewFileName; } }

        public FooterMenuWidget(IViewRenderService viewRenderService)
        {
            _viewRenderService = viewRenderService;
        }

        public void Init()
        {
            _title = "Footer menu";
            _description = "This is a sample widget which will show an image.";
            _footer = "Footer";
            _viewFileName = "Widgets/FooterMenu";
        }

        public string RenderBody()
        {
            _body = _viewRenderService.RenderToStringAsync<HelloWidgetController>(_viewFileName, null).Result;
            return _body;
        }

        public string RenderBody(string html = "")
        {
            if (!string.IsNullOrEmpty(html))
            {
                html.Replace(Widget.BODY_REPLACE_TEXT, _body);
            }
            else
            {
                html = _body;
            }
            
            return html;
        }

        public string RenderFooter(string html = "")
        {
            if (!string.IsNullOrEmpty(html))
            {
                html.Replace(Widget.FOOTER_REPLACE_TEXT, _body);
            }
            else
            {
                html = _footer;
            }

            return html;
        }

        public string RenderTitle(string html = "")
        {
            if (!string.IsNullOrEmpty(html))
            {
                html.Replace(Widget.TITLE_REPLACE_TEXT, _body);
            }
            else
            {
                html = _title;
            }

            return html;
        }

        public string RenderConfig()
        {
            throw new NotImplementedException();
        }
    }
}
