﻿using Exrin.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Enums;

namespace Tesla.Model
{
    public class ControlModel : BaseModel, IControlModel
    {

        //<Button Text = "Lock-Unlock" Command="{Binding LockCommand}" />
        //<Button Text = "Honk" Command="{Binding HonkCommand}" />
        //<Button Text = "Flash" Command="{Binding FlashCommand}" />
        //<Label Text = "{Binding ProximityLocationStatus}" />
        //<Button Text="Summon" Command="{Binding SummonCommand}" />
        //<Label Text = "{Binding SummonStatus}" />

        private readonly IAuthModel _authModel = null;

        public ControlModel(IDisplayService displayService, IErrorHandlingService errorHandlingService, IAuthModel authModel)
            : base(displayService, errorHandlingService, new ControlModelState())
        {
            _authModel = authModel;
        }

        public Task<bool> IssueCommand(CommandType type)
        {
            return Task.FromResult(true);
        }
    }
}
