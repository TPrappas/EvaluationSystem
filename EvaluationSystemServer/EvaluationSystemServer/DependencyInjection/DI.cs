using AutoMapper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;


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
                    mMapper = Host.Services.GetRequiredService<Mapper>();

                return mMapper;
            }
        }

        /// <summary>
        /// The database context
        /// </summary>
        public static EvaluationSystemDBContext GetDbContext => Host.Services.GetRequiredService<EvaluationSystemDBContext>();

        /// <summary>
        /// Gets the projects manager
        /// </summary>
        public static ProjectsManager GetProjectsManager => Host.Services.GetRequiredService<ProjectsManager>();

        /// <summary>
        /// Gets the users manager
        /// </summary>
        public static UsersManager GetUsersManager => Host.Services.GetRequiredService<UsersManager>();


        #endregion
    }
}
