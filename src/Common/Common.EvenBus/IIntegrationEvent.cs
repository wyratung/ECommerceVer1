﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EvenBus
{
    public interface IIntegrationEvent
    {
        public DateTime CreationDate { get; }
        public Guid Id { get; set; }
    }
}
