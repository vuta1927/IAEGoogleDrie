﻿using System;
using System.Collections.Generic;
using System.Text;
using IAEGoogleDrie.Dependency;
using IAEGoogleDrie.Messaging.Handling;

namespace IAEGoogleDrie.Messaging.Events
{
    class NullEventBus : IEventBus, ISingletonDependency
    {
        public void Publish(IEvent @event)
        {
        }

        public void Subscribe<T, TH>()
            where T : IEvent
            where TH : IEventHandler<T>
        {
        }

        public void SubscribeDynamic<TH>(string eventName) where TH : IDynamicEventHandler
        {
        }

        public void Unsubscribe<T, TH>()
            where T : IEvent
            where TH : IEventHandler<T>
        {
        }

        public void UnsubscribeDynamic<TH>(string eventName) where TH : IDynamicEventHandler
        {
        }
    }
}
