using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBEntity
{
    /// <summary>
    /// Clase para datos de configuracion
    /// Author: James Huiza
    /// Date: 4 de Noviembre 2020
    /// </summary>
    public class ConfigSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ApplicationType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OrganizationName { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string ApplicationDescription { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string UrlBaseIdentityServer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PathUpload { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string PathImages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PathTemplates { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PathDocuments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PathDocGenerate { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string PathLog { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public CircuitBreak CircuitBreak { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EmailConfiguration EmailConfiguration { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    /// </summary>
    public class EmailConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        public string UrlBaseEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PortBaseEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EmailBase { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PasswordEmailBase { get; set; }
    }


    /// <summary>
    /// CircuitBreaker
    /// </summary>
    public class CircuitBreak
    {
        /// <summary>
        /// 
        /// </summary>
        public string HandledEventsAllowed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DurationOfBreakCircuit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RetryCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SleepDuration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HandlerLifetime { get; set; }

    }
}
