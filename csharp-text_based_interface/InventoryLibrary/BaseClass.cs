using System;
using System.Collections.Generic;

class BaseClass {
    public string id { get; set; } = Guid.NewGuid().ToString();
    public DateTime date_created { get; set; } = DateTime.Now;
    public DateTime date_updated { get; set; } = DateTime.Now;
}

