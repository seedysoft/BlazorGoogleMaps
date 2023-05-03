﻿using OneOf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleMapsComponents.Maps.Extension;

namespace GoogleMapsComponents.Maps
{
    public class ListableEntityBase<TEntityOptions> : EventEntityBase, IDisposable, IJsObjectRef
        where TEntityOptions : ListableEntityOptionsBase
    {
        protected readonly JsObjectRef _jsObjectRef;

        public Guid Guid => _jsObjectRef.Guid;

        internal ListableEntityBase(JsObjectRef jsObjectRef) : base(jsObjectRef)
        {
            _jsObjectRef = jsObjectRef;
        }

        public new void Dispose()
        {
            base.Dispose();
            _jsObjectRef.Dispose();
        }

        public virtual Task<Map> GetMap()
        {
            return _jsObjectRef.InvokeAsync<Map>(
                "getMap");
        }

        /// <summary>
        /// Renders the map entity on the specified map or panorama. 
        /// If map is set to null, the map entity will be removed.
        /// </summary>
        /// <param name="map"></param>
        public virtual async Task SetMap(Map? map)
        {
            await _jsObjectRef.InvokeAsync("setMap", map);

            //_map = map;
        }

        public Task InvokeAsync(string functionName, params object[] args)
        {
            return _jsObjectRef.InvokeAsync(functionName, args);
        }

        public Task<T> InvokeAsync<T>(string functionName, params object[] args)
        {
            return _jsObjectRef.InvokeAsync<T>(functionName, args);
        }

        public Task<OneOf<T, U>> InvokeAsync<T, U>(string functionName, params object[] args)
        {
            return _jsObjectRef.InvokeAsync<T, U>(functionName, args);
        }

        public Task<OneOf<T, U, V>> InvokeAsync<T, U, V>(string functionName, params object[] args)
        {
            return _jsObjectRef.InvokeAsync<T, U, V>(functionName, args);
        }
    }
}
