using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.FlyWeightMode
{
    class WebsiteFactory
    {
        private Hashtable flyweights = new Hashtable();

        public Website GetWebsiteCategory(string key)
        {
            if (!flyweights.Contains(key))
                flyweights.Add(key,new ConcreteWebsite(key));
            return (Website)flyweights[key];
        }

        public int GetWebsiteCount()
        {
            return flyweights.Count;
        }
    }
}
