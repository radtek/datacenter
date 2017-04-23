﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bigdesk8.Ext
{
    public class FilterRule
    {
        public FilterRule()
        {
        }
        public FilterRule(string field, object value)
            : this(field, value, "equal")
        {
        }

        public FilterRule(string field, object value, string op)
        {
            this.field = field;
            this.value = value;
            this.op = op;
        }

        public string field { get; set; }
        public object value { get; set; }
        public string op { get; set; }
        public string type { get; set; }
    }
}
