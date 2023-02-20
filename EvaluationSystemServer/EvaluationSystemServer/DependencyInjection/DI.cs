using AutoMapper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;


namespace EvaluationSystemServer
{
    public class DI
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="GetMapper"/> property
        /// </summary>
        private static IMapper mMapper;

        #endregion

        #region Public Properties

        /// <summary>
        /// The host
        /// </summary>
        public static IHost Host { get; set; }

        /// <summary>
        /// The mapper
        /// </summary>
        public static IMapper GetMapper
        {
            get
            {
                if (mMapper == null)
                    mMapper = Host.Services.GetService<Mapper>();

                return mMapper;
            }
        }

        #endregion
    }
}
