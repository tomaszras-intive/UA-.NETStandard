/* Copyright (c) 1996-2022 The OPC Foundation. All rights reserved.
   The source code in this file is covered under a dual-license scenario:
     - RCL: for OPC Foundation Corporate Members in good-standing
     - GPL V2: everybody else
   RCL license terms accompanied with this source code. See http://opcfoundation.org/License/RCL/1.00/
   GNU General Public License as published by the Free Software Foundation;
   version 2 of the License are accompanied with this source code. See http://opcfoundation.org/License/GPLv2
   This source code is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;

namespace Opc.Ua
{
    /// <summary>
    /// Describes how to connect to an endpoint.
    /// </summary>
    public partial class EndpointConfiguration
    {
        #region Constructors
        /// <summary>
        /// Creates an instance of a configuration with reasonable default values.
        /// </summary>
        public static EndpointConfiguration Create()
        {
            EndpointConfiguration configuration = new EndpointConfiguration();

            configuration.OperationTimeout = 120000;
            configuration.UseBinaryEncoding = true;
            configuration.MaxArrayLength = UInt16.MaxValue;
            configuration.MaxByteStringLength = UInt16.MaxValue * 16;
            configuration.MaxMessageSize = UInt16.MaxValue * 64;
            configuration.MaxStringLength = UInt16.MaxValue;
            configuration.MaxBufferSize = UInt16.MaxValue;
            configuration.ChannelLifetime = 120000;
            configuration.SecurityTokenLifetime = 3600000;

            return configuration;
        }

        /// <summary>
        /// Creates an instance of a configuration from ApplicationConfiguration
        /// </summary>
        [System.Obsolete("Use overload that accepts TransportQuotas object")]
        public static EndpointConfiguration Create(ApplicationConfiguration applicationConfiguration)
        {
            if (applicationConfiguration == null || applicationConfiguration.TransportQuotas == null)
            {
                return Create();
            }

            return Create(applicationConfiguration.TransportQuotas);
        }

        /// <summary>
        /// Creates an instance of a configuration from TransportQuotas configuration.
        /// </summary>
        /// <param name="transportQuotas">TransportQuotas configuration</param>
        /// <param name="useBinaryEncoding">Use binary encoding</param>
        /// <returns>EndpointConfiguration instance</returns>
        public static EndpointConfiguration Create(TransportQuotas transportQuotas, bool useBinaryEncoding = true)
        {
            if (transportQuotas == null)
            {
                return Create();
            }

            return new EndpointConfiguration {
                OperationTimeout = transportQuotas.OperationTimeout,
                UseBinaryEncoding = useBinaryEncoding,
                MaxArrayLength = transportQuotas.MaxArrayLength,
                MaxByteStringLength = transportQuotas.MaxByteStringLength,
                MaxMessageSize = transportQuotas.MaxMessageSize,
                MaxStringLength = transportQuotas.MaxStringLength,
                MaxBufferSize = transportQuotas.MaxBufferSize,
                ChannelLifetime = transportQuotas.ChannelLifetime,
                SecurityTokenLifetime = transportQuotas.SecurityTokenLifetime
            };
        }
        #endregion
    }
}
