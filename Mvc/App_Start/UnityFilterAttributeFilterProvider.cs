﻿using Microsoft.Practices.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.App_Start
{
    public class UnityFilterAttributeFilterProvider : FilterAttributeFilterProvider
    {
        private IUnityContainer _container;

        public UnityFilterAttributeFilterProvider(IUnityContainer container)
        {
            _container = container;
        }

        protected override IEnumerable<FilterAttribute> GetControllerAttributes(
                    ControllerContext controllerContext,
                    ActionDescriptor actionDescriptor)
        {

            var attributes = base.GetControllerAttributes(controllerContext,
                                                          actionDescriptor);
            foreach (var attribute in attributes)
            {
                _container.BuildUp(attribute.GetType(), attribute);
            }

            return attributes;
        }

        protected override IEnumerable<FilterAttribute> GetActionAttributes(
                    ControllerContext controllerContext,
                    ActionDescriptor actionDescriptor)
        {

            var attributes = base.GetActionAttributes(controllerContext,
                                                      actionDescriptor);
            foreach (var attribute in attributes)
            {
                _container.BuildUp(attribute.GetType(), attribute);
            }

            return attributes;
        }
    }
}